using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieAPI.Models;
using Microsoft.Extensions.Options;

namespace movieAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        private readonly IOptions<MyApiOptions> MyApiConfig;
        public HomeController(DbConnector connect, IOptions<MyApiOptions> apiConfig)
        {
            _dbConnector = connect;
            MyApiConfig = apiConfig;
        }
        public IActionResult Index()
        {
            string temp = MyApiConfig.Value.Key;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
