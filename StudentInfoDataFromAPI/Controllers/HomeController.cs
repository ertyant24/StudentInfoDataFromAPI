using Microsoft.AspNetCore.Mvc;
using RestSharp;
using StudentInfoDataFromAPI.Models;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;

namespace StudentInfoDataFromAPI.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{

			RestClient client = new RestClient("http://localhost:5156/api");
			RestRequest request = new RestRequest("/Student", Method.Get);
			List<Student> response = client.Get<List<Student>>(request);

			return View(response);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}