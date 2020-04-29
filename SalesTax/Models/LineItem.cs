﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SalesTax.Models
{
	public class LineItem : ILineItem
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("product_tax_code")]
		public string ProductTaxCode { get; set; }

		[JsonPropertyName("unit_price")]
		public float UnitPrice { get; set; }

		[JsonPropertyName("discount")]
		public float Discount { get; set; }
	}
}
