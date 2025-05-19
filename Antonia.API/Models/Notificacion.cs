using System;

namespace Antonia.API.Models
{
    public class Notificacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaLectura { get; set; }
        public bool Leida { get; set; } = false;
        public string Tipo { get; set; } = "General"; // "General", "Tarea", "Sistema", "Urgente"
        public string Prioridad { get; set; } = "Normal"; // "Baja", "Normal", "Alta"

        // Relaciones
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int? TareaId { get; set; }
        public Tarea Tarea { get; set; }
    }
} 