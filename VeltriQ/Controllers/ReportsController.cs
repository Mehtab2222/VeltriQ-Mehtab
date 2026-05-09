using Microsoft.AspNetCore.Mvc;

namespace VeltriQ.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
