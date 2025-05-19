using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public VoluntariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioDto>>> GetVoluntarios()
        {
            return await _context.Voluntarios
                .Select(v => new VoluntarioDto {
                    Id = v.Id,
                    UsuarioId = v.UsuarioId,
                    Disponibilidad = v.Disponibilidad,
                    Experiencia = v.Experiencia,
                    AceptaEmergencias = v.AceptaEmergencias,
                    TieneVehiculo = v.TieneVehiculo,
                    PuedeLlamar = v.PuedeLlamar,
                    ArchivosVerificacion = v.ArchivosVerificacion
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoluntarioDto>> GetVoluntario(int id)
        {
            var v = await _context.Voluntarios.FindAsync(id);
            if (v == null) return NotFound();
            return new VoluntarioDto {
                Id = v.Id,
                UsuarioId = v.UsuarioId,
                Disponibilidad = v.Disponibilidad,
                Experiencia = v.Experiencia,
                AceptaEmergencias = v.AceptaEmergencias,
                TieneVehiculo = v.TieneVehiculo,
                PuedeLlamar = v.PuedeLlamar,
                ArchivosVerificacion = v.ArchivosVerificacion
            };
        }

        [HttpPost]
        public async Task<ActionResult<VoluntarioDto>> PostVoluntario(VoluntarioCreateDto dto)
        {
            var voluntario = new Voluntario {
                UsuarioId = dto.UsuarioId,
                Disponibilidad = dto.Disponibilidad,
                Experiencia = dto.Experiencia,
                AceptaEmergencias = dto.AceptaEmergencias,
                TieneVehiculo = dto.TieneVehiculo,
                PuedeLlamar = dto.PuedeLlamar,
                ArchivosVerificacion = dto.ArchivosVerificacion
            };
            _context.Voluntarios.Add(voluntario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVoluntario), new { id = voluntario.Id }, new VoluntarioDto {
                Id = voluntario.Id,
                UsuarioId = voluntario.UsuarioId,
                Disponibilidad = voluntario.Disponibilidad,
                Experiencia = voluntario.Experiencia,
                AceptaEmergencias = voluntario.AceptaEmergencias,
                TieneVehiculo = voluntario.TieneVehiculo,
                PuedeLlamar = voluntario.PuedeLlamar,
                ArchivosVerificacion = voluntario.ArchivosVerificacion
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoluntario(int id, VoluntarioCreateDto dto)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);
            if (voluntario == null) return NotFound();
            voluntario.UsuarioId = dto.UsuarioId;
            voluntario.Disponibilidad = dto.Disponibilidad;
            voluntario.Experiencia = dto.Experiencia;
            voluntario.AceptaEmergencias = dto.AceptaEmergencias;
            voluntario.TieneVehiculo = dto.TieneVehiculo;
            voluntario.PuedeLlamar = dto.PuedeLlamar;
            voluntario.ArchivosVerificacion = dto.ArchivosVerificacion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoluntario(int id)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);
            if (voluntario == null) return NotFound();
            _context.Voluntarios.Remove(voluntario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 