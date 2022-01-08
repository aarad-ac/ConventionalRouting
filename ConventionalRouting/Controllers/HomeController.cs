using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using System.Diagnostics;

namespace ConventionalRouting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
            //throw new NullReferenceException();
            return ControllerContext.MyDisplayRouteInfo(firstName, lastName);
        }

        public IActionResult Route5()
        {
            //throw new NullReferenceException();
            throw new NullReferenceException();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}