using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RandomPass.Controllers
{
    public class RandomPassController : Controller
    {
 	[HttpGet]
	[Route("")]
        public IActionResult Index()
        {   
            try {
                int? visited = HttpContext.Session.GetInt32("visited");
                visited++;
                HttpContext.Session.SetInt32("visited",(int)visited);
            } catch {
                int visited = 1;
                HttpContext.Session.SetInt32("visited",visited);
            }
            Random ayn = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string random = "";
            for (int i = 0; i <= 14; i++) {
                random += alphabet[ayn.Next(0,alphabet.Length)];
            }
            HttpContext.Session.SetString("random",random);
            TempData["random"] = HttpContext.Session.GetString("random");
            TempData["visited"] = HttpContext.Session.GetInt32("visited");
            return View();
        }
    [HttpGet]
    [Route("ajax")]
        public JsonResult Ajax()
        {
            int? visited = HttpContext.Session.GetInt32("visited");
            visited++;
            HttpContext.Session.SetInt32("visited",(int)visited);
            Random ayn = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string random = "";
            for (int i = 0; i <= 14; i++) {
                random += alphabet[ayn.Next(0,alphabet.Length)];
            }
            return Json(new {random = random, visited = visited});
        }
    }
}