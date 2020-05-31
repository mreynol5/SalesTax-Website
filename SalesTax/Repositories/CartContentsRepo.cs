using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Repositories
{
	public class CartContentsRepo : ICartContentsRepo
	{
		private readonly AppDbContext _context;
		private List<Product> _products;
		public CartContentsRepo(AppDbContext Context)
		{
			_context = Context;
			_products = GetCartContents();
		}

		public Product ProductDetails(List<Product> products, int id)
		{
			Product product = _context.Products.FirstOrDefault<Product>(e => e.Id == id);
			return product;
		}

		public Product Add(List<Product> products, Product product)
		{
			int id = products.Max(e => e.Id) + 1;
			products.Append<Product>(product);
			return product;
		}

		public Product Delete(List<Product> products, Product product, int id)
		{
			Product deletedProduct = _context.Products.FirstOrDefault(e => e.Id == id);
			if (deletedProduct != null)
			{
				products.Remove(deletedProduct);
			}
			return deletedProduct;
		}

		public void Update(ICartContentsRepo repo, List<Product> products,  Product productChanges)
		{
		
			Product product = products.FirstOrDefault(e => e.Id == productChanges. Id);
			if (product != null)
			{
				product.Name = product.Name;
				product.Description = product.Description;
				product.Discount = product.Discount;
			}
			return ;
		}

		public List<Product> GetCartContents()
		{
			List<Product> cartContents = _context.Products.ToList();
			_products = cartContents;
			return _products;
		}
	}
}
