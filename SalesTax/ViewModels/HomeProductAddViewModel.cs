using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SalesTax.ViewModels
{
	public class HomeProductAddViewModel
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public float UnitPrice { get; set; }
		public float? Discount { get; set; }
		public IFormFile Photo { get; set; }
	}
}
