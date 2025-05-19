using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antonia.API.Models
{
    public class Voluntario
    {
        public int Id { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        public bool Disponibilidad { get; set; }
        
        public bool AceptaEmergencias { get; set; }
        
        public bool TieneVehiculo { get; set; }
        
        public bool PuedeLlamar { get; set; }
        
        public string Experiencia { get; set; }
        public string ArchivosVerificacion { get; set; }

        // Propiedades de navegación
        [JsonIgnore]
        public Usuario Usuario { get; set; } = null!;
        
        [JsonIgnore]
        public ICollection<VoluntarioRol> VoluntarioRoles { get; set; } = new List<VoluntarioRol>();
        
        [JsonIgnore]
        public ICollection<Tarea> TareasAsignadas { get; set; } = new List<Tarea>();
    }
} 