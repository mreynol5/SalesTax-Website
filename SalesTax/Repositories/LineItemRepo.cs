using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTax.Repositories
{
	public class LineItemRepo : ILineItemRepo
	{
		private readonly List<ILineItem> _LinetemList;
		public LineItemRepo()
		{
			//This is a mocked list of purchased items.
			//Remove this list for production
			List<ILineItem> lineItemList = new List<ILineItem>()
					{
							new LineItem () { Name = "Tire",  Description = "All weather", Id = 1001,  Quantity = 4,  UnitPrice = 125.95F, ProductTaxCode = "0"  },
							new LineItem () {  Name = "Struts",  Description = "Truck struts",  Id = 1015,   Quantity = 2, UnitPrice = 145.95F, ProductTaxCode = "0" },
							new LineItem() {  Name = "Radiator",  Description = "F 150",  Id = 1021,  Quantity = 6, UnitPrice = 209.95F, ProductTaxCode = "0" },
							new LineItem() {  Name = "Wipers",  Description = "Winter",  Id = 1038,  Quantity = 1,  UnitPrice = 09.95F, ProductTaxCode = "0" },
							new LineItem () {  Name = "Seat Covers",  Description = "Cloth",  Id = 1047, Quantity = 4,  UnitPrice = 52.95F, ProductTaxCode = "0" }
					 };
			_LinetemList = lineItemList;
		}
		public IEnumerable<ILineItem> GetLineItemsList()
		{
			List<ILineItem> lineItemList = new List<ILineItem>();
			return lineItemList;
		}

		public ILineItem GetLineItem(int id)
		{
			ILineItem item = _LinetemList.Find(e => e.Id == id); 
			return item;
		}

		public ILineItem Add(ILineItem newProduct)
		{
			newProduct.Id = _LinetemList.Max(e => e.Id) + 1;
			_LinetemList.Add(newProduct);
			return newProduct;
		}

		public ILineItem Delete(int id)
		{
			ILineItem item = _LinetemList.FirstOrDefault(e => e.Id == id);
			if (item != null)
			{
				_LinetemList.Remove(item);
			}
			return item;
		}

		public ILineItem Update(ILineItem itemChanges)
		{
			ILineItem item = _LinetemList.FirstOrDefault(e => e.Id == itemChanges.Id);
			if (item != null)
			{
				item.Name = itemChanges.Name;
				item.Description = itemChanges.Description;
				item.Discount = itemChanges.Discount;
			}
			return item;
		}
	}
}
