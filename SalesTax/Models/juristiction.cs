using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SalesTax.Models
{
	public class juristiction
	{
		[JsonPropertyName("country")]
		public string Country { get; set; }

		[JsonPropertyName("state")]
		public string State { get; set; }

		[JsonPropertyName("county")]
		public string County { get; set; }

		[JsonPropertyName("city")]
		public string City { get; set; }
	}
}
