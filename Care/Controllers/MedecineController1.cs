using Microsoft.AspNetCore.Mvc;

namespace Care.Controllers
{
    public class MedecineController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
