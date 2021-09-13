package main

import (
	"fmt"
	"log"
	"net"
	"time"

	"google.golang.org/grpc"
	"open-match.dev/open-match/pkg/matchfunction"
	"open-match.dev/open-match/pkg/pb"
)

const (
	matchFunctionServePort = 50502
	matchName              = "basics-match-function"
	// Link inside kubernetes
	openMatchQueryService = "open-match-query:50503"
)

func main() {
	log.Println("Starting Edgegap's Match Function!")

	// Create Open Match Query service connection
	conn, err := grpc.Dial(
		openMatchQueryService, grpc.WithInsecure(),
	)

	if err != nil {
		log.Fatalf("Error while creating gRPC connection, err: %v", err.Error())
	}

	queryServiceClient := pb.NewQueryServiceClient(conn)

	// Creating basicMatchFunction
	basicMatchFunction := basicMatchFunction{
		queryServiceClient: queryServiceClient,
	}

	server := grpc.NewServer()

	pb.RegisterMatchFunctionServer(server, &basicMatchFunction) // IMPORTANT Register MatchFunction

	ln, err := net.Listen("tcp", fmt.Sprintf(":%d", matchFunctionServePort))

	if err != nil {
		log.Fatalf("TCP net listener initialization failed for port %v, got %s", 50502, err.Error())
	}

	log.Printf("TCP net listener initialized for port %v", matchFunctionServePort)
	err = server.Serve(ln)
	if err != nil {
		log.Fatalf("gRPC serve failed, got %s", err.Error())
	}
}

type basicMatchFunction struct {
	queryServiceClient pb.QueryServiceClient
}

func (bmf *basicMatchFunction) Run(req *pb.RunRequest, stream pb.MatchFunction_RunServer) error {
	// Fetch tickets for the pools specified in the Match Profile.
	log.Printf("Generating proposals for function %v", req.GetProfile().GetName())

	poolTickets, err := matchfunction.QueryPools(stream.Context(), bmf.queryServiceClient, req.GetProfile().GetPools())
	if err != nil {
		log.Printf("Failed to query tickets for the given pools, got %s", err.Error())
		return err
	}

	// Generate proposals.
	proposals, err := makeMatches(req.GetProfile(), poolTickets)
	if err != nil {
		log.Printf("Failed to generate matches, got %s", err.Error())
		return err
	}

	log.Printf("Streaming %v proposals to Open Match", len(proposals))
	// Stream the generated proposals back to Open Match.
	for _, proposal := range proposals {
		if err := stream.Send(&pb.RunResponse{Proposal: proposal}); err != nil {
			log.Printf("Failed to stream proposals to Open Match, got %s", err.Error())
			return err
		}
	}

	return nil
}

func makeMatches(p *pb.MatchProfile, poolTickets map[string][]*pb.Ticket) ([]*pb.Match, error) {
	ticketsPerPoolPerMatch := 2
	var matches []*pb.Match
	count := 0
	for {
		insufficientTickets := false
		matchTickets := []*pb.Ticket{}
		for pool, tickets := range poolTickets {
			if len(tickets) < ticketsPerPoolPerMatch {
				// This pool is completely drained out. Stop creating matches.
				insufficientTickets = true
				break
			}

			// Remove the Tickets from this pool and add them to the match proposal.
			matchTickets = append(matchTickets, tickets[0:ticketsPerPoolPerMatch]...)
			poolTickets[pool] = tickets[ticketsPerPoolPerMatch:]
		}

		if insufficientTickets {
			break
		}

		matches = append(matches, &pb.Match{
			MatchId:       fmt.Sprintf("profile-%v-time-%v-%v", p.GetName(), time.Now().Format("2006-01-02T15:04:05.00"), count),
			MatchProfile:  p.GetName(),
			MatchFunction: matchName,
			Tickets:       matchTickets,
		})

		count++
	}

	return matches, nil
}
