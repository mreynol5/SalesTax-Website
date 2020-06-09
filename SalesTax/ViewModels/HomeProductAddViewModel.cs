using Microsoft.AspNetCore.Http;
using SalesTax.Models;
using System.ComponentModel.DataAnnotations;


namespace SalesTax.ViewModels
{
	public class HomeProductAddViewModel
	{
		//public Product Product { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
		public string Name { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
		public string Description { get; set; }
		public int Quantity { get; set; }
		[Required]
		public string UnitPrice { get; set; }
		[Required]		
		public Disc? Discount { get; set; }
		public string PhotoPath { get; set; }
		public IFormFile Photo { get; set; }
	}
}
