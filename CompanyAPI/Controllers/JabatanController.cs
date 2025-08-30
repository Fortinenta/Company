using CompanyAPI.Models;
using CompanyAPI.Services;
using CompanyAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JabatanController : ControllerBase
    {
        private readonly IJabatanService _jabatanService;

        public JabatanController(IJabatanService jabatanService)
        {
            _jabatanService = jabatanService;
        }

        // GET: api/Jabatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JabatanDto>>> GetJabatan()
        {
            var jabatan = await _jabatanService.GetAllJabatanAsync();
            return Ok(jabatan);
        }

        // GET: api/Jabatan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JabatanDto>> GetJabatan(int id)
        {
            var jabatan = await _jabatanService.GetJabatanByIdAsync(id);
            if (jabatan == null)
            {
                return NotFound();
            }
            return Ok(jabatan);
        }

        // PUT: api/Jabatan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJabatan(int id, JabatanDto jabatanDto)
        {
            if (id != jabatanDto.JabatanID)
            {
                return BadRequest();
            }

            var success = await _jabatanService.UpdateJabatanAsync(id, jabatanDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Jabatan
        [HttpPost]
        public async Task<ActionResult<JabatanDto>> PostJabatan(JabatanDto jabatanDto)
        {
            var createdJabatan = await _jabatanService.CreateJabatanAsync(jabatanDto);
            return CreatedAtAction("GetJabatan", new { id = createdJabatan.JabatanID }, createdJabatan);
        }

        // DELETE: api/Jabatan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJabatan(int id)
        {
            var success = await _jabatanService.DeleteJabatanAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}