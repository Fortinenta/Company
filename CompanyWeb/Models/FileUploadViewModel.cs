using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyWeb.Models
{
    public class FileUploadViewModel
    {
        [Display(Name = "File")]
        public IFormFile? FormFile { get; set; }

        public List<PegawaiViewModel>? StagedPegawai { get; set; }

        // Properties for dropdown options
        public IEnumerable<SelectListItem> StatusKontrakOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> CabangOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> JabatanOptions { get; set; } = new List<SelectListItem>();
    }
}
