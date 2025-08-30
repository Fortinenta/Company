using CompanyAPI.Models;
using CompanyAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public ReportController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Report/pegawaireport
        [HttpGet("pegawaireport")]
        public async Task<ActionResult<IEnumerable<PegawaiDto>>> GetPegawaiReport()
        {
            var pegawaiReport = await _context.Pegawai
                .FromSqlRaw("SELECT * FROM vw_PegawaiReport")
                .Select(p => new PegawaiDto
                {
                    PegawaiID = p.PegawaiID,
                    NamaLengkap = p.NamaLengkap,
                    Email = p.Email,
                    NomorTelepon = p.NomorTelepon,
                    TanggalMasuk = p.TanggalMasuk,
                    StatusKontrak = p.StatusKontrak,
                    NamaCabang = p.Cabang != null ? p.Cabang.NamaCabang : null,
                    NamaJabatan = p.Jabatan != null ? p.Jabatan.NamaJabatan : null
                })
                .ToListAsync();
            return Ok(pegawaiReport);
        }

        // GET: api/Report/pegawaibystatus
        [HttpGet("pegawaibystatus")]
        public async Task<ActionResult<IEnumerable<PegawaiDto>>> GetPegawaiByStatus([FromQuery] string status)
        {
            var statusParam = new SqlParameter("status", status);
            var pegawai = await _context.Pegawai
                .FromSqlRaw("EXEC sp_GetPegawaiByContract @status", statusParam)
                .Select(p => new PegawaiDto
                {
                    PegawaiID = p.PegawaiID,
                    NamaLengkap = p.NamaLengkap,
                    Email = p.Email,
                    NomorTelepon = p.NomorTelepon,
                    TanggalMasuk = p.TanggalMasuk,
                    StatusKontrak = p.StatusKontrak,
                    NamaCabang = p.Cabang != null ? p.Cabang.NamaCabang : null,
                    NamaJabatan = p.Jabatan != null ? p.Jabatan.NamaJabatan : null
                })
                .ToListAsync();
            return Ok(pegawai);
        }

        // POST: api/Report/importpegawai
        [HttpPost("importpegawai")]
        public async Task<IActionResult> ImportPegawai([FromBody] List<PegawaiDto> pegawaiList)
        {
            // This requires a custom Table-Valued Parameter (TVP) type in SQL Server
            // and a way to pass it from C#.
            // For simplicity, this example will do individual inserts or require a more complex TVP setup.
            // A more robust solution would involve creating a DataTable from pegawaiList and passing it as a TVP.

            foreach (var pegawaiDto in pegawaiList)
            {
                var pegawai = new Pegawai
                {
                    NamaLengkap = pegawaiDto.NamaLengkap,
                    TanggalLahir = pegawaiDto.TanggalLahir!,
                    Alamat = pegawaiDto.Alamat!,
                    NomorTelepon = pegawaiDto.NomorTelepon!,
                    Email = pegawaiDto.Email!,
                    TanggalMasuk = pegawaiDto.TanggalMasuk!,
                    StatusKontrak = pegawaiDto.StatusKontrak!,
                    CabangID = pegawaiDto.CabangID!,
                    JabatanID = pegawaiDto.JabatanID!
                };
                _context.Pegawai.Add(pegawai);
            }
            await _context.SaveChangesAsync();

            return Ok("Import successful.");
        }
    }
}