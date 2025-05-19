using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaDto>>> GetTareas()
        {
            return await _context.Tareas
                .Select(t => new TareaDto {
                    Id = t.Id,
                    Descripcion = t.Descripcion,
                    Estado = t.Estado,
                    FechaHora = t.FechaHora,
                    Precio = t.Precio,
                    Direccion = t.Direccion,
                    ArchivoAdjunto = t.ArchivoAdjunto,
                    ProvinciaId = t.ProvinciaId,
                    RolId = t.RolId,
                    CreadoPorId = t.CreadoPorId,
                    AsignadoAId = t.AsignadoAId
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TareaDto>> GetTarea(int id)
        {
            var t = await _context.Tareas.FindAsync(id);
            if (t == null) return NotFound();
            return new TareaDto {
                Id = t.Id,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                FechaHora = t.FechaHora,
                Precio = t.Precio,
                Direccion = t.Direccion,
                ArchivoAdjunto = t.ArchivoAdjunto,
                ProvinciaId = t.ProvinciaId,
                RolId = t.RolId,
                CreadoPorId = t.CreadoPorId,
                AsignadoAId = t.AsignadoAId
            };
        }

        [HttpPost]
        public async Task<ActionResult<TareaDto>> PostTarea(TareaCreateDto dto)
        {
            var tarea = new Tarea {
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                FechaHora = dto.FechaHora,
                Precio = dto.Precio,
                Direccion = dto.Direccion,
                ArchivoAdjunto = dto.ArchivoAdjunto,
                ProvinciaId = dto.ProvinciaId,
                RolId = dto.RolId,
                CreadoPorId = dto.CreadoPorId,
                AsignadoAId = dto.AsignadoAId
            };
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, new TareaDto {
                Id = tarea.Id,
                Descripcion = tarea.Descripcion,
                Estado = tarea.Estado,
                FechaHora = tarea.FechaHora,
                Precio = tarea.Precio,
                Direccion = tarea.Direccion,
                ArchivoAdjunto = tarea.ArchivoAdjunto,
                ProvinciaId = tarea.ProvinciaId,
                RolId = tarea.RolId,
                CreadoPorId = tarea.CreadoPorId,
                AsignadoAId = tarea.AsignadoAId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, TareaCreateDto dto)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null) return NotFound();
            tarea.Descripcion = dto.Descripcion;
            tarea.Estado = dto.Estado;
            tarea.FechaHora = dto.FechaHora;
            tarea.Precio = dto.Precio;
            tarea.Direccion = dto.Direccion;
            tarea.ArchivoAdjunto = dto.ArchivoAdjunto;
            tarea.ProvinciaId = dto.ProvinciaId;
            tarea.RolId = dto.RolId;
            tarea.CreadoPorId = dto.CreadoPorId;
            tarea.AsignadoAId = dto.AsignadoAId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null) return NotFound();
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 