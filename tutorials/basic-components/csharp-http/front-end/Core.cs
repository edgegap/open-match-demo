using System.Net;
using System.Text.Json.Serialization;

namespace front_end
{
    public static class Constant
    {
        public static string OpenMatchFrontendService => "open-match-frontend:51504";
    }

    public struct CreateTicketPayload
    {
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
    }

    /**
     * We create these structs for the tutorial. 
     * We recommend generating an SDK with the Open Match's OpenAPI specification.
     * https://open-match.dev/site/swaggerui/index.html#/
     */
    public struct OpenMatchCreateTicketPayload
    {
        public struct SearchFields
        {
            [JsonPropertyName("tags")]
            public string[] Tags { get; set; }
        }

        public struct Extension
        {
            [JsonPropertyName("type_url")]
            public string TypeUrl { get; set; }
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }

        public struct Ticket
        {
            [JsonPropertyName("search_fields")]
            public SearchFields SearchFields { get; set; }
            [JsonPropertyName("extensions")]
            public Dictionary<string, Extension> Extensions { get; set; }
        }

        [JsonPropertyName("ticket")]
        public Ticket CreatedTicket { get; set; }
    }

    public class CreateTicket
    {
        public static async Task Handle(HttpContext context)
        {
            Console.WriteLine("Creating ticket...");

            // Get The player IP. This will be used later to make a call at Arbitrium (Edgegap's solution)
            IPAddress? playerIP = GetIPAddress(context);

            // Get the payload of the request
            CreateTicketPayload payload = await context.Request.ReadFromJsonAsync<CreateTicketPayload>();

            string response = await CreateTicketToOpenMatch(payload.Mode, playerIP?.ToString() ?? "0.0.0.0");

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(response);
        }

        private static IPAddress? GetIPAddress(HttpContext context) => context.Connection.RemoteIpAddress;

        private static async Task<string> CreateTicketToOpenMatch(string mode, string playerIP)
        {
            // Making a request to Open Match Front End. In an production environment, we recommend using a generated SDK
            // from Open Match's OpenAPI specification.
            // https://open-match.dev/site/swaggerui/index.html#/
            HttpClient client = new HttpClient();

            byte[] playerIPBytes = System.Text.Encoding.UTF8.GetBytes(playerIP);
            string playerIPBase64 = Convert.ToBase64String(playerIPBytes);

            // Creating the payload
            OpenMatchCreateTicketPayload body = new OpenMatchCreateTicketPayload
            {
                CreatedTicket = new OpenMatchCreateTicketPayload.Ticket
                {
                    SearchFields = new OpenMatchCreateTicketPayload.SearchFields { Tags = new string[] { mode } },
                    Extensions = new Dictionary<string, OpenMatchCreateTicketPayload.Extension>
                        {
                            {
                                "playerIp",
                                new OpenMatchCreateTicketPayload.Extension
                                {
                                    TypeUrl = "type.googleapis.com/google.protobuf.StringValue",
                                    Value = playerIPBase64
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
            // Making a request to Open Match Front End. In an production environment, we recommend using a generated SDK
            // from Open Match's OpenAPI specification.
            // https://open-match.dev/site/swaggerui/index.html#/
            HttpClient client = new HttpClient();

            // Sending the request to Open Match Front End
            HttpResponseMessage response = await client.DeleteAsync($"http://{Constant.OpenMatchFrontendService}/v1/frontendservice/tickets/{ticketId}");

            // Check if we were able to Get the ticket
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