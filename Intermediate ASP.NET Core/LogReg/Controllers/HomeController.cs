using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LogReg.Models;

namespace LogReg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect){
            _dbConnector = connect;
        }
        public IActionResult Landing() {
            return View();
        }
        public IActionResult Register(User user) {
            if (ModelState.IsValid)
            {
                var result = _dbConnector.Query($"SELECT * FROM users WHERE email='{user.Email}'");
                //Check to see if user already exists (ideally this should be a separate method, since it also is used below).
                if (result.Count == 0) {
                    _dbConnector.Execute($"INSERT INTO users (first, last, email, password) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}')");
                    HttpContext.Session.SetString("user",user.Email);
                    return RedirectToAction("Landing");
                } else {
                    ViewBag.duplicate = true;
                }
            }
            return View("Index");
        }
        public IActionResult Login(User user) {
            var result = _dbConnector.Query($"SELECT * FROM users WHERE email='{user.Email}' AND password='{user.Password}'");
            if (result.Count > 0) {
                HttpContext.Session.SetString("user",user.Email);
                return RedirectToAction("Landing");
            }
            TempData["loginFailure"] = true;
            return RedirectToAction("Index");
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
