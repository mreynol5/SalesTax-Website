using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesTax.Models;
using SalesTax.Repositories;
using SalesTax.ViewModels;

namespace SalesTax.Controllers
{
	[Route("[controller]/[action]")]
	public class HomeController : Controller
	{
		private readonly IWebHostEnvironment hostingEnvironment;
		private readonly ILineItemRepo _lineItemRepo;

		public HomeController(ILineItemRepo lineItemRepo, IWebHostEnvironment hostingEnvironment)
		{
			_lineItemRepo = lineItemRepo;
			this.hostingEnvironment = hostingEnvironment;
		}
	
		[Route("")]
		[Route("~/")]
		public ViewResult Index()
		{		
			var model = _lineItemRepo.GetLineItemsList();
			return View(model  );
		}

		[Route("Privacy")]
		public IActionResult Privacy()
		{
			return View();
		}

		[HttpGet]
		[Route("GetItem/{id?}")]
		public ViewResult GetItem(int? Id)
		{
			int id = 1024;
			HomeLineItemViewModel homeLineItemViewModel = new HomeLineItemViewModel()
			{
				Item = _lineItemRepo.GetLineItem(id),
				PageTitle = "Single Item Details"
			};
			return View(homeLineItemViewModel);
		}

		[Route("GetAll")]
		public ViewResult GetLineItemsList()
		{
			HomeLineItemListViewModel homeLineItemListViewModel = new HomeLineItemListViewModel();
			IEnumerable<ILineItem> model = _lineItemRepo.GetLineItemsList();
			return View (model);
		}

		[HttpPost]
		  public IActionResult AddProduct(HomeProductAddViewModel model)
		{			
			if(ModelState.IsValid)
			{
				string uniqueFileName = ProcessUploadedFile(model);
				ILineItem newProduct = new LineItem
				{
					Name = model.Name,
					Id = model.Id
				};
				ILineItem newItem = _lineItemRepo.Add(newProduct);
				return RedirectToAction("GetLineItem", new { Id = newItem.Id });
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
				// As soon as this block completes, the file stream is properly disposed of
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.Photo.CopyTo(fileStream);
				}
			}

			return uniqueFileName;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
