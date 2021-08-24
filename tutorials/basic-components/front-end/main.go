package main

import (
	"context"
	"fmt"
	"log"
	"net/http"

	"github.com/golang/protobuf/ptypes/any"
	"github.com/labstack/echo/v4"
	"google.golang.org/grpc"
	"open-match.dev/open-match/pkg/pb"
)

const (
	// Link inside kubernetes
	openMatchFrontendService = "open-match-frontend:50504"
)

func main() {
	e := echo.New()

	// How to extract IP
	e.IPExtractor = echo.ExtractIPDirect()

	e.GET("/", func(c echo.Context) error {
		return c.String(http.StatusOK, "Open Match Front End Edgegap's tutorial (basic)")
	})

	// Create a ticket
	e.POST("/v1/tickets", createTicket)

	// Get a ticket
	e.GET("/v1/tickets/:ticketId", getTicket)

	// Delete a ticket
	e.DELETE("/v1/tickets/:ticketId", deleteTicket)

	e.Logger.Fatal(e.Start(":51504"))
}

// TicketRequestModel represent the model tath we should receive for our create ticket endpoint
type TicketRequestModel struct {
	Mode string
}

// Create a ticket by communicating with Open Match core Front End service
func createTicket(echoContext echo.Context) error {
	log.Println("Creating ticket...")

	// Get The player IP. This will be used later to make a call at Arbitrium (Edgegap's solution)
	echoServer := echoContext.Echo()
	request := echoContext.Request()

	playerIP := echoServer.IPExtractor(request)

	userTicketRequest := TicketRequestModel{}

	// Bind the request JSON body to our model
	err := echoContext.Bind(&userTicketRequest)

	if err != nil {
		panic("Request Payload didn't match TicketRequestModel attributes")
	}

	service := getFrontendServiceClient()

	req := &pb.CreateTicketRequest{
		Ticket: &pb.Ticket{
			SearchFields: &pb.SearchFields{
				// Tags can support multiple values but for simplicity, the demo function
				// assumes only single mode selection per Ticket.
				Tags: []string{
					userTicketRequest.Mode,
				},
			},
			Extensions: map[string]*any.Any{
				// Adding player IP to create the game server later using Arbitrium (Edgegap's solution)
				// You can add other values in extensions. Those values will be ignored by Open Match. They are meant tu use by the developper.
				// Find all valid type here: https://developers.google.com/protocol-buffers/docs/reference/google.protobuf
				"playerIp": {
					TypeUrl: "type.googleapis.com/google.protobuf.StringValue",
					Value:   []byte(playerIP),
				},
			},
		},
	}

	ticket, err := service.CreateTicket(context.Background(), req)

	if err != nil {
		log.Printf("Was not able to create a ticket, err: %s\n", err.Error())
	}

	return echoContext.JSON(http.StatusOK, ticket)
}

// Get a object that can communicate with Open Match Front End service.
func getFrontendServiceClient() pb.FrontendServiceClient {
	conn, err := grpc.Dial(
		openMatchFrontendService, grpc.WithInsecure(),
	)

	if err != nil {
		panic(fmt.Sprintf("Could not dial Open Match Frontend service via gRPC, err: %v", err.Error()))
	}

	return pb.NewFrontendServiceClient(conn)
}

func getTicket(echoContext echo.Context) error {
	ticketID := echoContext.Param("ticketId")

	service := getFrontendServiceClient()

	req := &pb.GetTicketRequest{
		TicketId: ticketID,
	}

	ticket, err := service.GetTicket(context.Background(), req)

	if err != nil {
		log.Printf("Was not able to get a ticket, err: %s\n", err.Error())
		return echo.NewHTTPError(http.StatusNotFound, "Resource not found")
	}

	return echoContext.JSON(http.StatusOK, ticket)
}

func deleteTicket(echoContext echo.Context) error {
	ticketID := echoContext.Param("ticketId")

	service := getFrontendServiceClient()

	req := &pb.DeleteTicketRequest{
		TicketId: ticketID,
	}

	_, err := service.DeleteTicket(context.Background(), req)

	if err != nil {
		fmt.Printf("Was not able to delete a ticket, err: %s\n", err.Error())
		return echo.NewHTTPError(http.StatusNotFound, "Resource not found")
	}

	return echoContext.JSON(http.StatusOK, pb.Ticket{Id: ticketID})
}
