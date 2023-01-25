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

			RestClient client = new RestClient("http://localhost:5156/api/Student");
			RestRequest request = new RestRequest("", Method.Get);
			List<Student> response = client.Get<List<Student>>(request);

			return View(response);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateStudentModel model)
		{
			RestClient client = new RestClient("http://localhost:5156/api/Student");
			RestRequest request = new RestRequest("", Method.Post);
			request.AddJsonBody(model);
			RestResponse<Student> student = client.ExecutePost<Student>(request);

			return RedirectToAction(nameof(Index));
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