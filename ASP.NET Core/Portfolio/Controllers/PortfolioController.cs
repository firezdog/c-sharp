using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
 
namespace Portfolio.Controllers
{
    public class SecondController : Controller
    {
        [HttpGet]
        [Route("demo")]
        public string OtherMethod(string food, int quantity){
            return $"You want {quantity} {food}s";
        }
    }
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult Projects(){
            return View();
        }
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact(){
            return View();
        }
        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(string name, string location, string language, string comment) {
            return RedirectToAction("Comment", new {Name = name, Location = location, Language = language, Comment = comment});
        }
        [HttpGet]
        [Route("comment")]
        public IActionResult Comment(string Name, string Location, string Language, string Comment) {
            ViewBag.name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            return View();
        }
        [HttpGet]
        [Route("demo/{Food}/{Quantity}")]
        public IActionResult Method(string Food, int Quantity) {
            return RedirectToAction("OtherMethod", "Second", new {food = Food, quantity = Quantity});
        }
    }
}