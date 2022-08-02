using Microsoft.AspNetCore.Mvc;

namespace AdminDashboardForTask.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
