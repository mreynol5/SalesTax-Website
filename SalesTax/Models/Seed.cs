using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTax.Models
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var photoPath = "/Images/" ;

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 900,
					Name = "Battery",
					Description = "Toyota Tacoma battery",
					Quantity = 1,
					Discount = "10",
					UnitPrice = "125.78",
					ProductTaxCode = "0",
					PhotoPath = photoPath + "battery.png"
				},
				new Product
				{
					Id = 910,
					Name = "Tire",
					Description = "Goodyear X-300",
					Quantity = 4,
					Discount = "15",
					UnitPrice = "145.99",
					ProductTaxCode = "0",
					PhotoPath = photoPath + "tire.png"
				},
				new Product
				{
					Id = 905,
					Name = "Struts",
					Description = "Dodge Ram Heavy Duty Strut set",
					Quantity = 1,
					Discount = "5",
					UnitPrice = "98.99",
					ProductTaxCode = "0",
					PhotoPath = photoPath + "struts.png"
				},
				new Product
				{
					Id = 934,
					Name = "Air Filter",
					Description = "Silverado Air Filter",
					Quantity = 1,
					Discount = "10",
					UnitPrice = "38.55",
					ProductTaxCode = "0",
					PhotoPath = photoPath + "airFilter.png"
				});
		}
	}
}
