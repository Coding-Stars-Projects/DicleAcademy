using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class AbouteController : Controller
    {
        public IActionResult Index()
        {
            return View("AbouteIndex");
        }
    }
}
