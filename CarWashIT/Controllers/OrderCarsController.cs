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
    public class OrderCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderCars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderCars.Include(o => o.Car).Include(o => o.Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderCar = await _context.OrderCars
                .Include(o => o.Car)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderCar == null)
            {
                return NotFound();
            }

            return View(orderCar);
        }

        // GET: OrderCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: OrderCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CarId")] OrderCar orderCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", orderCar.CarId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderCar.OrderId);
            return View(orderCar);
        }

        // GET: OrderCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderCar = await _context.OrderCars.FindAsync(id);
            if (orderCar == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", orderCar.CarId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderCar.OrderId);
            return View(orderCar);
        }

        // POST: OrderCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CarId")] OrderCar orderCar)
        {
            if (id != orderCar.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderCarExists(orderCar.OrderId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", orderCar.CarId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderCar.OrderId);
            return View(orderCar);
        }

        // GET: OrderCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderCar = await _context.OrderCars
                .Include(o => o.Car)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderCar == null)
            {
                return NotFound();
            }

            return View(orderCar);
        }

        // POST: OrderCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderCar = await _context.OrderCars.FindAsync(id);
            _context.OrderCars.Remove(orderCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderCarExists(int id)
        {
            return _context.OrderCars.Any(e => e.OrderId == id);
        }
    }
}
