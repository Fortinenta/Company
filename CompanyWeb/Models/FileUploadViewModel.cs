using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyWeb.Models
{
    public class FileUploadViewModel
    {
        [Display(Name = "File")]
        public IFormFile? FormFile { get; set; }

        public SelectList? PegawaiList { get; set; }

        public int PegawaiId { get; set; }

        public List<PegawaiViewModel>? StagedPegawai { get; set; }

    }
}
