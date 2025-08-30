using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyAPI.Models
{
    [Table("Pegawai")]
    public class Pegawai
    {
        [Key]
        public int PegawaiID { get; set; }

        [Required]
        [StringLength(150)]
        public string NamaLengkap { get; set; } = string.Empty;

        public DateTime? TanggalLahir { get; set; }

        [StringLength(255)]
        public string? Alamat { get; set; }

        [StringLength(20)]
        public string? NomorTelepon { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime TanggalMasuk { get; set; }

        [StringLength(50)]
        public string? StatusKontrak { get; set; }

        public int? CabangID { get; set; }
        public int? JabatanID { get; set; }

        // Navigation properties
        [ForeignKey("CabangID")]
        public Cabang? Cabang { get; set; }

        [ForeignKey("JabatanID")]
        public Jabatan? Jabatan { get; set; }
    }
}
