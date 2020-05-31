using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestSharp.Extensions;
using SalesTax.Models;
using SalesTax.Repositories;
using SalesTax.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SalesTax.Controllers
{
	[Route("[controller]/[action]")]
	public class HomeController : Controller
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="hostEnvironment"></param>
		/// <param name="context"></param>

		private readonly ICartContentsRepo _cartContentsRepo;
		public HomeController(ICartContentsRepo cartContentsRepo, IWebHostEnvironment hostEnvironment, AppDbContext context)
		{
			_context = context;
			_cartContentsRepo = cartContentsRepo;
			_webHostEnvironment = hostEnvironment;
		}

		/// <summary>
		/// Fields
		/// </summary>
		private AppDbContext _context;
		private IWebHostEnvironment _webHostEnvironment;
		private List<Product> _cartContents;
		//private Product _product;


		[Route("")]
		[Route("~/")]
		public ViewResult Index()
		{			
			return View();
		}

		[Route("Privacy")]
		public IActionResult Privacy()
		{
			return View();
		}

		[HttpGet]
		[Route("ProductDetails/{id?}")]
		public ViewResult ProductDetails( int id)
		{
			id = 1001;     //remove hard coded id
			_cartContents = _cartContentsRepo.GetCartContents();
			Product model = _cartContentsRepo.ProductDetails(_cartContents, id);
			HomeProductDetailsViewModel homeProductDetailsViewModel = new HomeProductDetailsViewModel()
			{
				Product = model,
				PageTitle = "Product Details"
			};	
			return View(homeProductDetailsViewModel);
		}


		[Route("CartContents")]
		public ViewResult CartContents()
		{
			//HomeCartContentsViewModel homeCartContentsViewModel = new HomeCartContentsViewModel();
			List<Product> model = _cartContentsRepo.GetCartContents().ToList<Product>();
			_cartContents = model;
			//return View(homeCartContentsViewModel);
			return View(model);
		}

		[HttpPost]
		public ViewResult AddProduct(Product product)
		{
			List<Product> model = _cartContentsRepo.GetCartContents().ToList<Product>();
			HomeProductAddViewModel homeProductAddViewModel = new HomeProductAddViewModel();
			product = _cartContentsRepo.Add(_cartContents, product);
			{
				product.Name = product.Name;
				product.Id = product.Id;
				product.Discount = product.Discount;
			};
			//return RedirectToAction("AddProduct", new { product.Id });
			return View(homeProductAddViewModel);		
		}

		private string ProcessUploadedFile(HomeProductAddViewModel model)
		{
			string uniqueFileName = null;
			if (model.PhotoPath != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;

				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.PhotoPath.CopyTo(fileStream);
				}
			}

			return uniqueFileName;
		}

		[HttpPost]
		public ViewResult RemoveProduct(Product product, int id)
		{
			HomeProductAddViewModel homeProductAddViewModel = new HomeProductAddViewModel();
			product = null;
			if (ModelState.IsValid)
			{
				product = _cartContentsRepo.Delete(_cartContents, product, id);
	
				//return RedirectToAction("AddProduct", new { product.Id });
			}
			return View(homeProductAddViewModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
