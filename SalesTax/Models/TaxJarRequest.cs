using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Taxjar;

namespace SalesTax.Models
{
	public class TaxJarRequest
	{
		public Taxjar.TaxjarApi client { get; set; } = new TaxjarApi("7e5bdb532b034a0a6746202b93d40d7b");

		[JsonPropertyName("from_city")]
		public string FromCity { get; set; } = "Stuart";

		[JsonPropertyName("from_country")]
		public string FromCountry { get; set; } = "US";

		[JsonPropertyName("to_country")]
		public string ToCountry { get; set; } = "US";

		[JsonPropertyName("to_zip")]
		public string ToZip { get; set; } = "34997";

		[JsonPropertyName("to_state")]
		public string ToState { get; set; } = "FL";

		[JsonPropertyName("to_city")]
		public string ToCity { get; set; } = "Stuart";

		[JsonPropertyName("amount")]
		public float Amount { get; set; } = 0.0F;

		[JsonPropertyName("line_items")]
		public LineItem[] Lineitem { get; set; }

	}
}
