using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Routing.Controllers
{
    public class MyRouteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo(); ;
        }
    }
}
