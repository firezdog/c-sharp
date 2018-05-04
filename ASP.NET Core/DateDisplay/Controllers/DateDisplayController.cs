using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DateDisplay.Controllers
{
    public class DateDisplayController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}