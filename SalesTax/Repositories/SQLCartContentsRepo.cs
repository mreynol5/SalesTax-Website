using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SalesTax.Repositories
{
	public class SQLCartContentsRepo : ICartContentsRepo
	{
		public ICartContentsRepo Repo { get; }
		private readonly AppDbContext dbContext;
		private List<Product>products;

		public SQLCartContentsRepo(AppDbContext dbContext, 
			HttpContext httpContext, HttpClient httpClient)
		{			
			this.dbContext = dbContext;
			List<Product> products = GetCartContents(dbContext,	httpContext,  httpClient);
			this.products = products;
		}

		public Product SelectProduct(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product product = dbContext.Products.FirstOrDefault<Product>(e => e.Id == id);
			return product;
		}

		public Product Add(Product product, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			dbContext.Products.Add(product);
			dbContext.SaveChanges();
			return product;
		}

		public Product Delete( int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product product = dbContext.Products.Find(id, dbContext,
				httpContext, httpClient);
			if (product != null)
			{
				dbContext.Products.Remove(product);
				dbContext.SaveChanges();
			}
			return product;
		}
		public Product ProductDetails( int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			return dbContext.Products.Find(id);
		}

		public List<Product> GetCartContents(AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			return dbContext.Products.ToList<Product>();
		}

		public void Update(Product productChanges, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			//todo gather input from user about new product
			var product = dbContext.Products.Attach(productChanges);
			product.State = EntityState.Modified;
			dbContext.SaveChanges();
			return ;
		}
	}
}
