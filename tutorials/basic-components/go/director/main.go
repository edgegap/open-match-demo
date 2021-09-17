package main

import (
	"context"
	"director/swagger"
	"errors"
	"fmt"
	"io"
	"log"
	"sync"
	"time"

	"google.golang.org/grpc"
	"open-match.dev/open-match/pkg/pb"
)

const (
	openMatchMatchFunctionHost = "basics-match-function"
	openMatchMatchFunctionPort = 50502
	openMatchBackendService    = "open-match-backend:50505"
	// Game server data
	gameServerPort = "<APP_PORT>"      // String | E.G. 25565
	appName        = "<APP_NAME>"      // E.G. MySuperGame
	appVersion     = "<APP_VERSION>"   // E.G. V1
	arbitriumAPI   = "<ARBITRIUM_API>" // E.G. https://api.edgegap.com/
	apiToken       = "<API_TOKEN>"     // E.G. 1111aa11aa11111a1aa11111d111a111111111a1
)

func main() {
	fmt.Println("Stating Edgegap tutorial's Director!")

	backendService := newBackendConnection()

	for range time.Tick(time.Second * 5) {
		fmt.Println("Creating matches...")

		var wg sync.WaitGroup
		for _, p := range getProfiles() {
			wg.Add(1)
			go func(wg *sync.WaitGroup, profile *pb.MatchProfile) {
				defer wg.Done()

				matches, err := fetch(profile, backendService)

				if err != nil {
					log.Printf("Failed to fetch matches for profile %v, got %s", profile.GetName(), err.Error())
					return
				}

				log.Printf("Generated %v matches for profile %v", len(matches), profile.GetName())

				if err := assign(matches, backendService); err != nil {
					log.Printf("Failed to assign servers to matches, got %s", err.Error())
					return
				}
			}(&wg, p)
		}
		wg.Wait()
	}
}

// Get all the possible profiles
func getProfiles() []*pb.MatchProfile {
	var profiles []*pb.MatchProfile
	modes := []string{"mode.casual", "mode.ranked", "mode.private"}
	for _, mode := range modes {
		profiles = append(profiles, &pb.MatchProfile{
			Name: fmt.Sprintf("%s_profile", mode),
			Pools: []*pb.Pool{
				{
					Name: "pool_" + mode,
					TagPresentFilters: []*pb.TagPresentFilter{
						{
							Tag: mode,
						},
					},
				},
			},
		},
		)
	}

	return profiles
}

// Create a connection to Open Match Backend service
func newBackendConnection() pb.BackendServiceClient {
	conn, err := grpc.Dial(
		openMatchBackendService, grpc.WithInsecure(),
	)

	if err != nil {
		log.Printf("Error while communicating with Open Match Backend, err: %v", err.Error())
	}

	return pb.NewBackendServiceClient(conn)
}

// fetch Fetch profile's matches
func fetch(p *pb.MatchProfile, backendService pb.BackendServiceClient) ([]*pb.Match, error) {
	// Making request object
	req := &pb.FetchMatchesRequest{
		Config: &pb.FunctionConfig{
			Host: openMatchMatchFunctionHost,
			Port: openMatchMatchFunctionPort,
			Type: pb.FunctionConfig_GRPC,
		},
		Profile: p,
	}

	// Getting match proposals
	stream, err := backendService.FetchMatches(context.Background(), req)
	if err != nil {
		return nil, err
	}

	var result []*pb.Match
	for {
		resp, err := stream.Recv()
		if err == io.EOF {
			break
		}

		if err != nil {
			return nil, err
		}

		result = append(result, resp.GetMatch())
	}

	return result, nil
}

// assign Deploy a game server with CoDeMa API and assign its IP to match's tickets
func assign(matches []*pb.Match, backendService pb.BackendServiceClient) error {
	for _, match := range matches {
		// Getting Tickets ID and players IP
		ticketIDs := []string{}
		IPS := []string{}
		for _, t := range match.GetTickets() {
			ticketIDs = append(ticketIDs, t.Id)
			IPS = append(IPS, string(t.Extensions["playerIp"].Value))
		}

		// Game server port
		gamePort := gameServerPort

		// Deploying game server and getting ip
		conn, err := getServerIP(IPS, gamePort)

		if err != nil {
			return fmt.Errorf("AssignTickets failed for match %v, got %w", match.GetMatchId(), err)
		}

		// Assign game server to tickets
		req := &pb.AssignTicketsRequest{
			Assignments: []*pb.AssignmentGroup{
				{
					TicketIds: ticketIDs,
					Assignment: &pb.Assignment{
						Connection: conn,
					},
				},
			},
		}

		if _, err := backendService.AssignTickets(context.Background(), req); err != nil {
			return fmt.Errorf("AssignTickets failed for match %v, got %w", match.GetMatchId(), err)
		}

		log.Printf("Assigned server %v to match %v", conn, match.GetMatchId())
	}

	return nil
}

// getServerIP Deploy the Game server and fetch its IP when the server is ready
func getServerIP(ips []string, gamePort string) (string, error) {
	// Creating Arbitrium deploy request
	payload := swagger.DeployModel{
		AppName:     appName,
		VersionName: appVersion,
		IpList:      ips,
	}

	// Creating API Client to communicate with arbitrium
	configuration := swagger.NewConfiguration()
	configuration.BasePath = arbitriumAPI
	client := swagger.NewAPIClient(configuration)
	auth := context.WithValue(context.Background(), swagger.ContextAPIKey, swagger.APIKey{
		Key:    apiToken,
		Prefix: "token",
	})

	// Deploying
	request, _, err := client.DeploymentsApi.Deploy(auth, payload)

	if err != nil {
		log.Printf("Could not deploy game server, err: %v", err.Error())
		return "", err
	}

	timeout := 30.0
	start := time.Now()

	status := ""
	var response swagger.Status

	// Waiting for the server to be ready
	for status != "Status.READY" && time.Since(start).Seconds() <= timeout {
		response, _, err = client.DeploymentsApi.DeploymentStatusGet(auth, request.RequestId)

		if err != nil {
			log.Printf("Error while fetching status, err: %v", err.Error())
		}

		status = response.CurrentStatus
		time.Sleep(1 * time.Second) //  let's wait a bit
	}

	if time.Since(start).Seconds() > timeout {
		return "", errors.New("Timeout while waiting for deployment")
	}

	return fmt.Sprintf("%s:%d", response.PublicIp, response.Ports[gamePort].External), nil
}
