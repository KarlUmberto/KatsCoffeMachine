using KatsCoffeMachine.Models;
using Microsoft.AspNetCore.Mvc;

namespace KatsCoffeMachine.Controllers
{
    public class DispenserController : Controller
    {
        private int CupsInPackage = 50;
        public IActionResult Index()
        {
            //var coffe = _context.Coffee.Where(x => x.CoffeeType == CoffeeType).Where(x => x.Brand == Brand).Where(y => y.CupsAvailable <= 1).FirstOrDefault();
            return View();
        }
    }
}
