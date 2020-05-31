using Microsoft.AspNetCore.Http;
using SalesTax.Models;
using System.ComponentModel.DataAnnotations;

namespace SalesTax.ViewModels
{
	public class HomeProductAddViewModel
	{
		public Product Product { get; set; }
		public string PageTitle { get; set; }
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public int Quantity { get; set; }
		[Required]
		public float UnitPrice { get; set; }
		public float? Discount { get; set; }
		public IFormFile PhotoPath { get; set; }
	}
}
