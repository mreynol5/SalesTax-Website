using Microsoft.EntityFrameworkCore;
using SalesTax.Models;
using System.Collections.Generic;

namespace SalesTax.Repositories
{
	public class SQLLineItemRepo : ILineItemRepo
	{
		public AppDBContext Context { get; }

		public SQLLineItemRepo(AppDBContext context)
		{			
			this.Context = context;
		}

		public ILineItem GetLineItem(int id)
		{
			return Context.lineItems.Find(id);
		}

		public IEnumerable<ILineItem> GetLineItemsList()
		{
			return Context.lineItems;
		}

		public ILineItem Add(ILineItem product)
		{
			Context.Add(product);
			Context.SaveChanges();
			return product;
		}

		public ILineItem Update(ILineItem productChanges)
		{
			var product = Context.lineItems.Attach(productChanges);
			product.State = EntityState.Modified;			
			Context.SaveChanges();
			return productChanges;
		}

		public ILineItem Delete(int Id)
		{
			ILineItem lineItem = Context.lineItems.Find(Id);
			if (lineItem != null)
			{
				Context.lineItems.Remove(lineItem);
				Context.SaveChanges();
			}
			return lineItem;
		}
	}
}
