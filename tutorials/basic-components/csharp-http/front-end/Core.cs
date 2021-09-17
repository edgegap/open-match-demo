using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace front_end
{
    // All the constants used in the program
    public static class Constant
    {
        // Link inside kubernetes
        public static string OpenMatchFrontendService => "open-match-frontend:51504";
    }

    public class CreateTicket
    {
        public static async Task Handle(HttpContext context, ILogger logger)
        {
            logger.LogInformation("Creating ticket...");

            // Get The player IP. This will be used later to make a call at Arbitrium (Edgegap's solution)
            IPAddress? playerIP = context.Connection.RemoteIpAddress?.MapToIPv4();

            // Bind the request JSON body to our model
            CreateTicketPayload payload = await context.Request.ReadFromJsonAsync<CreateTicketPayload>();

            string response = await CreateTicketToOpenMatch(payload.Mode, playerIP?.ToString() ?? "0.0.0.0");

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(response);
        }

        /// <summary>
        /// Create a ticket by communicating with Open Match core Front End service
        /// </summary>
        private static async Task<string> CreateTicketToOpenMatch(string mode, string playerIP)
        {
            HttpClient client = new HttpClient();

            byte[] playerIPBytes = System.Text.Encoding.UTF8.GetBytes(playerIP);

            // Creating the payload
            OpenMatchCreateTicketRequest body = new OpenMatchCreateTicketRequest
            {
                Ticket = new OpenMatchTicket
                {
                    // Tags can support multiple values but for simplicity, the demo function
                    // assumes only single mode selection per Ticket.
                    SearchFields = new OpenMatchSearchFields { Tags = new string[] { mode } },
                    // Adding player IP to create the game server later using Arbitrium (Edgegap's solution)
                    // You can add other values in extensions. Those values will be ignored by Open Match. They are meant tu use by the developper. 
                    // Find all valid type here: https://developers.google.com/protocol-buffers/docs/reference/google.protobuf
                    Extensions = new Dictionary<string, ProtobufAny>
                        {
                            {
                                "playerIp",
                                new ProtobufAny
                                {
                                    TypeUrl = "google.protobuf.StringValue",
                                    Value = playerIPBytes
                                }
                            }
                        }
                }
            };

            // Sending the request to Open Match Front End
            HttpResponseMessage response = await client.PostAsJsonAsync(
                $"http://{Constant.OpenMatchFrontendService}/v1/frontendservice/tickets",
                body
            );

            // Check if we were able to create the ticket
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string msg = $"ERROR - Was not able to create a ticket: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }

    public class GetTicket
    {
        public static async Task Handle(HttpContext context, string ticketId)
        {
            // Making a request to Open Match Front End. In an production environment, we recommend using a generated SDK
            // from Open Match's OpenAPI specification.
            // https://open-match.dev/site/swaggerui/index.html#/
            HttpClient client = new HttpClient();

            // Sending the request to Open Match Front End
            HttpResponseMessage response = await client.GetAsync($"http://{Constant.OpenMatchFrontendService}/v1/frontendservice/tickets/{ticketId}");

            // Check if we were able to Get the ticket
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string msg = $"ERROR - Was not able to get ticket {ticketId}: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }

            string responseContent = await response.Content.ReadAsStringAsync();

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(responseContent);
        }
    }

    public class DeleteTicket
    {
        public static async Task Handle(HttpContext context, string ticketId)
        {
            HttpClient client = new HttpClient();

            // Sending the request to Open Match Front End
            HttpResponseMessage response = await client.DeleteAsync($"http://{Constant.OpenMatchFrontendService}/v1/frontendservice/tickets/{ticketId}");

            // Check if we were able to Delete the ticket
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string msg = $"ERROR - Was not able to delete ticket {ticketId}: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                Console.WriteLine(msg);
                throw new Exception(msg);
            }

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { Id = ticketId });
        }
    }
}