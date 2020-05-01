using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Repositories
{
	public class MockLineItemRepo : ILineItemRepo
	{
		private readonly List<ILineItem> _LinetemList;
		public MockLineItemRepo()
		{
			List<ILineItem> lineItemList = new List<ILineItem>()
					{
							new LineItem () { Id = 1001,  Quantity = 4,  UnitPrice = 145.95F  },
							new LineItem () { Id = 1015,   Quantity = 2, UnitPrice = 145.95F },
							new LineItem() { Id = 1021,  Quantity = 6, UnitPrice = 209.95F },
							new LineItem() { Id = 1038,  Quantity = 1,  UnitPrice = 09.95F },
							new LineItem () { Id = 1047, Quantity = 4,  UnitPrice = 52.95F }
					 };
			_LinetemList = lineItemList;
		}

		public List<ILineItem> GetLineItemsList()
		{
			return _LinetemList;
		}

		public ILineItem GetLineItem(int Id)
		{
			return _LinetemList.FirstOrDefault(e => e.Id == Id);
		}
	}
}
