namespace CompanyAPI.ViewModels
{
    public class PegawaiDto
    {
        public int PegawaiID { get; set; }
        public string? NamaLengkap { get; set; }
        public string? Email { get; set; }
        public string? NomorTelepon { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? Alamat { get; set; }
        public int? CabangID { get; set; }
        public int? JabatanID { get; set; }
        public DateTime TanggalMasuk { get; set; }
        public string? StatusKontrak { get; set; }
        public string? NamaCabang { get; set; }
        public string? NamaJabatan { get; set; }
    }
}
