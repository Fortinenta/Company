using CompanyWeb.Models;
using CsvHelper.Configuration;

namespace CompanyWeb.Mappings
{
    public sealed class PegawaiViewModelMap : ClassMap<PegawaiViewModel>
    {
        public PegawaiViewModelMap()
        {
            AutoMap(System.Globalization.CultureInfo.InvariantCulture);
            Map(m => m.TanggalLahir).TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.TanggalMasuk).TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.NamaCabang).Ignore();
            Map(m => m.NamaJabatan).Ignore();
        }
    }
}
