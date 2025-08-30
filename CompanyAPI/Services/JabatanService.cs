using CompanyAPI.Models;
using CompanyAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
    public class JabatanService : IJabatanService
    {
        private readonly CompanyDbContext _context;

        public JabatanService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<JabatanDto> CreateJabatanAsync(JabatanDto jabatanDto)
        {
            var jabatan = new Jabatan
            {
                NamaJabatan = jabatanDto.NamaJabatan,
                Deskripsi = jabatanDto.Deskripsi
            };

            _context.Jabatan.Add(jabatan);
            await _context.SaveChangesAsync();

            jabatanDto.JabatanID = jabatan.JabatanID;
            return jabatanDto;
        }

        public async Task<bool> DeleteJabatanAsync(int id)
        {
            var jabatan = await _context.Jabatan.FindAsync(id);
            if (jabatan == null)
            {
                return false;
            }

            _context.Jabatan.Remove(jabatan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<JabatanDto>> GetAllJabatanAsync()
        {
            return await _context.Jabatan
                .Select(j => new JabatanDto
                {
                    JabatanID = j.JabatanID,
                    NamaJabatan = j.NamaJabatan,
                    Deskripsi = j.Deskripsi
                }).ToListAsync();
        }

        public async Task<JabatanDto?> GetJabatanByIdAsync(int id)
        {
            var jabatan = await _context.Jabatan.FindAsync(id);

            if (jabatan == null)
            {
                return null;
            }

            return new JabatanDto
            {
                JabatanID = jabatan.JabatanID,
                NamaJabatan = jabatan.NamaJabatan,
                Deskripsi = jabatan.Deskripsi
            };
        }

        public async Task<bool> UpdateJabatanAsync(int id, JabatanDto jabatanDto)
        {
            var jabatan = await _context.Jabatan.FindAsync(id);
            if (jabatan == null)
            {
                return false;
            }

            jabatan.NamaJabatan = jabatanDto.NamaJabatan;
            jabatan.Deskripsi = jabatanDto.Deskripsi!;

            _context.Entry(jabatan).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Jabatan.Any(e => e.JabatanID == id))
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