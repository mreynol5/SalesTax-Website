using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Repositories
{
	public class MockLineItemRepo : ILineItemRepo
	{
		private List<ILineItem> _LinetemList;
		public MockLineItemRepo()
		{
			_LinetemList = new List<ILineItem>()
			{
				new LineItem () { Name = "Tire",  Description = "All weather", Id = 1001,  Quantity = 4,  UnitPrice = 125.95F, ProductTaxCode = "0"  },
				new LineItem () {  Name = "Struts",  Description = "Truck struts",  Id = 1015,   Quantity = 2, UnitPrice = 145.95F, ProductTaxCode = "0" },
				new LineItem() {  Name = "Radiator",  Description = "F 150",  Id = 1021,  Quantity = 6, UnitPrice = 209.95F, ProductTaxCode = "0" },
				new LineItem() {  Name = "Wipers",  Description = "Winter",  Id = 1038,  Quantity = 1,  UnitPrice = 09.95F, ProductTaxCode = "0" },
				new LineItem () {  Name = "Seat Covers",  Description = "Cloth",  Id = 1047, Quantity = 4,  UnitPrice = 52.95F, ProductTaxCode = "0" }
			 };
		}

		public List<ILineItem> GetLineItemsList()
		{
			return _LinetemList;
		}

		public ILineItem GetLineItem(int Id)
		{
			ILineItem item = _LinetemList.Find(e => e.Id == Id);
			return item;
		}
	}
}
