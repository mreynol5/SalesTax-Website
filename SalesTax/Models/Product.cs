using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesTax.Models
{
	public class Product
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		private string _orderDate;
		public string OrderDate
		{
			set => _orderDate = DateTime.Now.ToString();
		}

		[Required]
		[MaxLength (50, ErrorMessage = "Name cannot exceed 50 characters")]
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[Required]
		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("product_tax_code")]
		public string ProductTaxCode { get; set; }

		[Required]
		[JsonPropertyName("unit_price")]
		public float UnitPrice { get; set; }

		[JsonPropertyName("discount")]
		public float Discount { get; set; }

		[JsonPropertyName("photoPath")]
		public string PhotoPath { get; set; }
	}
}
