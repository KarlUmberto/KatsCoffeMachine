using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KatsCoffeMachine.Data;
using KatsCoffeMachine.Models;

namespace KatsCoffeMachine.Controllers
{
    public class CoffeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
         Naitab koffisi mida saab tellida, kui topse pole, siis ei naita v ytleb et ei saa tellida.. mingi out of service

         */
        public async Task<IActionResult> Dispenser()
        {
            var applicationDbContext = _context.Coffee.Include(c => c.Brand).Include(c => c.CoffeeType);
            return View(await applicationDbContext.ToListAsync());
        }

        /* 
         Order method, vahendab topside arvu ja kui arv on 0 siis votab 1 package ara ja lisab tagasi 50
         */
        [HttpPost]
        public async Task<IActionResult> Dispenser(int? id)
        {
            if (id == null || _context.Coffee == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .Include(c => c.Brand)
                .Include(c => c.CoffeeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            coffee.CupsAvailable--;

            await _context.SaveChangesAsync();
            return RedirectToAction("OrderComplete", new { id = id });

        }

        public async Task<IActionResult> OrderComplete(int? id)
        {
            if (id == null || _context.Coffee == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .Include(c => c.Brand)
                .Include(c => c.CoffeeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }




        //public OrderDrink()
        //{
        //    var applicationDbContext = _context
        //                    .Coffee
        //                    .Include(c => c.CoffeeType)
        //                    .Where(r => r.Brand == Brand);

        //    IQueryable<string> genreQuery = from m in _context.CoffeeType
        //                                    orderby m.Coffees
        //                                    select m.Brand;
        //    var cargos = from m in _context.Coffee
        //                 select m;

        //    if (!string.IsNullOrEmpty(Brand))
        //    {
        //        cargos = cargos.Where(x => x.Brand == Brand);
        //    }
        //}

        // GET: Coffees
        public async Task<IActionResult> Orders()
        {
            var applicationDbContext = _context.Coffee.Include(c => c.Brand).Include(c => c.CoffeeType);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult AddDrink()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
            ViewData["CoffeeTypeId"] = new SelectList(_context.Set<CoffeeType>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDrink([Bind("Id,DisplayName,BrandId,CoffeeTypeId,CupsAvailable,CupsInPackage")] Coffee coffee)
        {
            var coffeeType = await _context.CoffeeType.FirstOrDefaultAsync(m => m.Id == coffee.CoffeeTypeId);
            coffee.CoffeeType = coffeeType;
            ModelState.ClearValidationState(nameof(coffee.CoffeeType));
            var brand = await _context.Brand.FirstOrDefaultAsync(m => m.Id == coffee.BrandId);
            coffee.Brand = brand;
            coffee.CupsAvailable = 0;
            ModelState.ClearValidationState(nameof(coffee.Brand));
            TryValidateModel(coffee);
            if (ModelState.IsValid)
            {
                _context.Add(coffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Orders));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", coffee.BrandId);
            ViewData["CoffeeTypeId"] = new SelectList(_context.Set<CoffeeType>(), "Id", "Id", coffee.CoffeeTypeId);
            return View(coffee);
        }


        // GET: Coffees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Coffee.Include(c => c.Brand).Include(c => c.CoffeeType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Coffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Coffee == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .Include(c => c.Brand)
                .Include(c => c.CoffeeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // GET: Coffees/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id");
            ViewData["CoffeeTypeId"] = new SelectList(_context.CoffeeType, "Id", "Id");
            return View();
        }

        // POST: Coffees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisplayName,BrandId,CoffeeTypeId,CupsAvailable,CupsInPackage")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", coffee.BrandId);
            ViewData["CoffeeTypeId"] = new SelectList(_context.CoffeeType, "Id", "Id", coffee.CoffeeTypeId);
            return View(coffee);
        }

        // GET: Coffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Coffee == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee.FindAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", coffee.BrandId);
            ViewData["CoffeeTypeId"] = new SelectList(_context.CoffeeType, "Id", "Id", coffee.CoffeeTypeId);
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisplayName,BrandId,CoffeeTypeId,CupsAvailable,CupsInPackage")] Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeExists(coffee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Id", coffee.BrandId);
            ViewData["CoffeeTypeId"] = new SelectList(_context.CoffeeType, "Id", "Id", coffee.CoffeeTypeId);
            return View(coffee);
        }

        // GET: Coffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Coffee == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .Include(c => c.Brand)
                .Include(c => c.CoffeeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Coffee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Coffee'  is null.");
            }
            var coffee = await _context.Coffee.FindAsync(id);
            if (coffee != null)
            {
                _context.Coffee.Remove(coffee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeExists(int id)
        {
            return (_context.Coffee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
