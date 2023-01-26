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

		[HttpGet]
		public IActionResult Edit(int id)
		{

			RestClient client = new RestClient("http://localhost:5156/api/Student");
			RestRequest request = new RestRequest($"/update/{id}", Method.Get);
			RestResponse<Student> student = client.ExecuteGet<Student>(request);

			return View(student);
		}

		public IActionResult Edit(int id, UpdateStudentModel model)
		{

			RestClient client = new RestClient("http://localhost:5156/api/Student");
			RestRequest request = new RestRequest($"/update/{id}", Method.Put);
			request.AddJsonBody(model);
			RestResponse<Student> response = client.ExecutePost<Student>(request);

			if(response.IsSuccessful)
			{
				return RedirectToAction(nameof(Index));
			}
			else
			{
				ModelState.AddModelError("", "Student is Not Found.");
				return View(model);
			}
		}

		public IActionResult Delete(int id)
		{

			RestClient client = new RestClient("http://localhost:5156/api/Student");
			RestRequest request = new RestRequest($"/delete/{id}", Method.Delete);
			RestResponse response = client.Delete(request);

			if (response.IsSuccessful)
			{
				TempData["success"] = "Student is Deleted.";
			}
			else
			{
				TempData["success"] = "Student is not Deleted.";
			}
			
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