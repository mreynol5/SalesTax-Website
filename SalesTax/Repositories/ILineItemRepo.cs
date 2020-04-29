using SalesTax.Models;
using System.Collections.Generic;

namespace SalesTax.Repositories
{
	public interface ILineItemRepo
	{
		ILineItem GetLineItem(int id);
		List<ILineItem> GetLineItemsList( );
	}
}