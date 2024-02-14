using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View("CategoryIndex");
        }
        public IActionResult CategoryDetails()
        {
            return View("CategoryDetailsIndex");
        }
    }
}
