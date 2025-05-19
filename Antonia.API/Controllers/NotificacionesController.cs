using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NotificacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificacionDto>>> GetNotificaciones()
        {
            return await _context.Notificaciones
                .Select(n => new NotificacionDto {
                    Id = n.Id,
                    UsuarioId = n.UsuarioId,
                    TareaId = n.TareaId,
                    Mensaje = n.Mensaje,
                    Tipo = n.Tipo,
                    Leida = n.Leida,
                    Fecha = n.Fecha
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacionDto>> GetNotificacion(int id)
        {
            var n = await _context.Notificaciones.FindAsync(id);
            if (n == null) return NotFound();
            return new NotificacionDto {
                Id = n.Id,
                UsuarioId = n.UsuarioId,
                TareaId = n.TareaId,
                Mensaje = n.Mensaje,
                Tipo = n.Tipo,
                Leida = n.Leida,
                Fecha = n.Fecha
            };
        }

        [HttpPost]
        public async Task<ActionResult<NotificacionDto>> PostNotificacion(NotificacionCreateDto dto)
        {
            var notificacion = new Notificacion {
                UsuarioId = dto.UsuarioId,
                TareaId = dto.TareaId,
                Mensaje = dto.Mensaje,
                Tipo = dto.Tipo,
                Leida = dto.Leida,
                Fecha = dto.Fecha
            };
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNotificacion), new { id = notificacion.Id }, new NotificacionDto {
                Id = notificacion.Id,
                UsuarioId = notificacion.UsuarioId,
                TareaId = notificacion.TareaId,
                Mensaje = notificacion.Mensaje,
                Tipo = notificacion.Tipo,
                Leida = notificacion.Leida,
                Fecha = notificacion.Fecha
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacion(int id, NotificacionCreateDto dto)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null) return NotFound();
            notificacion.UsuarioId = dto.UsuarioId;
            notificacion.TareaId = dto.TareaId;
            notificacion.Mensaje = dto.Mensaje;
            notificacion.Tipo = dto.Tipo;
            notificacion.Leida = dto.Leida;
            notificacion.Fecha = dto.Fecha;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var notificacion = await _context.Notificaciones.FindAsync(id);
            if (notificacion == null) return NotFound();
            _context.Notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 