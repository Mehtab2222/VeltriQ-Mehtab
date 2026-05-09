using Microsoft.AspNetCore.Mvc;

namespace VeltriQ.Controllers
{
    public class LeaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LeaveTypes()
        {
            return View();
        }
    }
}
