using CompanyWeb.Models;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using CsvHelper;
using System.Text;
using CsvHelper.Configuration;
using CompanyWeb.Mappings;

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
            if (id == null) return NotFound();
            var pegawai = await _pegawaiApiService.GetPegawaiByIdAsync(id.Value);
            if (pegawai == null) return NotFound();
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
            }
            await PopulateDropdowns();
            return View(pegawaiViewModel);
        }

        // GET: Pegawai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var pegawai = await _pegawaiApiService.GetPegawaiByIdAsync(id.Value);
            if (pegawai == null) return NotFound();
            await PopulateDropdowns();
            return View(pegawai);
        }

        // POST: Pegawai/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PegawaiID,NamaLengkap,Email,NomorTelepon,TanggalLahir,Alamat,TanggalMasuk,StatusKontrak,CabangID,JabatanID")] PegawaiViewModel pegawaiViewModel)
        {
            if (id != pegawaiViewModel.PegawaiID) return NotFound();
            if (ModelState.IsValid)
            {
                var success = await _pegawaiApiService.UpdatePegawaiAsync(pegawaiViewModel);
                if (success)
                {
                    TempData["SuccessMessage"] = "Employee updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
            }
            await PopulateDropdowns();
            return View(pegawaiViewModel);
        }

        // GET: Pegawai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var pegawai = await _pegawaiApiService.GetPegawaiByIdAsync(id.Value);
            if (pegawai == null) return NotFound();
            return View(pegawai);
        }

        // POST: Pegawai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _pegawaiApiService.DeletePegawaiAsync(id);
            if (success) TempData["SuccessMessage"] = "Employee deleted successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Pegawai/Upload
        public IActionResult Upload()
        {
            return View(new FileUploadViewModel());
        }

        private async Task<FileUploadViewModel> PopulateDropdownsForUpload(FileUploadViewModel model)
        {
            var cabangs = await _cabangApiService.GetAllCabangAsync();
            var jabatans = await _jabatanApiService.GetAllJabatanAsync();

            model.CabangOptions = cabangs.Select(c => new SelectListItem { Value = c.CabangID.ToString(), Text = c.NamaCabang }).ToList();
            model.JabatanOptions = jabatans.Select(j => new SelectListItem { Value = j.JabatanID.ToString(), Text = j.NamaJabatan }).ToList();
            model.StatusKontrakOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Aktif", Text = "Aktif" },
                new SelectListItem { Value = "Tidak Aktif", Text = "Tidak Aktif" },
                new SelectListItem { Value = "Permanen", Text = "Permanen" }
            };

            return model;
        }

        // POST: Pegawai/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(FileUploadViewModel model)
        {
            if (model.FormFile != null && model.FormFile.Length > 0)
            {
                try
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null };
                    using (var reader = new StreamReader(model.FormFile.OpenReadStream()))
                    using (var csv = new CsvReader(reader, config))
                    {
                        csv.Context.RegisterClassMap<PegawaiViewModelMap>();
                        var records = csv.GetRecords<PegawaiViewModel>().ToList();
                        model.StagedPegawai = records;
                    }
                    TempData["SuccessMessage"] = $"{model.StagedPegawai.Count} records loaded from file. Please review before saving.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error processing file: {ex.Message}";
                }
            }
            else
            {
                ModelState.AddModelError("FormFile", "Please select a file to upload.");
            }
            await PopulateDropdownsForUpload(model);
            return View(model);
        }

        // GET: Pegawai/BatchUpdate
        public IActionResult BatchUpdate()
        {
            return View(new FileUploadViewModel());
        }

        // POST: Pegawai/BatchUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BatchUpdate(FileUploadViewModel model)
        {
            if (model.FormFile != null && model.FormFile.Length > 0)
            {
                try
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null };
                    using (var reader = new StreamReader(model.FormFile.OpenReadStream()))
                    using (var csv = new CsvReader(reader, config))
                    {
                        csv.Context.RegisterClassMap<PegawaiViewModelMap>();
                        var records = csv.GetRecords<PegawaiViewModel>().ToList();
                        model.StagedPegawai = records;
                    }
                    TempData["SuccessMessage"] = $"{model.StagedPegawai.Count} records loaded from file for update. Please review before saving.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error processing file: {ex.Message}";
                }
            }
            else
            {
                ModelState.AddModelError("FormFile", "Please select a file to upload.");
            }
            await PopulateDropdownsForUpload(model);
            return View(model);
        }

        // GET: Pegawai/DownloadTemplate
        public IActionResult DownloadTemplate()
        {
            var exampleRecord = new List<PegawaiViewModel> { new PegawaiViewModel { NamaLengkap = "John Doe", Email = "john.doe@example.com", NomorTelepon = "081234567890", TanggalLahir = new DateTime(1990, 1, 15), Alamat = "123 Main Street", TanggalMasuk = DateTime.Today, StatusKontrak = "Aktif", CabangID = 1, JabatanID = 1 } };
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PegawaiViewModelMap>();
                csv.WriteRecords(exampleRecord);
                writer.Flush();
                return File(memoryStream.ToArray(), "text/csv", "template-pegawai.csv");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveStagedData(FileUploadViewModel model)
        {
            if (model.StagedPegawai == null || !model.StagedPegawai.Any()) { TempData["ErrorMessage"] = "No data to save."; return RedirectToAction(nameof(Upload)); }
            var result = await _pegawaiApiService.ProcessBatchAsync(model.StagedPegawai);
            if (result != null && result.Success) { TempData["SuccessMessage"] = result.Message; } else { TempData["ErrorMessage"] = result?.Message ?? "An unknown error occurred."; }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessMassAction(string action, List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                TempData["ErrorMessage"] = "No items selected.";
                return RedirectToAction(nameof(Index));
            }

            switch (action)
            {
                case "export":
                    var allPegawai = await _pegawaiApiService.GetAllPegawaiAsync();
                    var selectedPegawai = allPegawai.Where(p => selectedIds.Contains(p.PegawaiID)).ToList();
                    
                    using (var memoryStream = new MemoryStream())
                    using (var writer = new StreamWriter(memoryStream))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<PegawaiViewModelMap>();
                        csv.WriteRecords(selectedPegawai);
                        writer.Flush();
                        return File(memoryStream.ToArray(), "text/csv", $"pegawai-export-{DateTime.UtcNow.Ticks}.csv");
                    }

                case "delete":
                    int successCount = 0;
                    foreach (var id in selectedIds)
                    {
                        var success = await _pegawaiApiService.DeletePegawaiAsync(id);
                        if (success) successCount++;
                    }
                    TempData["SuccessMessage"] = $"{successCount} records deleted successfully.";
                    return RedirectToAction(nameof(Index));

                default:
                    return BadRequest("Invalid action.");
            }
        }

        public async Task<IActionResult> ExportPegawai()
        {
            var pegawaiList = await _pegawaiApiService.GetAllPegawaiAsync();
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PegawaiViewModelMap>();
                csv.WriteRecords(pegawaiList);
                writer.Flush();
                return File(memoryStream.ToArray(), "text/csv", "pegawai-export.csv");
            }
        }

        private async Task PopulateDropdowns()
        {
            var cabangs = await _cabangApiService.GetAllCabangAsync();
            var jabatans = await _jabatanApiService.GetAllJabatanAsync();
            ViewBag.CabangList = new SelectList(cabangs, "CabangID", "NamaCabang");
            ViewBag.JabatanList = new SelectList(jabatans, "JabatanID", "NamaJabatan");
        }
    }
}