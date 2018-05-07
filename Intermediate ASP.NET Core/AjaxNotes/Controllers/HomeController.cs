using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxNotes.Models;
using DbConnection;

namespace AjaxNotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("note")]
        public IActionResult newNote(string title){
            List<string> errors = new List<string>();
            //Length validation.
            if (title == null) {
                errors.Add("You must enter a title.");
                return Json(new {errors = errors});
            } else if (title.Length < 4) {
                errors.Add("Your title must be at least 4 characters.");
                return Json(new {errors = errors});
            }
            //Uniqueness validation.
            string query = $"SELECT * FROM notes WHERE title='{title}'";
            if (DbConnector.Query(query).Count > 0) {
                errors.Add("Note already exists.");
                return Json(new {errors = errors});
            }
            query = $"INSERT INTO notes (title) VALUES ('{title}')";
            DbConnector.Execute(query);
            return RedirectToAction("getNotes");
        }
        public IActionResult getNotes() {
            string query = "SELECT * FROM notes ORDER BY created_at DESC";
            var result = DbConnector.Query(query);
            var jresult = Json(result);
            return jresult;
        }
        [HttpPost]
        [Route("note/{id}")]
        public IActionResult updateNote(string id, string description){
            string query;
            query = $"UPDATE notes SET description='{description}' WHERE id='{id}'";
            DbConnector.Execute(query);
            return RedirectToAction("getNotes");
        }
        [HttpPost]
        [Route("note/{id}/delete")]
        public IActionResult deleteNote (string id) {
            string query;
            query = $"DELETE FROM notes WHERE id='{id}'";
            DbConnector.Execute(query);
            return RedirectToAction("getNotes");
        }
        public IActionResult Index()
        {
            string query = "SELECT * FROM notes ORDER BY created_at DESC";
            ViewBag.notes = DbConnector.Query(query);
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
