using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.WebApp.Filters;

namespace Samples.WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        //[ServiceFilterAttribute(typeof(TestActionFilterAttribute))]//需要先注入
        [TypeFilterAttribute(typeof(TestActionFilterAttribute))]//不需要注入
        [Route("Home/Index")]
        public IActionResult GetInfo()
        {
            logger.LogInformation("GetInfo");
            return Json(new { Info = "test" });
        }
    }
}