using CompanyAPI.Models;
using CompanyAPI.Services;
using CompanyAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabangController : ControllerBase
    {
        private readonly ICabangService _cabangService;

        public CabangController(ICabangService cabangService)
        {
            _cabangService = cabangService;
        }

        // GET: api/Cabang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CabangDto>>> GetCabang()
        {
            var cabang = await _cabangService.GetAllCabangAsync();
            return Ok(cabang);
        }

        // GET: api/Cabang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CabangDto>> GetCabang(int id)
        {
            var cabang = await _cabangService.GetCabangByIdAsync(id);
            if (cabang == null)
            {
                return NotFound();
            }
            return Ok(cabang);
        }

        // PUT: api/Cabang/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabang(int id, CabangDto cabangDto)
        {
            if (id != cabangDto.CabangID)
            {
                return BadRequest();
            }

            var success = await _cabangService.UpdateCabangAsync(id, cabangDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Cabang
        [HttpPost]
        public async Task<ActionResult<CabangDto>> PostCabang(CabangDto cabangDto)
        {
            var createdCabang = await _cabangService.CreateCabangAsync(cabangDto);
            return CreatedAtAction("GetCabang", new { id = createdCabang.CabangID }, createdCabang);
        }

        // DELETE: api/Cabang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabang(int id)
        {
            var success = await _cabangService.DeleteCabangAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}