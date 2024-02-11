using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View("CoursesIndex");
        }
        public IActionResult CoursesDetails()
        {
            return View("CoursesDetails");
        }
    }
}
