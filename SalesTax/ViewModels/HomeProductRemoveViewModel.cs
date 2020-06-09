using Microsoft.AspNetCore.Http;
using SalesTax.Models;
using System.ComponentModel.DataAnnotations;

namespace SalesTax.ViewModels
{
	public class HomeProductRemoveViewModel
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
		public string Name { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
		public string Description { get; set; }
		public int Quantity { get; set; }
		[Required]
		public float UnitPrice { get; set; }
		public string Discount { get; set; }
		public IFormFile PhotoPath { get; set; }
	}
}