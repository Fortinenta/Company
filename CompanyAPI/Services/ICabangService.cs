using CompanyAPI.ViewModels;

namespace CompanyAPI.Services
{
    public interface ICabangService
    {
        Task<IEnumerable<CabangDto>> GetAllCabangAsync();
        Task<CabangDto?> GetCabangByIdAsync(int id);
        Task<CabangDto> CreateCabangAsync(CabangDto cabangDto);
        Task<bool> UpdateCabangAsync(int id, CabangDto cabangDto);
        Task<bool> DeleteCabangAsync(int id);
    }
}
