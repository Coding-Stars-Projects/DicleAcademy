using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class SkillsController : Controller
    {
        public IActionResult Index()
        {
            return View("SkillsIndex");
        }
    }
}
