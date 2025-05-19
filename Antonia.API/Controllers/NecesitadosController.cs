using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NecesitadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NecesitadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NecesitadoDto>>> GetNecesitados()
        {
            return await _context.Necesitados
                .Select(n => new NecesitadoDto {
                    Id = n.Id,
                    UsuarioId = n.UsuarioId,
                    Observaciones = n.Observaciones,
                    MovilidadReducida = n.MovilidadReducida,
                    NecesitaAcompaniamiento = n.NecesitaAcompaniamiento,
                    PuedeLeer = n.PuedeLeer,
                    AceptaLlamadas = n.AceptaLlamadas,
                    ContactoAlternativoNombre = n.ContactoAlternativoNombre,
                    ContactoAlternativoTelefono = n.ContactoAlternativoTelefono,
                    Direccion = n.Direccion
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NecesitadoDto>> GetNecesitado(int id)
        {
            var n = await _context.Necesitados.FindAsync(id);
            if (n == null) return NotFound();
            return new NecesitadoDto {
                Id = n.Id,
                UsuarioId = n.UsuarioId,
                Observaciones = n.Observaciones,
                MovilidadReducida = n.MovilidadReducida,
                NecesitaAcompaniamiento = n.NecesitaAcompaniamiento,
                PuedeLeer = n.PuedeLeer,
                AceptaLlamadas = n.AceptaLlamadas,
                ContactoAlternativoNombre = n.ContactoAlternativoNombre,
                ContactoAlternativoTelefono = n.ContactoAlternativoTelefono,
                Direccion = n.Direccion
            };
        }

        [HttpPost]
        public async Task<ActionResult<NecesitadoDto>> PostNecesitado(NecesitadoCreateDto dto)
        {
            var necesitado = new Necesitado {
                UsuarioId = dto.UsuarioId,
                Observaciones = dto.Observaciones,
                MovilidadReducida = dto.MovilidadReducida,
                NecesitaAcompaniamiento = dto.NecesitaAcompaniamiento,
                PuedeLeer = dto.PuedeLeer,
                AceptaLlamadas = dto.AceptaLlamadas,
                ContactoAlternativoNombre = dto.ContactoAlternativoNombre,
                ContactoAlternativoTelefono = dto.ContactoAlternativoTelefono,
                Direccion = dto.Direccion
            };
            _context.Necesitados.Add(necesitado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNecesitado), new { id = necesitado.Id }, new NecesitadoDto {
                Id = necesitado.Id,
                UsuarioId = necesitado.UsuarioId,
                Observaciones = necesitado.Observaciones,
                MovilidadReducida = necesitado.MovilidadReducida,
                NecesitaAcompaniamiento = necesitado.NecesitaAcompaniamiento,
                PuedeLeer = necesitado.PuedeLeer,
                AceptaLlamadas = necesitado.AceptaLlamadas,
                ContactoAlternativoNombre = necesitado.ContactoAlternativoNombre,
                ContactoAlternativoTelefono = necesitado.ContactoAlternativoTelefono,
                Direccion = necesitado.Direccion
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNecesitado(int id, NecesitadoCreateDto dto)
        {
            var necesitado = await _context.Necesitados.FindAsync(id);
            if (necesitado == null) return NotFound();
            necesitado.UsuarioId = dto.UsuarioId;
            necesitado.Observaciones = dto.Observaciones;
            necesitado.MovilidadReducida = dto.MovilidadReducida;
            necesitado.NecesitaAcompaniamiento = dto.NecesitaAcompaniamiento;
            necesitado.PuedeLeer = dto.PuedeLeer;
            necesitado.AceptaLlamadas = dto.AceptaLlamadas;
            necesitado.ContactoAlternativoNombre = dto.ContactoAlternativoNombre;
            necesitado.ContactoAlternativoTelefono = dto.ContactoAlternativoTelefono;
            necesitado.Direccion = dto.Direccion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNecesitado(int id)
        {
            var necesitado = await _context.Necesitados.FindAsync(id);
            if (necesitado == null) return NotFound();
            _context.Necesitados.Remove(necesitado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 