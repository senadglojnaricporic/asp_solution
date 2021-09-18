using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.MVC.Models;
using Project.Service.Interfaces;
using Project.MVC.Data;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehicleMakeController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: VehicleMake
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.VehicleMakes.ToListAsync());
        }

        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = await _context.VehicleMakes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMakeViewModel == null)
            {
                return NotFound();
            }

            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleMakeViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = await _context.VehicleMakes.FindAsync(id);
            if (vehicleMakeViewModel == null)
            {
                return NotFound();
            }
            return View(vehicleMakeViewModel);
        }

        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeViewModel)
        {
            if (id != vehicleMakeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleMakeViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakeViewModelExists(vehicleMakeViewModel.Id))
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
            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = await _context.VehicleMakes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMakeViewModel == null)
            {
                return NotFound();
            }

            return View(vehicleMakeViewModel);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleMakeViewModel = await _context.VehicleMakes.FindAsync(id);
            _context.VehicleMakes.Remove(vehicleMakeViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleMakeViewModelExists(int id)
        {
            return _context.VehicleMakes.Any(e => e.Id == id);
        }
    }
}
