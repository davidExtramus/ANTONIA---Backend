using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioDto {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellido1 = u.Apellido1,
                    Apellido2 = u.Apellido2,
                    Email = u.Email,
                    TipoDocumento = u.TipoDocumento,
                    DocumentoIdentidad = u.DocumentoIdentidad,
                    Telefono = u.Telefono,
                    Tipo = u.Tipo,
                    EsAdministrador = u.EsAdministrador,
                    ProvinciaId = u.ProvinciaId,
                    FechaAlta = u.FechaAlta
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return NotFound();
            return new UsuarioDto {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido1 = u.Apellido1,
                Apellido2 = u.Apellido2,
                Email = u.Email,
                TipoDocumento = u.TipoDocumento,
                DocumentoIdentidad = u.DocumentoIdentidad,
                Telefono = u.Telefono,
                Tipo = u.Tipo,
                EsAdministrador = u.EsAdministrador,
                ProvinciaId = u.ProvinciaId,
                FechaAlta = u.FechaAlta
            };
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuario(UsuarioCreateDto dto)
        {
            var usuario = new Usuario {
                Nombre = dto.Nombre,
                Apellido1 = dto.Apellido1,
                Apellido2 = dto.Apellido2,
                Email = dto.Email,
                ContraseniaHash = dto.ContraseniaHash,
                TipoDocumento = dto.TipoDocumento,
                DocumentoIdentidad = dto.DocumentoIdentidad,
                Telefono = dto.Telefono,
                Tipo = dto.Tipo,
                EsAdministrador = dto.EsAdministrador,
                ProvinciaId = dto.ProvinciaId,
                FechaAlta = DateTime.UtcNow
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new UsuarioDto {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido1 = usuario.Apellido1,
                Apellido2 = usuario.Apellido2,
                Email = usuario.Email,
                TipoDocumento = usuario.TipoDocumento,
                DocumentoIdentidad = usuario.DocumentoIdentidad,
                Telefono = usuario.Telefono,
                Tipo = usuario.Tipo,
                EsAdministrador = usuario.EsAdministrador,
                ProvinciaId = usuario.ProvinciaId,
                FechaAlta = usuario.FechaAlta
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioCreateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            usuario.Nombre = dto.Nombre;
            usuario.Apellido1 = dto.Apellido1;
            usuario.Apellido2 = dto.Apellido2;
            usuario.Email = dto.Email;
            usuario.ContraseniaHash = dto.ContraseniaHash;
            usuario.TipoDocumento = dto.TipoDocumento;
            usuario.DocumentoIdentidad = dto.DocumentoIdentidad;
            usuario.Telefono = dto.Telefono;
            usuario.Tipo = dto.Tipo;
            usuario.EsAdministrador = dto.EsAdministrador;
            usuario.ProvinciaId = dto.ProvinciaId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
