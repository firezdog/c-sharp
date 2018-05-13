using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DojoLeague.Models;
using DojoLeague.Factory;

namespace DojoLeague.Controllers
{
    public class DojoLeagueController:Controller{
        private readonly DojoFactory dojoFactory;
        private readonly NinjaFactory ninjaFactory;
        public DojoLeagueController(){
            dojoFactory = new DojoFactory();
            ninjaFactory = new NinjaFactory();
        }
        //RECRUIT or BANISH a NINJA from a DOJO.
        [HttpPost]
        [Route("ninjas/{ninja_id}/dojo/{dojo_id}/recruit/{recruit}")]
        public IActionResult UpdateNinja(int ninja_id, int dojo_id, bool recruit){
            ninjaFactory.BanishRecruit(ninja_id, dojo_id, recruit);
            return RedirectToAction("ViewDojo", new {id=dojo_id});
        }
        //View page for individual dojo
        [HttpGet]
        [Route("dojos/{id}")]
        public IActionResult ViewDojo(int id){
            ViewBag.dojo = dojoFactory.GetOne(id);
            ViewBag.ninjas = ninjaFactory.GetAll();
            return View();
        }
        [HttpPost]
        [Route("dojos/new")]
        public IActionResult NewDojo(Dojo dojo){
            if(ModelState.IsValid){
                dojoFactory.Add(dojo);
                return RedirectToAction("Dojos");
            }
            ViewBag.dojos = dojoFactory.GetAll();
            return View("Dojos");
        }
        [HttpPost]
        [Route("ninjas/new")]
        public IActionResult NewNinja(Ninja ninja){
            ViewBag.ninjas = ninjaFactory.GetAll();
            ViewBag.dojos = dojoFactory.GetAll();
            return View("Ninjas");
        }
        [HttpGet]
        [Route("")]
        public IActionResult Dojos(){
            ViewBag.dojos = dojoFactory.GetAll();
            return View();
        }
        [HttpGet]
        [Route("ninjas")]
        public IActionResult Ninjas(){
            ViewBag.ninjas = ninjaFactory.GetAll();
            ViewBag.dojos = dojoFactory.GetAll();
            return View();
        }
    }
}
