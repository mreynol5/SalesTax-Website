using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesTax.Models;
using SalesTax.Repositories;

namespace SalesTax.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private  ILineItemRepo _lineItemRepo { get; }

		public HomeController(ILogger<HomeController> logger,
			ILineItemRepo lineItemRepo)
		{
			_logger = logger;
			_lineItemRepo = lineItemRepo;
		}

		public ViewResult Index()
		{
			var model = GetItem(1021);
			return View (model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public ViewResult GetItem(int Id)
		{
			ILineItem model = _lineItemRepo.GetLineItem(1021);
			ViewData["LineItem"] = model;
			ViewData["PageTitle"] = "Single Item";
			return View(model);
		}

		public List<ILineItem> GetLineItemsList()
		{
			List <ILineItem> model = _lineItemRepo.GetLineItemsList();
			return model;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
