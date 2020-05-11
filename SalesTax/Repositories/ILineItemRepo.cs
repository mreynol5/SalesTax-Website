using SalesTax.Models;
using System.Collections.Generic;

namespace SalesTax.Repositories
{
	public interface ILineItemRepo
	{
		ILineItem GetLineItem(int id);
		IEnumerable<ILineItem> GetLineItemsList( );
		ILineItem Add(ILineItem product);
		ILineItem Update(ILineItem productChanges);
		ILineItem Delete(int Id);
	}
}