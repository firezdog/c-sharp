using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
 
namespace Portfolio.Controllers
{
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
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("Comment");
        }
    }
}