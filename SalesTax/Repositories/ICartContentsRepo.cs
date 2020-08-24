using Microsoft.AspNetCore.Http;
using SalesTax.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace SalesTax.Repositories
{
	public interface ICartContentsRepo
	{
		Product ProductDetails(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient);
		List<Product> GetCartContents(AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient);
		Product Add(Product product, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient);	
		void Update(Product productChanges, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient);
		Product Delete(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient);
		Product SelectProduct(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient);
	}
}