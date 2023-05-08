using Microsoft.AspNetCore.Mvc;

namespace Ostral.WEB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
