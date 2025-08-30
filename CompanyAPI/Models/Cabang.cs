using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyAPI.Models
{
    [Table("Cabang")]
    public class Cabang
    {
        [Key]
        public int CabangID { get; set; }

        [Required]
        [StringLength(100)]
        public string NamaCabang { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Alamat { get; set; }

        [StringLength(100)]
        public string? Kota { get; set; }

        [StringLength(10)]
        public string? KodePos { get; set; }

        // Navigation property for related Pegawai
        public ICollection<Pegawai> Pegawai { get; set; } = new List<Pegawai>();
    }
}
