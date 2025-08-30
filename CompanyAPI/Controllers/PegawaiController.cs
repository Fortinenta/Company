using CompanyAPI.Models;
using CompanyAPI.Services;
using CompanyAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<PegawaiDto>>> GetPegawais()
        {
            var pegawais = await _pegawaiService.GetAllAsync();
            var dtos = pegawais.Select(p => new PegawaiDto(p)); // Assuming a constructor mapping
            return Ok(dtos);
        }

        // GET: api/Pegawai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PegawaiDto>> GetPegawai(int id)
        {
            var pegawai = await _pegawaiService.GetByIdAsync(id);

            if (pegawai == null)
            {
                return NotFound();
            }

            return new PegawaiDto(pegawai);
        }

        // PUT: api/Pegawai/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPegawai(int id, PegawaiDto pegawaiDto)
        {
            if (id != pegawaiDto.PegawaiID)
            {
                return BadRequest();
            }

            var result = await _pegawaiService.UpdateAsync(id, pegawaiDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Pegawai
        [HttpPost]
        public async Task<ActionResult<PegawaiDto>> PostPegawai(PegawaiDto pegawaiDto)
        {
            var newPegawai = await _pegawaiService.CreateAsync(pegawaiDto);
            var newPegawaiDto = new PegawaiDto(newPegawai);
            return CreatedAtAction(nameof(GetPegawai), new { id = newPegawai.PegawaiID }, newPegawaiDto);
        }

        // DELETE: api/Pegawai/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePegawai(int id)
        {
            var result = await _pegawaiService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("batch")]
        public async Task<IActionResult> ProcessBatch([FromBody] List<PegawaiDto> pegawaiDtos)
        {
            if (pegawaiDtos == null || !pegawaiDtos.Any())
            {
                return BadRequest("No data provided.");
            }

            var result = await _pegawaiService.ProcessBatchAsync(pegawaiDtos);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
