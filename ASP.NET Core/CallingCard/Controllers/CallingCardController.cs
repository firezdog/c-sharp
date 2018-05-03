using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard.Controllers
{
    public class CallingCardController : Controller
    {
        [HttpGet]
        [Route("{first}/{last}/{age}/{color}")]
        public JsonResult Index(string first, string last, string age, string color)
        {
            var obj = new {
                first = first,
                last = last,
                age = age,
                color = color
            };
            return Json(obj);
        }
    }
}