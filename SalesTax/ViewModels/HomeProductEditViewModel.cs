using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTax.ViewModels
{
	public class HomeProductEditViewModel : HomeProductAddViewModel
	{
		public int Id { get; set; }
		public string ExistingPhotoPath { get; set; }
	}
}
