using Microsoft.AspNetCore.Mvc;

namespace KatsCoffeMachine.Controllers
{
    public class DispenserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
