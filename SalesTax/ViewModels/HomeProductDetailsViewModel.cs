using SalesTax.Models;

namespace SalesTax.ViewModels
{
	public class HomeProductDetailsViewModel
	{
		public Product Product { get; set; }
		public string PageTitle { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Id { get;  set; }
		public int Quantity { get;  set; }
		public string UnitPrice { get;  set; }
		public string ProductTaxCode { get; set; }
		public string PhotoPath { get; set; }
	}
}
