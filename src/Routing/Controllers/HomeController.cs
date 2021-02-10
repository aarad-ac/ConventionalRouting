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
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Route1()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        //Home/Rout2?value={}
        public IActionResult Route2(string firstName)
        {
            return ControllerContext.MyDisplayRouteInfo(firstName);
        }

        public IActionResult Route2int(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }

        //Home/Route3?firstName={}&lastName={}
        public IActionResult Route3(string firstName, string lastName)
        {
            return ControllerContext.MyDisplayRouteInfo(firstName, lastName);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
