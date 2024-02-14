using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View("ContactIndex");
        }
    }
}
