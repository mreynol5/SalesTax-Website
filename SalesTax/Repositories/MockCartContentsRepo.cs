using Microsoft.AspNetCore.Http;
using System.Net.Http;
using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTax.Repositories
{
	public class MockCartContentsRepo : ICartContentsRepo
	{
		public Product product { get;  set; }

		private List<Product> cartContentsList;
		public List<Product> productList { get => cartContentsList; set => cartContentsList = value; }

		public MockCartContentsRepo()
		{
			cartContentsList = new List<Product>()
			{
				new Product () { Name = "Tire",  Description = "All weather", Id = 1001,  Quantity = 4,  UnitPrice = "125.95", ProductTaxCode = "0", Discount = "5", PhotoPath = "tire.png"  },
				new Product () {  Name = "Struts",  Description = "Truck struts",  Id = 1015,   Quantity = 2, UnitPrice = "145.95", ProductTaxCode = "0", Discount = "15", PhotoPath = "struts.png"  },
				new Product() {  Name = "airFilter,png",  Description = "F 150",  Id = 1021,  Quantity = 6, UnitPrice = "32.78", ProductTaxCode = "0", Discount = "25",PhotoPath = "tires.png"  },
				new Product() {  Name = "Wipers",  Description = "Winter",  Id = 1038,  Quantity = 1,  UnitPrice = "9.95", ProductTaxCode = "0", Discount = "5",  PhotoPath =  "wipers.jpg"  },
				new Product () {  Name = "Seat Covers",  Description = "Cloth",  Id = 1047, Quantity = 4,  UnitPrice = "52.95", ProductTaxCode = "0", Discount = "10", PhotoPath =  "seatCover.png"  }
			 };
		}

		public Product SelectProduct(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product product = cartContentsList.FirstOrDefault<Product>(e => e.Id == id);
			return product;
		}

		public List<Product> GetCartContents(AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			return cartContentsList;
		}										

		public Product ProductDetails(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product product = cartContentsList.FirstOrDefault<Product> (e => e.Id == id);
			return product;
		}

		public Product Add( Product product, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			product.Id = cartContentsList.Max(e => e.Id) + 1;
			cartContentsList.Add(product);
			return product;
		}

		public Product Delete(int id, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product item = cartContentsList.FirstOrDefault(e => e.Id == id);
			if (item != null)
			{
				cartContentsList.Remove(item);
			}
			return item;
		}

		public void Update(Product productChanges, AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			int id = 1015;	  //remove this after testing
			product = cartContentsList.FirstOrDefault(e => e.Id == id);
			if (product != null)
			{
				product.Name = product.Name;
				product.Description = product.Description;
				product.Discount = product.Discount ;
			}
			return ;
		}
	}
}
