﻿using System.Text.Json.Serialization;

namespace SalesTax.Models
{

    public class NexusAddress
	{       
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }
    }
}
