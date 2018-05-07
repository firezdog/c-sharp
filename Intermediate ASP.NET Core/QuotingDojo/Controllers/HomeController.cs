using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult NewComment(string name, string comment)
        {
            string query = $"INSERT INTO messages (creator, text) VALUES ('{name}', '{comment}') ";
            try {
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            catch {
                //I don't understand what is being asked -- how do you return a view without re-rendering the page and losing the form data?
                ViewBag.message = "There was an error in your submission.";
                return View("Form");
            }
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Index()
        {
            var result = DbConnector.Query("SELECT * FROM messages ORDER BY  created_at DESC");
            ViewBag.result = result;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
