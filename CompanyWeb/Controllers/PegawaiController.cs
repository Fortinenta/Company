using CompanyWeb.Models;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyWeb.Controllers
{
    public class PegawaiController : Controller
    {
        private readonly PegawaiApiService _pegawaiApiService;
        private readonly CabangApiService _cabangApiService;
        private readonly JabatanApiService _jabatanApiService;

        public PegawaiController(PegawaiApiService pegawaiApiService, CabangApiService cabangApiService, JabatanApiService jabatanApiService)
        {
            _pegawaiApiService = pegawaiApiService;
            _cabangApiService = cabangApiService;
            _jabatanApiService = jabatanApiService;
        }

        // GET: Pegawai
        public async Task<IActionResult> Index(string searchNama)
        {
            IEnumerable<PegawaiViewModel>? pegawai;
            if (string.IsNullOrEmpty(searchNama))
            {
                pegawai = await _pegawaiApiService.GetAllPegawaiAsync();
            }
            else
            {
                pegawai = await _pegawaiApiService.SearchPegawaiAsync(searchNama);
            }
            return View(pegawai);
        }

        // GET: Pegawai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _pegawaiApiService.GetPegawaiByIdAsync(id.Value);
            if (pegawai == null)
            {
                return NotFound();
            }
            return View(pegawai);
        }

        // GET: Pegawai/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        // POST: Pegawai/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamaLengkap,Email,NomorTelepon,TanggalLahir,Alamat,TanggalMasuk,StatusKontrak,CabangID,JabatanID")] PegawaiViewModel pegawaiViewModel)
        {
            if (ModelState.IsValid)
            {
                var createdPegawai = await _pegawaiApiService.CreatePegawaiAsync(pegawaiViewModel);
                if (createdPegawai != null)
                {
                    TempData["SuccessMessage"] = "Employee created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error creating employee.");
                TempData["ErrorMessage"] = "Error creating employee.";
            }
            await PopulateDropdowns();
            return View(pegawaiViewModel);
        }

        // GET: Pegawai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _pegawaiApiService.GetPegawaiByIdAsync(id.Value);
            if (pegawai == null)
            {
                return NotFound();
            }
            await PopulateDropdowns();
            return View(pegawai);
        }

        // POST: Pegawai/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PegawaiID,NamaLengkap,Email,NomorTelepon,TanggalLahir,Alamat,TanggalMasuk,StatusKontrak,CabangID,JabatanID")] PegawaiViewModel pegawaiViewModel)
        {
            if (id != pegawaiViewModel.PegawaiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _pegawaiApiService.UpdatePegawaiAsync(pegawaiViewModel);
                if (success)
                {
                    TempData["SuccessMessage"] = "Employee updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error updating employee.");
                TempData["ErrorMessage"] = "Error updating employee.";
            }
            await PopulateDropdowns();
            return View(pegawaiViewModel);
        }

        // GET: Pegawai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _pegawaiApiService.GetPegawaiByIdAsync(id.Value);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // POST: Pegawai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _pegawaiApiService.DeletePegawaiAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Employee deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Error deleting employee.");
            TempData["ErrorMessage"] = "Error deleting employee.";
            return RedirectToAction(nameof(Delete), new { id = id });
        }

        // GET: Pegawai/Search
        // This action is now integrated into the Index action.
        // public async Task<IActionResult> Search(string nama)
        // {
        //     var pegawai = await _pegawaiApiService.SearchPegawaiAsync(nama);
        //     return View("Index", pegawai);
        // }

        private async Task PopulateDropdowns()
        {
            var cabangs = await _cabangApiService.GetAllCabangAsync();
            var jabatans = await _jabatanApiService.GetAllJabatanAsync();

            ViewBag.CabangList = new SelectList(cabangs, "CabangID", "NamaCabang");
            ViewBag.JabatanList = new SelectList(jabatans, "JabatanID", "NamaJabatan");
        }
    }
}
