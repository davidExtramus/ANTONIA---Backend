using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDto>>> GetRoles()
        {
            return await _context.Roles
                .Select(r => new RolDto {
                    Id = r.Id,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Requerimientos = r.Requerimientos
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> GetRol(int id)
        {
            var r = await _context.Roles.FindAsync(id);
            if (r == null) return NotFound();
            return new RolDto {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Requerimientos = r.Requerimientos
            };
        }

        [HttpPost]
        public async Task<ActionResult<RolDto>> PostRol(RolCreateDto dto)
        {
            var rol = new Rol {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Requerimientos = dto.Requerimientos
            };
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, new RolDto {
                Id = rol.Id,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion,
                Requerimientos = rol.Requerimientos
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, RolCreateDto dto)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return NotFound();
            rol.Nombre = dto.Nombre;
            rol.Descripcion = dto.Descripcion;
            rol.Requerimientos = dto.Requerimientos;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null) return NotFound();
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 