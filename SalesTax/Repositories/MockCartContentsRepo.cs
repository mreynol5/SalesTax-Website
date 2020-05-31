using SalesTax.Models;
using System.Collections.Generic;
using System.Linq;

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
				new Product () { Name = "Tire",  Description = "All weather", Id = 1001,  Quantity = 4,  UnitPrice = 125.95F, ProductTaxCode = "0", PhotoPath = "/images/tire.png"  },
				new Product () {  Name = "Struts",  Description = "Truck struts",  Id = 1015,   Quantity = 2, UnitPrice = 145.95F, ProductTaxCode = "0", PhotoPath = "/images/struts.png"  },
				new Product() {  Name = "Radiator",  Description = "F 150",  Id = 1021,  Quantity = 6, UnitPrice = 209.95F, ProductTaxCode = "0", PhotoPath = "/images/tires.png"  },
				new Product() {  Name = "Wipers",  Description = "Winter",  Id = 1038,  Quantity = 1,  UnitPrice = 09.95F, ProductTaxCode = "0", PhotoPath = "/images/tires.png"  },
				new Product () {  Name = "Seat Covers",  Description = "Cloth",  Id = 1047, Quantity = 4,  UnitPrice = 52.95F, ProductTaxCode = "0", PhotoPath = "/images/tires.png"  }
			 };
		}

		public List<Product> GetCartContents()
		{
			return cartContentsList;
		}

		public Product ProductDetails(List<Product> products, int id)
		{
			Product product = cartContentsList.FirstOrDefault<Product> (e => e.Id == id);
			return product;
		}

		public Product Add(List<Product> products, Product product)
		{
			product.Id = cartContentsList.Max(e => e.Id) + 1;
			cartContentsList.Append<Product>(product);
			return product;
		}

		public Product Delete( List<Product> products, Product product, int id)
		{
			Product item = cartContentsList.FirstOrDefault(e => e.Id == id);
			if (item != null)
			{
				cartContentsList.Remove(item);
			}
			return item;
		}

		public void Update(ICartContentsRepo repo, List<Product> products, Product productChanges)
		{
			product = cartContentsList.FirstOrDefault(e => e.Id == product.Id);
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
