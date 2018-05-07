using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbConnection;

namespace Database.Controllers
{
    public class DatabaseController : Controller
    {
	[HttpGet]
	[Route("")]
        public IActionResult Index()
        {
            string queryString = "SELECT * FROM cars";
            var result = DbConnector.Query(queryString);
            ViewBag.result = result;
            return View();
        }
    [HttpPost]
    [Route("/addCar")]
        public IActionResult AddCar (string make, string model) {
            string queryString = $"INSERT INTO cars (make,model) VALUES ('{make}','{model}')";
            DbConnector.Execute(queryString);
            return RedirectToAction("Index");
        }
    }
}