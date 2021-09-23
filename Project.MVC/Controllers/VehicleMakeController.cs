using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.MVC.Models;
using Project.Service.Interfaces;
using Project.Service.Models;
using Project.MVC.Data;
using AutoMapper;
using Project.Service.Collections;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _service;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: VehicleMake
        public async Task<IActionResult> Index(string sortOrder, int pageIndex = 1)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["AbrvSortParam"] = sortOrder == "abrv" ? "abrv_desc" : "abrv";

            var vehicleMakeData = _service.GetData<VehicleMakeDataModel>();
            vehicleMakeData = _service.Sort(vehicleMakeData, sortOrder);
            var list = await _service.CreatePageAsync<VehicleMakeDataModel>(vehicleMakeData, pageIndex, 3);
            var vehicleMakeView = _mapper.Map<PaginatedList<VehicleMakeViewModel>>(list);

            return View(vehicleMakeView);
        }

        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMakeDataModel = await _service.ReadById<VehicleMakeDataModel>((int)id);

            if (vehicleMakeDataModel == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMakeDataModel);

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
                var vehicleMakeDataModel = _mapper.Map<VehicleMakeDataModel>(vehicleMakeViewModel);
                await _service.Create<VehicleMakeDataModel>(vehicleMakeDataModel);
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

            var vehicleMakeDataModel = await _service.ReadById<VehicleMakeDataModel>((int)id);

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMakeDataModel);

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
                var vehicleMakeDataModel = _mapper.Map<VehicleMakeDataModel>(vehicleMakeViewModel);

                try
                {
                    await _service.Update<VehicleMakeDataModel>(vehicleMakeDataModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakeViewModelExists(vehicleMakeDataModel.Id))
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

            var vehicleMakeDataModel = await _service.ReadById<VehicleMakeDataModel>((int)id);

            if (vehicleMakeDataModel == null)
            {
                return NotFound();
            }

            var vehicleMakeViewModel = _mapper.Map<VehicleMakeViewModel>(vehicleMakeDataModel);

            return View(vehicleMakeViewModel);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleMakeDataModel = await _service.ReadById<VehicleMakeDataModel>(id);
            await _service.Delete<VehicleMakeDataModel>(id);

            return RedirectToAction(nameof(Index));
        }

        private bool VehicleMakeViewModelExists(int id)
        {
            return _service.GetData<VehicleMakeDataModel>().Any(x => x.Id == id);
        }
    }
}
