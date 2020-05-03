namespace SalesTax.Models
{
	public interface ILineItem
	{
		string Name { get; set; }
		string Description { get; set; }
		float Discount { get; set; }
		int Id { get; set; }
		int Quantity { get; set; }
		float UnitPrice { get; set; }
		string ProductTaxCode { get; set; }
	}
}