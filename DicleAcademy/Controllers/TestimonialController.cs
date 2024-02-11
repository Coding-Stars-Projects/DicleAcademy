using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class TestimonialController : Controller
    {
        public IActionResult Index()
        {
            return View("TestimonialIndex");
        }
    }
}
