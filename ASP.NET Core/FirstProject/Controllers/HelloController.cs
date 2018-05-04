using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers {
    public class HelloController: Controller
    {
        [HttpGet]
        [Route("firstView")]
        public IActionResult FirstView() {
            return View();
        }
        [HttpGet]
        [Route("")]
        public JsonResult Example() {
            var anonObject = new {
                firstName = "Alex",
                lastName = "Leibowitz",
                Age = 34,
                state = "apologizes to Tom"
            };
            return Json(anonObject);
        }
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "You've reached the Hello Controller!";
        }
        [HttpGet]
        [Route("template/{name}")]
        public string IActionResult(string Name) {
            return $"Hello {Name}!";
        }
        [HttpPost]
        [Route("index")]
        public void IActionResult2() {
            //Return a view
        }
    }
}