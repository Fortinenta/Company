namespace CompanyWeb.Models
{
    public class ReportViewModel
    {
        public int TotalPegawai { get; set; }
        public int TotalCabang { get; set; }
        public int TotalJabatan { get; set; }
        public Dictionary<string, int> PegawaiPerCabang { get; set; }
    }
}
