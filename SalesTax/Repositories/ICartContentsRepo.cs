using SalesTax.Models;
using System.Collections.Generic;

namespace SalesTax.Repositories
{
	public interface ICartContentsRepo
	{
		Product ProductDetails(List<Product> products, int id);
		List<Product> GetCartContents();
		Product Add(List<Product> products, Product product);
		void Update(ICartContentsRepo repo, List<Product> products, Product productChanges);
		Product Delete(List<Product> products, Product product, int id);
	}
}