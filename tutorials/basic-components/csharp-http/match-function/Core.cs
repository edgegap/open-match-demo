using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace match_function
{
    // All the constants used in the program
    public static class Constant
    {
        public const string OpenMatchQueryService = "open-match-query:51503";
        public const string MatchName = "basics-match-function";
    }

    public static class MatchFunction
    {
        public static async Task Handle(HttpContext context, ILogger logger)
        {
            context.Request.ContentType = "application/json";
            OpenMatchRunRequest body = await context.Request.ReadFromJsonAsync<OpenMatchRunRequest>();

            logger.LogInformation($"Generating proposals for profile {body.Profile.Name}");

            IDictionary<string, IList<OpenMatchTicket>> poolTickets = await GetPoolTickets(body.Profile.Pools);
            IEnumerable<OpenMatchMatch> proposals = MakeMatches(body.Profile, poolTickets);

            logger.LogInformation("Streaming proposals to Open Match");
            foreach (OpenMatchMatch proposal in proposals)
            {
                var responseChunk = new OpenMatchStreamResult<OpenMatchRunResponse>
                {
                    Result = new OpenMatchRunResponse
                    {
                        Proposal = proposal
                    }
                };
                await JsonSerializer.SerializeAsync(context.Response.Body, responseChunk);
                await context.Response.Body.FlushAsync();

                logger.LogInformation($"Streaming proposal {proposal.MatchId} to Open Match");
            }
        }

        private static async Task<IDictionary<string, IList<OpenMatchTicket>>> GetPoolTickets(IList<OpenMatchPool> pools)
        {
            IDictionary<string, IList<OpenMatchTicket>> result = new Dictionary<string, IList<OpenMatchTicket>>();

            foreach (OpenMatchPool pool in pools)
            {
                try
                {
                    // Making a request to Open Match Front End. In an production environment, we recommend using a generated SDK
                    // from Open Match's OpenAPI specification.
                    // https://open-match.dev/site/swaggerui/index.html?urls.primaryName=Query
                    HttpClient client = new HttpClient();

                    OpenMatchQueryTicketsRequest body = new OpenMatchQueryTicketsRequest
                    {
                        Pool = pool
                    };

                    // Sending the request to Open Match Query
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        $"http://{Constant.OpenMatchQueryService}/v1/queryservice/tickets:query",
                        body
                    );

                    string stringBody = await response.Content.ReadAsStringAsync();
                    IEnumerable<string> results = stringBody.Trim().Split('\n').Where(s => s is not null && s.Trim() != "");

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        throw new Exception($"Resquest Error {(int)response.StatusCode} - {stringBody}");
                    }

                    List<OpenMatchTicket> tickets = new();

                    // Extracting propsals from response
                    foreach (string rawJSON in results)
                    {
                        var matchResult = JsonSerializer.Deserialize<OpenMatchStreamResult<OpenMatchQueryTicketsResponse>>(rawJSON);
                        tickets.AddRange(matchResult.Result.Tickets);
                    }

                    result.Add(pool.Name, tickets);
                }
                catch (Exception ex)
                {
                    throw new Exception("TODO", ex);
                }
            }

            return result;
        }

        private static IEnumerable<OpenMatchMatch> MakeMatches(OpenMatchMatchProfile profile, IDictionary<string, IList<OpenMatchTicket>> poolTickets)
        {
            int ticketsPerPoolPerMatch = 2;
            int count = 0;

            while (true)
            {
                bool insufficientTickets = false;
                List<OpenMatchTicket> matchTickets = new();

                foreach (string poolName in poolTickets.Keys)
                {
                    IList<OpenMatchTicket> tickets = poolTickets[poolName];
                    if (tickets.Count < ticketsPerPoolPerMatch)
                    {
                        // This pool is completely drained out. Stop creating matches.
                        insufficientTickets = true;
                        break;
                    }

                    // Remove the Tickets from this pool and add them to the match proposal.
                    matchTickets.AddRange(tickets.Take(ticketsPerPoolPerMatch));
                    poolTickets[poolName] = tickets.Skip(ticketsPerPoolPerMatch).ToArray();
                }

                if (insufficientTickets)
                {
                    break;
                }

                yield return new OpenMatchMatch
                {
                    MatchId = $"profile-{profile.Name}-time-{DateTime.UtcNow.ToString("o")}-{count}",
                    MatchProfile = profile.Name,
                    MatchFunction = Constant.MatchName,
                    Tickets = matchTickets.ToArray(),
                };

                count++;
            }
        }
    }
}