using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTax.Repositories
{
	public class LineItemRepo : ILineItemRepo
	{
		public List<ILineItem> GetLineItemsList()
		{
			List<ILineItem> lineItemList = new List<ILineItem>();
			return lineItemList;
		}

		public ILineItem GetLineItem(int id)
		{
			List<ILineItem> lineItemList = new List<ILineItem>();
			return lineItemList.FirstOrDefault(e => e.Id == id);
		}
	}
}
