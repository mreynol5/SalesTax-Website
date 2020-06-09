using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RestSharp.Extensions;
using SalesTax.Models;
using SalesTax.Repositories;
using SalesTax.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace SalesTax.Controllers
{
	[Route("[controller]/[action]")]
	public class HomeController : Controller
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="hostEnvironment"></param>
		/// <param name="DbContext"></param>

		private readonly ICartContentsRepo cartContentsRepo;
		private readonly IWebHostEnvironment hostingEnvironment;
		private readonly HttpContext httpContext;
		private readonly HttpClient httpClient;
		private readonly AppDbContext dbContext;
		private List<Product> cartContents;

		public HomeController(ICartContentsRepo cartContentsRepo, 
			IWebHostEnvironment hostingEnvironment, 
			AppDbContext dbContext,
			HttpContext httpContext, 
			HttpClient httpClient)
		{
			this.cartContentsRepo = cartContentsRepo;
			this.hostingEnvironment = hostingEnvironment;
			this.dbContext = dbContext;
			this.httpContext = httpContext;
			this.httpClient = httpClient;
			cartContents =  cartContentsRepo.GetCartContents(dbContext,
			 httpContext, httpClient);
		}

		/// <summary>
		/// Fields
		/// </summary>

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
		public ViewResult ProductDetails(int? id,  AppDbContext dbContext, 
			HttpContext httpContext, HttpClient httpClient)
		{			
			Product model = cartContentsRepo.ProductDetails(id.Value,  dbContext,
						httpContext, httpClient);
			if(model == null)
			{
				Response.StatusCode = 404;
				return View("That product is not in your cart", id.Value);
			}
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
			List<Product> model = cartContents;
			return View(model);
		}

		[HttpGet]
		public ViewResult ProductEdit(int id)
		{
			Product product = cartContentsRepo.ProductDetails(id,
				dbContext, httpContext, httpClient);

			if(product == null)
			{
				Response.StatusCode = 404;
				return View("Product was not found", id);
			}
			HomeProductEditViewModel homeProductEditViewModel = new HomeProductEditViewModel()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Quantity = product.Quantity,
				UnitPrice = product.UnitPrice,
				Photo = product.Photo,
				PhotoPath = product.PhotoPath,
				ExistingPhotoPath = product.PhotoPath
			};
			return View(homeProductEditViewModel);
			//return RedirectToAction("ProductDetails", id);
		}

		[HttpPost]
		public IActionResult ProductEdit(HomeProductEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				Product product = cartContentsRepo.ProductDetails(model.Id, dbContext,
								httpContext,  httpClient);
				product.Name = model.Name;
				product.Description = model.Description;
				product.Discount = model.Discount.ToString();
				product.Quantity = model.Quantity;
				product.UnitPrice = model.UnitPrice;
				product.PhotoPath = model.PhotoPath;
				if (product.Photo != null)
				{
					if(product.ExistingPhotoPath != null)
					{
						string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images",
							product.ExistingPhotoPath);
						System.IO.File.Delete(filePath);
					}
					product.PhotoPath = ProcessUploadedFile(model);
				}

				cartContentsRepo.Update(product, dbContext,
							httpContext,  httpClient);
				return RedirectToAction("ProductDetails", new { id = product.Id });
			}
			return View();
		}

		[HttpGet]
		public ViewResult ProductAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ProductAdd(HomeProductAddViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = null;
				if (model.Photo != null)
				{
					string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
					uniqueFileName =  Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
					string filePath = Path.Combine(uploadsFolder, uniqueFileName);
					model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
				}
				Product newProduct = new Product
				{
					Name = model.Name,
					Description = model.Description,
					Quantity = model.Quantity,
					Discount = model.Discount.ToString(),
					PhotoPath = uniqueFileName
				};

				cartContentsRepo.Add(newProduct, dbContext, httpContext, httpClient);
				return RedirectToAction("ProductDetails", new { id = newProduct.Id });
			}
			return View();
		}

		private string ProcessUploadedFile(HomeProductAddViewModel model)
		{
			string uniqueFileName = null;
			if (model.Photo != null)
			{
				string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.Photo.CopyTo(fileStream);
				}
			}
			return uniqueFileName;
		}

		public RedirectToActionResult ProductRemove(int id,  AppDbContext dbContext,
			HttpContext httpContext, HttpClient httpClient)
		{
			Product product = cartContentsRepo.Delete(id, dbContext, httpContext, httpClient);
			return RedirectToAction("CartContents");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
