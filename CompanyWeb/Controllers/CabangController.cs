using CompanyWeb.Models;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class CabangController : Controller
    {
        private readonly CabangApiService _cabangApiService;

        public CabangController(CabangApiService cabangApiService)
        {
            _cabangApiService = cabangApiService;
        }

        // GET: Cabang
        public async Task<IActionResult> Index()
        {
            var cabang = await _cabangApiService.GetAllCabangAsync();
            return View(cabang);
        }

        // GET: Cabang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabang = await _cabangApiService.GetCabangByIdAsync(id.Value);
            if (cabang == null)
            {
                return NotFound();
            }
            return View(cabang);
        }

        // GET: Cabang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cabang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamaCabang,Alamat,Kota,KodePos")] CabangViewModel cabangViewModel)
        {
            if (ModelState.IsValid)
            {
                var createdCabang = await _cabangApiService.CreateCabangAsync(cabangViewModel);
                if (createdCabang != null)
                {
                    TempData["SuccessMessage"] = "Branch created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error creating branch.");
                TempData["ErrorMessage"] = "Error creating branch.";
            }
            return View(cabangViewModel);
        }

        // GET: Cabang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabang = await _cabangApiService.GetCabangByIdAsync(id.Value);
            if (cabang == null)
            {
                return NotFound();
            }
            return View(cabang);
        }

        // POST: Cabang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CabangID,NamaCabang,Alamat,Kota,KodePos")] CabangViewModel cabangViewModel)
        {
            if (id != cabangViewModel.CabangID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _cabangApiService.UpdateCabangAsync(cabangViewModel);
                if (success)
                {
                    TempData["SuccessMessage"] = "Branch updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error updating branch.");
                TempData["ErrorMessage"] = "Error updating branch.";
            }
            return View(cabangViewModel);
        }

        // GET: Cabang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabang = await _cabangApiService.GetCabangByIdAsync(id.Value);
            if (cabang == null)
            {
                return NotFound();
            }

            return View(cabang);
        }

        // POST: Cabang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _cabangApiService.DeleteCabangAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Branch deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Error deleting branch.");
            TempData["ErrorMessage"] = "Error deleting branch.";
            return RedirectToAction(nameof(Delete), new { id = id });
        }
    }
}
