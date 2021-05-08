using Microsoft.AspNetCore.Mvc;

namespace MoneyWatcher.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}