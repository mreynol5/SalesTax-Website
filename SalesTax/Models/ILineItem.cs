namespace SalesTax.Models
{
	public interface ILineItem
	{
		float Discount { get; set; }
		int Id { get; set; }
		string ProductTaxCode { get; set; }
		int Quantity { get; set; }
		float UnitPrice { get; set; }
	}
}