using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.FileProviders;
using System.Net.Http;

namespace SalesTax.Repositories
{
	public class CartContentsRepo : ICartContentsRepo
	{
		private readonly AppDbContext dbContext;
		private readonly HttpClient httpClient;
		private List<Product> products;
		private HttpContext httpContext { get; }

		public CartContentsRepo(AppDbContext dbContext, HttpContext httpContext,
			HttpClient httpClient)
		{
			this.dbContext = dbContext;
			this.httpClient = httpClient;
			products = GetCartContents(dbContext, httpContext, httpClient);
			this.httpContext = httpContext;
		}

		public Product SelectProduct(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product product = dbContext.Products. FirstOrDefault<Product>(e => e.Id == id);
			return product;
		}

		public Product ProductDetails(int id, AppDbContext dbContext, HttpContext httpContext,
			HttpClient httpClient)
		{
			Product product = dbContext.Products.FirstOrDefault<Product>(e => e.Id == id);

			if(product == null)
			{
				var response =  httpContext.Response.StatusCode = 404;
				return null ;
			}
			return product;
		}

		public Product Add(Product product, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			product.Id = products.Max(e => e.Id) + 1;
			products.Add(product);
			return product;
		}

		public Product Delete(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product deletedProduct = dbContext.Products.FirstOrDefault(e => e.Id == id);
			if (deletedProduct != null)
			{
				products.Remove(deletedProduct);
			}
			return deletedProduct;
		}

		public void Update(Product productChanges, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
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

		public List<Product> GetCartContents(AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			List<Product> cartContents = dbContext.Products.ToList();
			products = cartContents;
			return products;
		}
	}
}
