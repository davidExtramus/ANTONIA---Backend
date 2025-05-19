using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antonia.API.Models
{
    public class Cartera
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; } = 0;
        public string Estado { get; set; } = "Activa"; // "Activa", "Inactiva", "Bloqueada"
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaActualizacion { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        // Relaciones
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int NecesitadoId { get; set; }

        // Propiedades de navegación
        [JsonIgnore]
        public Usuario Usuario { get; set; } = null!;
        [JsonIgnore]
        public Necesitado Necesitado { get; set; } = null!;
    }
} 