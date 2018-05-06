using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
 
namespace Tomaguchi.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }    
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class Pet 
    {
        public int happiness;
        public int fullness;
        public int energy;
        public int meals;
        public string action;
        static Random ayn = new Random();
        public Pet(){
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
            action = "Your Tomaguchi is ready to play.";
        }
        public void feed(){
            if(meals>0){
                meals--;
                int chance = ayn.Next(1,100);
                if (chance < 26) {
                    action = "You tried to feed your Tomaguchi, but it didn't like it.";
                } else {
                    int gain = ayn.Next(5,10);
                    fullness += gain;
                    action = $"You fed your Tomaguchi, and it gained {gain} fullness.";
                }
            } else {
                action = "Your Tomaguchi will have to WORK for its supper.";
            }
        }
        public void play(){
            if(energy > 4){
                energy -= 5;
                int chance = ayn.Next(1,100);
                if (chance < 26) {
                    action = "You tried to play with your Tomaguchi, but it didn't like it.";
                } else {
                    int gain = ayn.Next(5,10);
                    happiness += gain;
                    action = $"You played with your Tomaguchi, and it gained {gain} happiness.";
                }
            } else {
                action = "Your Tomaguchi is too tired to play.";
            }
        }
        public void work() {
            if (energy > 4) {
                energy -= 5;
                int gain = ayn.Next(1,3);
                meals += gain;
                action = $"Your Tomaguchi went to work and earned {gain} meals.";
            } else {
                action = "Your Tomaguchi is too tired to work :(";
            }
        }
        public void sleep() {
            if (happiness > 4 && fullness > 4){
                fullness -= 5;
                happiness -= 5;
                energy += 15;
                action = "Your Tomaguchi took a nap and gained 15 energy.";
            } else {
                action = "Your Tomaguchi is too hungry or unhappy to sleep.";
            }
        }
        public void reset() {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
            action = "Your Tomaguchi is ready to play.";
        }
    }
    public class TomaguchiController : Controller
    {
	[HttpGet]
	[Route("")]
        public IActionResult Index()
        {
            Pet pet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            if (pet == null) {
                pet = new Pet();
                HttpContext.Session.SetObjectAsJson("pet",pet);
            }
            ViewBag.pet = pet;
            return View();
        }
    [HttpGet]
    [Route("action/{deed}")]
        public JsonResult Action(string deed) {
            Pet pet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            Dictionary<string, System.Action> actions = new Dictionary<string, System.Action> {
                {"Feed", pet.feed},
                {"Play", pet.play},
                {"Work", pet.work},
                {"Sleep", pet.sleep}
            };
            actions[deed]();
            HttpContext.Session.SetObjectAsJson("pet",pet);
            return Json(pet);
        }
    [HttpGet]
    [Route("reset")]
        public JsonResult Reset() {
            Pet pet = HttpContext.Session.GetObjectFromJson<Pet>("pet");
            pet.reset();
            HttpContext.Session.SetObjectAsJson("pet",pet);
            return Json(pet);
        }
    }
}