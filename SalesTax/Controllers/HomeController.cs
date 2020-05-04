using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		public HomeController(ILogger<HomeController> logger,
		ILineItemRepo lineItemRepo)
		{
			_logger = logger;
			_lineItemRepo = lineItemRepo;
		}

		private readonly ILogger<HomeController> _logger;

		private  ILineItemRepo _lineItemRepo { get; }

	
		[Route("")]
		[Route("~/")]
		public ViewResult Index()
		{
			HomeLineItemListViewModel homeLineItemListViewModel = new HomeLineItemListViewModel();
			//var model = _lineItemRepo.GetLineItem(1021);
			var model = _lineItemRepo.GetLineItemsList();
			return View("GetLineItemsList", model  );
		}

		[Route("Privacy")]
		public IActionResult Privacy()
		{
			return View();
		}


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
			List<ILineItem> model = _lineItemRepo.GetLineItemsList();
			return View (model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
