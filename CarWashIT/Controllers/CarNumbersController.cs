using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarWashIT.Data;
using CarWashIT.Models;

namespace CarWashIT.Controllers
{
    public class CarNumbersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarNumbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarNumbers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarNumbers.Include(c => c.Car);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CarNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carNumber = await _context.CarNumbers
                .Include(c => c.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carNumber == null)
            {
                return NotFound();
            }

            return View(carNumber);
        }

        // GET: CarNumbers/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
            return View();
        }

        // POST: CarNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Number,CarId")] CarNumber carNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", carNumber.CarId);
            return View(carNumber);
        }

        // GET: CarNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carNumber = await _context.CarNumbers.FindAsync(id);
            if (carNumber == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", carNumber.CarId);
            return View(carNumber);
        }

        // POST: CarNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Number,CarId")] CarNumber carNumber)
        {
            if (id != carNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarNumberExists(carNumber.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", carNumber.CarId);
            return View(carNumber);
        }

        // GET: CarNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carNumber = await _context.CarNumbers
                .Include(c => c.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carNumber == null)
            {
                return NotFound();
            }

            return View(carNumber);
        }

        // POST: CarNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carNumber = await _context.CarNumbers.FindAsync(id);
            _context.CarNumbers.Remove(carNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarNumberExists(int id)
        {
            return _context.CarNumbers.Any(e => e.Id == id);
        }
    }
}
