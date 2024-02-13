using Microsoft.AspNetCore.Mvc;

namespace DicleAcademy.Controllers
{
    public class TeamsController : Controller
    {
        public IActionResult Index()
        {
            return View("TeamsIndex");
        }
    }
}
