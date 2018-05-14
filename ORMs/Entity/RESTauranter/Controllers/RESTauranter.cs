using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using System;
using System.Linq;

namespace RESTauranter.Controllers{
    public class RESTauranterController:Controller{
        private Context _context;
        public RESTauranterController(Context context){
            _context = context;
        }
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews(){
            ViewBag.reviews = _context.reviews.OrderByDescending(review => review.created_at);
            return View();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        [Route("reviews")]
        public IActionResult NewReview(Review thisReview){
            if (ModelState.IsValid){
                _context.reviews.Add(thisReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index");
        }
    }
}
