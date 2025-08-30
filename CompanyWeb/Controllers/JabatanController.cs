using CompanyWeb.Models;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class JabatanController : Controller
    {
        private readonly JabatanApiService _jabatanApiService;

        public JabatanController(JabatanApiService jabatanApiService)
        {
            _jabatanApiService = jabatanApiService;
        }

        // GET: Jabatan
        public async Task<IActionResult> Index()
        {
            var jabatan = await _jabatanApiService.GetAllJabatanAsync();
            return View(jabatan);
        }

        // GET: Jabatan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jabatan = await _jabatanApiService.GetJabatanByIdAsync(id.Value);
            if (jabatan == null)
            {
                return NotFound();
            }
            return View(jabatan);
        }

        // GET: Jabatan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jabatan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamaJabatan,Deskripsi")] JabatanViewModel jabatanViewModel)
        {
            if (ModelState.IsValid)
            {
                var createdJabatan = await _jabatanApiService.CreateJabatanAsync(jabatanViewModel);
                if (createdJabatan != null)
                {
                    TempData["SuccessMessage"] = "Position created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error creating position.");
                TempData["ErrorMessage"] = "Error creating position.";
            }
            return View(jabatanViewModel);
        }

        // GET: Jabatan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jabatan = await _jabatanApiService.GetJabatanByIdAsync(id.Value);
            if (jabatan == null)
            {
                return NotFound();
            }
            return View(jabatan);
        }

        // POST: Jabatan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JabatanID,NamaJabatan,Deskripsi")] JabatanViewModel jabatanViewModel)
        {
            if (id != jabatanViewModel.JabatanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _jabatanApiService.UpdateJabatanAsync(jabatanViewModel);
                if (success)
                {
                    TempData["SuccessMessage"] = "Position updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error updating position.");
                TempData["ErrorMessage"] = "Error updating position.";
            }
            return View(jabatanViewModel);
        }

        // GET: Jabatan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jabatan = await _jabatanApiService.GetJabatanByIdAsync(id.Value);
            if (jabatan == null)
            {
                return NotFound();
            }

            return View(jabatan);
        }

        // POST: Jabatan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _jabatanApiService.DeleteJabatanAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Position deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Error deleting position.");
            TempData["ErrorMessage"] = "Error deleting position.";
            return RedirectToAction(nameof(Delete), new { id = id });
        }
    }
}
