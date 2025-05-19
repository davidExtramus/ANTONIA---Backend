using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProvinciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinciaDto>>> GetProvincias()
        {
            return await _context.Provincias
                .Select(p => new ProvinciaDto {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    CodigoPostal = p.CodigoPostal,
                    Descripcion = p.Descripcion
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinciaDto>> GetProvincia(int id)
        {
            var p = await _context.Provincias.FindAsync(id);
            if (p == null) return NotFound();
            return new ProvinciaDto {
                Id = p.Id,
                Nombre = p.Nombre,
                CodigoPostal = p.CodigoPostal,
                Descripcion = p.Descripcion
            };
        }

        [HttpPost]
        public async Task<ActionResult<ProvinciaDto>> PostProvincia(ProvinciaCreateDto dto)
        {
            var provincia = new Provincia {
                Nombre = dto.Nombre,
                CodigoPostal = dto.CodigoPostal,
                Descripcion = dto.Descripcion
            };
            _context.Provincias.Add(provincia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProvincia), new { id = provincia.Id }, new ProvinciaDto {
                Id = provincia.Id,
                Nombre = provincia.Nombre,
                CodigoPostal = provincia.CodigoPostal,
                Descripcion = provincia.Descripcion
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, ProvinciaCreateDto dto)
        {
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null) return NotFound();
            provincia.Nombre = dto.Nombre;
            provincia.CodigoPostal = dto.CodigoPostal;
            provincia.Descripcion = dto.Descripcion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvincia(int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null) return NotFound();
            _context.Provincias.Remove(provincia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 