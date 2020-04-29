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

		public JsonResult Index()
		{
			var model = GetLineItemsList();
			return Json(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public JsonResult GetItem(int id)
		{
			ILineItem model = _lineItemRepo.GetLineItem(1021); 
			return Json(model);
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
