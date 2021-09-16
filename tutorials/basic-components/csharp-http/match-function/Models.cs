using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace match_function
{
    /**
    * We create these structs for the tutorial. 
    * We recommend generating an SDK with the Open Match's OpenAPI specification.
    * https://open-match.dev/site/swaggerui/index.html?urls.primaryName=Query
    * https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    */

    // Based On OpenMatchRunRequest in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchRunRequest
    {
        [JsonPropertyName("profile")]
        public OpenMatchMatchProfile Profile { get; set; }
    }

    // Based On OpenMatchMatchProfile in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchMatchProfile
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("pools")]
        public OpenMatchPool[] Pools { get; set; }
    }

    // Based On OpenMatchPool in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchPool
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("tag_present_filters")]
        public TagPresentFilter[] TagPresentFilters { get; set; }
    }

    // Based On TagPresentFilter in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct TagPresentFilter
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }

    // Based On OpenMatchQueryTicketsRequest in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=Query
    public struct OpenMatchQueryTicketsRequest
    {
        [JsonPropertyName("pool")]
        public OpenMatchPool Pool { get; set; }
    }

    // Based On Stream result in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchStreamResult<T>
    {
        [JsonPropertyName("result")]
        public T Result { get; set; }
    }

    // Based On Stream result in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=Query
    public struct OpenMatchQueryTicketsResponse
    {
        [JsonPropertyName("tickets")]
        public OpenMatchTicket[] Tickets { get; set; }
    }

    // Based On OpenMatchTicket in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchTicket
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("search_fields")]
        public OpenMatchSearchFields SearchFields { get; set; }
        [JsonPropertyName("extensions")]
        public Dictionary<string, ProtobufAny> Extensions { get; set; }
    }

    // Based On OpenMatchSearchFields in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=Query
    public struct OpenMatchSearchFields
    {
        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }
    }

    // Based On ProtobufAny in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct ProtobufAny
    {
        [JsonPropertyName("@type")]
        public string TypeUrl { get; set; }
        [JsonPropertyName("value")]
        public byte[] Value { get; set; }
    }

    // Based On OpenMatchMatch in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchMatch
    {
        [JsonPropertyName("match_id")]
        public string MatchId { get; set; }
        [JsonPropertyName("match_profile")]
        public string MatchProfile { get; set; }
        [JsonPropertyName("match_function")]
        public string MatchFunction { get; set; }
        [JsonPropertyName("tickets")]
        public OpenMatchTicket[] Tickets { get; set; }
    }

    // Based On OpenMatchRunResponse in https://open-match.dev/site/swaggerui/index.html?urls.primaryName=MatchFunction
    public struct OpenMatchRunResponse
    {
        [JsonPropertyName("proposal")]
        public OpenMatchMatch Proposal { get; set; }
    }

    
}