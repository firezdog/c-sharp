using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LostInWoods.Models;
using LostInWoods.Factory;
using System;

namespace LostInWoods.Controllers{
    public class LostInWoodsController:Controller{
        private readonly TrailFactory trailFactory;
        public LostInWoodsController()
        {
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("trail/{id}")]
        public IActionResult ShowTrail(int id){
            ViewBag.trail = trailFactory.FindOne(id);
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateTrail(TrailViewModel newTrail){
            if(ModelState.IsValid){
                Trail trail = new Trail {
                    trail_name = newTrail.trail_name,
                    trail_description = newTrail.trail_description,
                    trail_length = (double) newTrail.trail_length,
                    elevation_change = (int) newTrail.elevation_change,
                    latitude = (double) newTrail.latitude,
                    longitude = (double) newTrail.longitude
                };
                trailFactory.Add(trail);
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }
        [HttpGet]
        [Route("new")]
        public IActionResult NewTrail(){
            return View();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.trails = trailFactory.FindAll();
            return View("Index");
        }
    }
}
