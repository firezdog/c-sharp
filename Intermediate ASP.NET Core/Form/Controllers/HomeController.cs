using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Form.Models;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("submit")]
        public IActionResult Submit(User user)
        {
            int? age = user.Age;
            if (age == null) {
                user.Age = 0;
            }
            TryValidateModel(user);
            foreach (var issue in ModelState.Values) {
                if(issue.Errors.Count > 0) {
                    return Json(ModelState.Values);
                }
            }
            return RedirectToAction("Login", user);
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login(User user) {
            ViewBag.user = user;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
