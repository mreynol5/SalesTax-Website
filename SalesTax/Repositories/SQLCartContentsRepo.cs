using Microsoft.EntityFrameworkCore;
using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Repositories
{
	public class SQLCartContentsRepo : ICartContentsRepo
	{
		public ICartContentsRepo Repo { get; }
		private readonly AppDbContext _context;

		public SQLCartContentsRepo(AppDbContext context)
		{			
			_context = context;
		}

		public Product Add(List<Product> products, Product product)
		{
			products.Add(product);
			_context.SaveChanges();
			return product;
		}

		public Product Delete(List<Product> products,  Product product, int id)
		{
			product = products.Find(e=> e.Id == id);
			if (product != null)
			{
				_context.Products.Remove(product);
				_context.SaveChanges();
			}
			return product;
		}
		public Product ProductDetails(List<Product> products, int id)
		{
			return products.Find(e=> e.Id == id);
		}

		public List<Product> GetCartContents()
		{
			return _context.Products.ToList<Product>();
		}

		public void Update(ICartContentsRepo repo, List<Product> products, Product productChanges)
		{
			//todo gather input from user about new product
			var product = _context.Products.Attach(productChanges);
			product.State = EntityState.Modified;
			_context.SaveChanges();
			return ;
		}
	}
}
