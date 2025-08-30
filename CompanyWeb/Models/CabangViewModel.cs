using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models
{
    public class CabangViewModel
    {
        public int CabangID { get; set; }

        [Required]
        [Display(Name = "Nama Cabang")]
        public string NamaCabang { get; set; }

        public string? Alamat { get; set; }

        public string? Kota { get; set; }

        [Display(Name = "Kode Pos")]
        public string? KodePos { get; set; }
    }
}
