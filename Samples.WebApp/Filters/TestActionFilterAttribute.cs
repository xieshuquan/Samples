using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samples.WebApp.Filters
{
    public class TestActionFilterAttribute : IActionFilter
    {
        public IConfiguration Configuration { get; private set; }

        public TestActionFilterAttribute(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!Configuration.GetValue<bool>("Config:AllowAccess"))
            {
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(new { Message = "无权访问" }),
                    ContentType = "application/json",
                    StatusCode = 200,
                };
            }
        }
    }
}
