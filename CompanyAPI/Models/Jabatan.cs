using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyAPI.Models
{
    [Table("Jabatan")]
    public class Jabatan
    {
        [Key]
        public int JabatanID { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaJabatan { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Deskripsi { get; set; }

        // Navigation property for related Pegawai
        public ICollection<Pegawai> Pegawai { get; set; } = new List<Pegawai>();
    }
}
