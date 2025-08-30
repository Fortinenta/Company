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

        public async Task<IEnumerable<Pegawai>> GetAllAsync()
        {
            return await _context.Pegawai
                .Include(p => p.Cabang)
                .Include(p => p.Jabatan)
                .ToListAsync();
        }

        public async Task<Pegawai?> GetByIdAsync(int id)
        {
            return await _context.Pegawai
                .Include(p => p.Cabang)
                .Include(p => p.Jabatan)
                .FirstOrDefaultAsync(p => p.PegawaiID == id);
        }

        public async Task<Pegawai> CreateAsync(PegawaiDto pegawaiDto)
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
            return pegawai;
        }

        public async Task<bool> UpdateAsync(int id, PegawaiDto pegawaiDto)
        {
            if (id != pegawaiDto.PegawaiID)
            {
                return false;
            }

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
            pegawai.TanggalMasuk = pegawaiDto.TanggalMasuk;
            pegawai.StatusKontrak = pegawaiDto.StatusKontrak;
            pegawai.CabangID = pegawaiDto.CabangID;
            pegawai.JabatanID = pegawaiDto.JabatanID;

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

        public async Task<bool> DeleteAsync(int id)
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

        public async Task<BatchResult> ProcessBatchAsync(List<PegawaiDto> pegawaiDtos)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var dto in pegawaiDtos)
                    {
                        if (dto.PegawaiID > 0)
                        {
                            // Update
                            await UpdateAsync(dto.PegawaiID, dto);
                        }
                        else
                        {
                            // Create
                            await CreateAsync(dto);
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return new BatchResult { Success = true, Message = $"{pegawaiDtos.Count} records processed successfully." };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new BatchResult { Success = false, Message = $"An error occurred: {ex.Message}. No data was saved." };
                }
            }
        }
    }
}
