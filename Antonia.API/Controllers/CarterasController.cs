using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antonia.API.Data;
using Antonia.API.Models;
using Antonia.API.Dtos;

namespace Antonia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarterasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CarterasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarteraDto>>> GetCarteras()
        {
            return await _context.Carteras
                .Select(c => new CarteraDto {
                    Id = c.Id,
                    NecesitadoId = c.NecesitadoId,
                    Saldo = c.Saldo,
                    UltimaActualizacion = c.UltimaActualizacion
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarteraDto>> GetCartera(int id)
        {
            var c = await _context.Carteras.FindAsync(id);
            if (c == null) return NotFound();
            return new CarteraDto {
                Id = c.Id,
                NecesitadoId = c.NecesitadoId,
                Saldo = c.Saldo,
                UltimaActualizacion = c.UltimaActualizacion
            };
        }

        [HttpPost]
        public async Task<ActionResult<CarteraDto>> PostCartera(CarteraCreateDto dto)
        {
            var cartera = new Cartera {
                NecesitadoId = dto.NecesitadoId,
                Saldo = dto.Saldo,
                UltimaActualizacion = dto.UltimaActualizacion
            };
            _context.Carteras.Add(cartera);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCartera), new { id = cartera.Id }, new CarteraDto {
                Id = cartera.Id,
                NecesitadoId = cartera.NecesitadoId,
                Saldo = cartera.Saldo,
                UltimaActualizacion = cartera.UltimaActualizacion
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartera(int id, CarteraCreateDto dto)
        {
            var cartera = await _context.Carteras.FindAsync(id);
            if (cartera == null) return NotFound();
            cartera.NecesitadoId = dto.NecesitadoId;
            cartera.Saldo = dto.Saldo;
            cartera.UltimaActualizacion = dto.UltimaActualizacion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartera(int id)
        {
            var cartera = await _context.Carteras.FindAsync(id);
            if (cartera == null) return NotFound();
            _context.Carteras.Remove(cartera);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 