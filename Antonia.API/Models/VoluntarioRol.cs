using System;

namespace Antonia.API.Models
{
    public class VoluntarioRol
    {
        public int VoluntarioId { get; set; }
        public int RolId { get; set; }
        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;
        public string Observaciones { get; set; } = string.Empty;

        // Relaciones
        public Voluntario Voluntario { get; set; }
        public Rol Rol { get; set; }
    }
} 