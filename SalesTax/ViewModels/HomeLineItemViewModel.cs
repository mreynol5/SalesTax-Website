using SalesTax.Models;

namespace SalesTax.ViewModels
{
	public class HomeLineItemViewModel
	{
		public ILineItem  lineItem { get; set; }
		public string PageTitle { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Id { get;  set; }
		public int Quantity { get;  set; }
		public float UnitPrice { get;  set; }
		public string ProductTaxCode { get; set; }
	}
}
