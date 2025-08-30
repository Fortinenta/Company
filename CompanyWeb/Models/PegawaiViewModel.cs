using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models
{
    public class PegawaiViewModel
    {
        public int PegawaiID { get; set; }

        [Required]
        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Nomor Telepon")]
        public string? NomorTelepon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Lahir")]
        public DateTime? TanggalLahir { get; set; }

        public string? Alamat { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tanggal Masuk")]
        public DateTime TanggalMasuk { get; set; }

        [Display(Name = "Status Kontrak")]
        public string? StatusKontrak { get; set; }

        [Required]
        [Display(Name = "Cabang")]
        public int? CabangID { get; set; }

        [Required]
        [Display(Name = "Jabatan")]
        public int? JabatanID { get; set; }

        [Display(Name = "Nama Cabang")]
        public string? NamaCabang { get; set; }

        [Display(Name = "Nama Jabatan")]
        public string? NamaJabatan { get; set; }
    }
}