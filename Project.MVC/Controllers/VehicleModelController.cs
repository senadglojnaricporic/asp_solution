using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.MVC.Models;
using Project.MVC.Data;
using Project.Service.Interfaces;
using AutoMapper;
using Project.Service.Models;
using Project.Service.Collections;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _service;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: VehicleModel
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,
                                                string searchString, int pageIndex)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["AbrvSortParam"] = sortOrder == "abrv" ? "abrv_desc" : "abrv";
            ViewData["MakeSortParam"] = sortOrder == "make" ? "make_desc" : "make";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var vehicleModelData = _service.GetData<VehicleModelDataModel>();
            vehicleModelData = _service.FilterModelByMake(vehicleModelData, searchString);
            vehicleModelData = _service.Sort(vehicleModelData, sortOrder);
            var list = await _service.CreatePageAsync<VehicleModelDataModel>(vehicleModelData, pageIndex, 3);
            var vehicleModelView = _mapper.Map<PaginatedList<VehicleModelViewModel>>(list);

            return View(vehicleModelView);
        }
/*
        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = await _context.VehicleModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModelViewModel == null)
            {
                return NotFound();
            }

            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MakeId,Name,Abrv")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleModelViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModelViewModel == null)
            {
                return NotFound();
            }
            return View(vehicleModelViewModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MakeId,Name,Abrv")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (id != vehicleModelViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleModelViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelViewModelExists(vehicleModelViewModel.Id))
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
            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = await _context.VehicleModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModelViewModel == null)
            {
                return NotFound();
            }

            return View(vehicleModelViewModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModelViewModel = await _context.VehicleModels.FindAsync(id);
            _context.VehicleModels.Remove(vehicleModelViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelViewModelExists(int id)
        {
            return _context.VehicleModels.Any(e => e.Id == id);
        }
*/    }
}
