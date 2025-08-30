using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models
{
    public class FileUploadViewModel
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
