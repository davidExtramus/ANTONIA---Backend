using System.Collections.Generic;

namespace Antonia.API.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activa { get; set; } = true;

        // Relaciones
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
} 