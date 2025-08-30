using CompanyAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.ViewModels
{
    public class PegawaiDto
    {
        public PegawaiDto() { }

        public PegawaiDto(Pegawai pegawai)
        {
            PegawaiID = pegawai.PegawaiID;
            NamaLengkap = pegawai.NamaLengkap;
            Email = pegawai.Email;
            NomorTelepon = pegawai.NomorTelepon;
            TanggalLahir = pegawai.TanggalLahir;
            Alamat = pegawai.Alamat;
            TanggalMasuk = pegawai.TanggalMasuk;
            StatusKontrak = pegawai.StatusKontrak;
            CabangID = pegawai.CabangID;
            JabatanID = pegawai.JabatanID;
            NamaCabang = pegawai.Cabang?.NamaCabang;
            NamaJabatan = pegawai.Jabatan?.NamaJabatan;
        }

        public int PegawaiID { get; set; }
        public string NamaLengkap { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? NomorTelepon { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TanggalLahir { get; set; }
        public string? Alamat { get; set; }

        [DataType(DataType.Date)]
        public DateTime TanggalMasuk { get; set; }
        public string? StatusKontrak { get; set; }
        public int? CabangID { get; set; }
        public int? JabatanID { get; set; }
        public string? NamaCabang { get; set; }
        public string? NamaJabatan { get; set; }
    }
}

