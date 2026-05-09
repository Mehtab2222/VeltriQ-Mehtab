using Microsoft.AspNetCore.Mvc;

namespace VeltriQ.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
