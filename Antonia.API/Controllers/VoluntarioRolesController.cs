using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntarioRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VoluntarioRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioRolDto>>> GetVoluntarioRoles()
        {
            return await _context.VoluntarioRoles
                .Select(vr => new VoluntarioRolDto {
                    VoluntarioId = vr.VoluntarioId,
                    RolId = vr.RolId
                })
                .ToListAsync();
        }

        [HttpGet("{voluntarioId}/{rolId}")]
        public async Task<ActionResult<VoluntarioRolDto>> GetVoluntarioRol(int voluntarioId, int rolId)
        {
            var vr = await _context.VoluntarioRoles.FindAsync(voluntarioId, rolId);
            if (vr == null) return NotFound();
            return new VoluntarioRolDto {
                VoluntarioId = vr.VoluntarioId,
                RolId = vr.RolId
            };
        }

        [HttpPost]
        public async Task<ActionResult<VoluntarioRolDto>> PostVoluntarioRol(VoluntarioRolCreateDto dto)
        {
            var voluntarioRol = new VoluntarioRol {
                VoluntarioId = dto.VoluntarioId,
                RolId = dto.RolId
            };
            _context.VoluntarioRoles.Add(voluntarioRol);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVoluntarioRol), new { voluntarioId = voluntarioRol.VoluntarioId, rolId = voluntarioRol.RolId }, new VoluntarioRolDto {
                VoluntarioId = voluntarioRol.VoluntarioId,
                RolId = voluntarioRol.RolId
            });
        }

        [HttpDelete("{voluntarioId}/{rolId}")]
        public async Task<IActionResult> DeleteVoluntarioRol(int voluntarioId, int rolId)
        {
            var voluntarioRol = await _context.VoluntarioRoles.FindAsync(voluntarioId, rolId);
            if (voluntarioRol == null) return NotFound();
            _context.VoluntarioRoles.Remove(voluntarioRol);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 