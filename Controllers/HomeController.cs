using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace VueDotNetNewTemplate.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Error() {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}