using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.Models
{
    public class PegawaiViewModel
    {
        public int PegawaiID { get; set; }

        [Required]
        [Display(Name = "Nama Lengkap")]
        public string? NamaLengkap { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Nomor Telepon")]
        public string? NomorTelepon { get; set; }

        [Display(Name = "Tanggal Lahir")]
        [DataType(DataType.Date)]
        public DateTime? TanggalLahir { get; set; }

        [Display(Name = "Alamat")]
        public string? Alamat { get; set; }

        public int? CabangID { get; set; }
        public int? JabatanID { get; set; }

        [Display(Name = "Tanggal Masuk")]
        [DataType(DataType.Date)]
        public DateTime TanggalMasuk { get; set; }

        [Display(Name = "Status Kontrak")]
        public string? StatusKontrak { get; set; }

        [Display(Name = "Cabang")]
        public string? NamaCabang { get; set; }

        [Display(Name = "Jabatan")]
        public string? NamaJabatan { get; set; }
    }
}
