using Microsoft.AspNetCore.Mvc;

namespace VeltriQ.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}