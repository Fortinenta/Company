using CompanyAPI.Models;
using CompanyAPI.Services;
using CompanyAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PegawaiController : ControllerBase
    {
        private readonly IPegawaiService _pegawaiService;

        public PegawaiController(IPegawaiService pegawaiService)
        {
            _pegawaiService = pegawaiService;
        }

        // GET: api/Pegawai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PegawaiDto>>> GetPegawai()
        {
            var pegawai = await _pegawaiService.GetAllPegawaiAsync();
            return Ok(pegawai);
        }

        // GET: api/Pegawai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PegawaiDto>> GetPegawai(int id)
        {
            var pegawai = await _pegawaiService.GetPegawaiByIdAsync(id);
            if (pegawai == null)
            {
                return NotFound();
            }
            return Ok(pegawai);
        }

        // PUT: api/Pegawai/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPegawai(int id, PegawaiDto pegawaiDto)
        {
            if (id != pegawaiDto.PegawaiID)
            {
                return BadRequest();
            }

            var success = await _pegawaiService.UpdatePegawaiAsync(id, pegawaiDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Pegawai
        [HttpPost]
        public async Task<ActionResult<PegawaiDto>> PostPegawai(PegawaiDto pegawaiDto)
        {
            var createdPegawai = await _pegawaiService.CreatePegawaiAsync(pegawaiDto);
            return CreatedAtAction("GetPegawai", new { id = createdPegawai.PegawaiID }, createdPegawai);
        }

        // DELETE: api/Pegawai/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePegawai(int id)
        {
            var success = await _pegawaiService.DeletePegawaiAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET: api/Pegawai/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PegawaiDto>>> SearchPegawai([FromQuery] string nama)
        {
            var pegawai = await _pegawaiService.SearchPegawaiAsync(nama);
            return Ok(pegawai);
        }
    }
}