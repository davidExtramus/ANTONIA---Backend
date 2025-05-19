using System.Collections.Generic;

namespace Antonia.API.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        public ICollection<VoluntarioRol> VoluntarioRoles { get; set; } = new List<VoluntarioRol>();
    }
} 