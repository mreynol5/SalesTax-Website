using Microsoft.AspNetCore.Http;

namespace SalesTax.Models
{
	public interface ILineItem
	{
		int Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		float Discount { get; set; }
		int Quantity { get; set; }
		float UnitPrice { get; set; }
		string ProductTaxCode { get; set; }
		public string PhotoPath { get; set; }
	}
}