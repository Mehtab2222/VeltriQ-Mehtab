using Microsoft.AspNetCore.Mvc;

namespace VeltriQ.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}