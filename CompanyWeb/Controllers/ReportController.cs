using CompanyWeb.Models;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly PegawaiApiService _pegawaiApiService;
        private readonly CabangApiService _cabangApiService;

        public ReportController(PegawaiApiService pegawaiApiService, CabangApiService cabangApiService)
        {
            _pegawaiApiService = pegawaiApiService;
            _cabangApiService = cabangApiService;
        }

        public async Task<IActionResult> Index()
        {
            var totalPegawai = (await _pegawaiApiService.GetAllPegawaiAsync())?.Count() ?? 0;
            var totalCabang = (await _cabangApiService.GetAllCabangAsync())?.Count() ?? 0;

            var model = new ReportViewModel
            {
                TotalPegawai = totalPegawai,
                TotalCabang = totalCabang,
                // Add more report data here
            };

            return View(model);
        }
    }
}