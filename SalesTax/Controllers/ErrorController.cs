﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace SalesTax.Controllers
{
	public class ErrorController : Controller
	{
		[Route("")]
		[Route("Error/{statusCode}")]
		public IActionResult HttpStatusCodeHandler(int statusCode)
		{
			var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
			switch (statusCode)
			{
				case 404:
					ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
					ViewBag.Path = statusCodeResult.OriginalPath;
					ViewBag.Query = statusCodeResult.OriginalQueryString;

					break;
			}
			return View ("NotFound");
		}


		[Route("Error")]
		[AllowAnonymous]
		public IActionResult Error()
		{
			var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			ViewBag.ExceptionPath = exceptionDetails.Path;
			ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
			ViewBag.StackTrace = exceptionDetails.Error.StackTrace;

			return View("Error");
		}

	}
}
