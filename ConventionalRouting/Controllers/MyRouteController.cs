using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace ConventionalRouting.Controllers
{
    public class MyRouteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
}
