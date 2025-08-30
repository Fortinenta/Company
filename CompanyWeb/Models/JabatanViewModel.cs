using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models
{
    public class JabatanViewModel
    {
        public int JabatanID { get; set; }

        [Required]
        [Display(Name = "Nama Jabatan")]
        public string NamaJabatan { get; set; }

        public string? Deskripsi { get; set; }
    }
}
