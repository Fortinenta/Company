using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models
{
    public class Pegawai
    {
        [Key]
        public int PegawaiID { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaLengkap { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? TanggalLahir { get; set; }

        [StringLength(255)]
        public string? Alamat { get; set; }

        [StringLength(20)]
        public string? NomorTelepon { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime TanggalMasuk { get; set; }

        [StringLength(50)]
        public string? StatusKontrak { get; set; }

        public int? CabangID { get; set; }
        public Cabang? Cabang { get; set; }

        public int? JabatanID { get; set; }
        public Jabatan? Jabatan { get; set; }
    }
}

