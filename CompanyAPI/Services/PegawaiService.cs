using CompanyAPI.Models;
using CompanyAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
    public class PegawaiService : IPegawaiService
    {
        private readonly CompanyDbContext _context;

        public PegawaiService(CompanyDbContext context)
        { 
            _context = context;
        }

        public async Task<PegawaiDto> CreatePegawaiAsync(PegawaiDto pegawaiDto)
        {
            var pegawai = new Pegawai
            {
                NamaLengkap = pegawaiDto.NamaLengkap,
                TanggalLahir = pegawaiDto.TanggalLahir,
                Alamat = pegawaiDto.Alamat,
                NomorTelepon = pegawaiDto.NomorTelepon,
                Email = pegawaiDto.Email,
                TanggalMasuk = pegawaiDto.TanggalMasuk,
                StatusKontrak = pegawaiDto.StatusKontrak,
                CabangID = pegawaiDto.CabangID,
                JabatanID = pegawaiDto.JabatanID
            };

            _context.Pegawai.Add(pegawai);
            await _context.SaveChangesAsync();

            pegawaiDto.PegawaiID = pegawai.PegawaiID;
            return pegawaiDto;
        }

        public async Task<bool> DeletePegawaiAsync(int id)
        {
            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return false;
            }

            _context.Pegawai.Remove(pegawai);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PegawaiDto>> GetAllPegawaiAsync()
        {
            return await _context.Pegawai
                .Include(p => p.Cabang)
                .Include(p => p.Jabatan)
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
                }).ToListAsync();
        }

        public async Task<PegawaiDto?> GetPegawaiByIdAsync(int id)
        {
            var pegawai = await _context.Pegawai
                .Include(p => p.Cabang)
                .Include(p => p.Jabatan)
                .FirstOrDefaultAsync(p => p.PegawaiID == id);

            if (pegawai == null)
            {
                return null;
            }

            return new PegawaiDto
            {
                PegawaiID = pegawai.PegawaiID,
                NamaLengkap = pegawai.NamaLengkap,
                Email = pegawai.Email,
                NomorTelepon = pegawai.NomorTelepon,
                TanggalMasuk = pegawai.TanggalMasuk,
                StatusKontrak = pegawai.StatusKontrak,
                NamaCabang = pegawai.Cabang != null ? pegawai.Cabang.NamaCabang : null,
                NamaJabatan = pegawai.Jabatan != null ? pegawai.Jabatan.NamaJabatan : null
            };
        }

        public async Task<IEnumerable<PegawaiDto>> SearchPegawaiAsync(string nama)
        {
            return await _context.Pegawai
                .Include(p => p.Cabang)
                .Include(p => p.Jabatan)
                .Where(p => p.NamaLengkap.Contains(nama))
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
                }).ToListAsync();
        }

        public async Task<bool> UpdatePegawaiAsync(int id, PegawaiDto pegawaiDto)
        {
            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return false;
            }

            pegawai.NamaLengkap = pegawaiDto.NamaLengkap;
            pegawai.TanggalLahir = pegawaiDto.TanggalLahir;
            pegawai.Alamat = pegawaiDto.Alamat;
            pegawai.NomorTelepon = pegawaiDto.NomorTelepon;
            pegawai.Email = pegawaiDto.Email;
            pegawai.TanggalMasuk = pegawaiDto.TanggalMasuk!;
            pegawai.StatusKontrak = pegawaiDto.StatusKontrak!;
            pegawai.CabangID = pegawaiDto.CabangID!;
            pegawai.JabatanID = pegawaiDto.JabatanID!;

            _context.Entry(pegawai).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pegawai.Any(e => e.PegawaiID == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
    }
}