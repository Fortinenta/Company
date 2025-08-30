using CompanyAPI.Models;
using CompanyAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
    public class CabangService : ICabangService
    {
        private readonly CompanyDbContext _context;

        public CabangService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<CabangDto> CreateCabangAsync(CabangDto cabangDto)
        {
            var cabang = new Cabang
            {
                NamaCabang = cabangDto.NamaCabang,
                Alamat = cabangDto.Alamat,
                Kota = cabangDto.Kota,
                KodePos = cabangDto.KodePos
            };

            _context.Cabang.Add(cabang);
            await _context.SaveChangesAsync();

            cabangDto.CabangID = cabang.CabangID;
            return cabangDto;
        }

        public async Task<bool> DeleteCabangAsync(int id)
        {
            var cabang = await _context.Cabang.FindAsync(id);
            if (cabang == null)
            {
                return false;
            }

            _context.Cabang.Remove(cabang);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CabangDto>> GetAllCabangAsync()
        {
            return await _context.Cabang
                .Select(c => new CabangDto
                {
                    CabangID = c.CabangID,
                    NamaCabang = c.NamaCabang,
                    Alamat = c.Alamat,
                    Kota = c.Kota,
                    KodePos = c.KodePos
                }).ToListAsync();
        }

        public async Task<CabangDto?> GetCabangByIdAsync(int id)
        {
            var cabang = await _context.Cabang.FindAsync(id);

            if (cabang == null)
            {
                return null;
            }

            return new CabangDto
            {
                CabangID = cabang.CabangID,
                NamaCabang = cabang.NamaCabang,
                Alamat = cabang.Alamat,
                Kota = cabang.Kota,
                KodePos = cabang.KodePos
            };
        }

        public async Task<bool> UpdateCabangAsync(int id, CabangDto cabangDto)
        {
            var cabang = await _context.Cabang.FindAsync(id);
            if (cabang == null)
            {
                return false;
            }

            cabang.NamaCabang = cabangDto.NamaCabang;
            cabang.Alamat = cabangDto.Alamat!;
            cabang.Kota = cabangDto.Kota!;
            cabang.KodePos = cabangDto.KodePos!;

            _context.Entry(cabang).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cabang.Any(e => e.CabangID == id))
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