using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.MVC.Models;
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
                                                string searchString, int pageIndex = 1)
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

            var list = await _service.GetPageAsync(sortOrder, searchString, pageIndex);
            
            var vehicleModelView = _mapper.Map<PaginatedList<VehicleModelViewModel>>(list);

            return View(vehicleModelView);
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModelDataModel = await _service.ReadById<VehicleModelDataModel>((int)id);

            if (vehicleModelDataModel == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModelDataModel);

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
                var vehicleModelDataModel = _mapper.Map<VehicleModelDataModel>(vehicleModelViewModel);
                await _service.Create<VehicleModelDataModel>(vehicleModelDataModel);
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

            var vehicleModelDataModel = await _service.ReadById<VehicleModelDataModel>((int)id);

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModelDataModel);

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
                var vehicleModelDataModel = _mapper.Map<VehicleModelDataModel>(vehicleModelViewModel);

                try
                {
                    await _service.Update<VehicleModelDataModel>(vehicleModelDataModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelViewModelExists(vehicleModelDataModel.Id))
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

            var vehicleModelDataModel = await _service.ReadById<VehicleModelDataModel>((int)id);

            if (vehicleModelDataModel == null)
            {
                return NotFound();
            }

            var vehicleModelViewModel = _mapper.Map<VehicleModelViewModel>(vehicleModelDataModel);

            return View(vehicleModelViewModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModelDataModel = await _service.ReadById<VehicleModelDataModel>(id);
            await _service.Delete<VehicleModelDataModel>(id);

            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelViewModelExists(int id)
        {
            return _service.ReadById<VehicleModelDataModel>(id) != null;
        }
    }
}
