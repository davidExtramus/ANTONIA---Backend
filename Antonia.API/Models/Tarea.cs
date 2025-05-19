using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antonia.API.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        
        [Required]
        public string Titulo { get; set; } = string.Empty;
        
        public string? Descripcion { get; set; }
        
        public string Estado { get; set; } = "Pendiente"; // "Pendiente", "En Progreso", "Completada", "Cancelada"
        
        public string Prioridad { get; set; } = "Normal"; // "Baja", "Normal", "Alta", "Urgente"
        
        public DateTime FechaCreacion { get; set; }
        
        public DateTime FechaActualizacion { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        [Required]
        public int ProvinciaId { get; set; }
        
        [Required]
        public int RolId { get; set; }
        
        [Required]
        public int CreadoPorId { get; set; }
        
        public int? AsignadoAId { get; set; }
        
        // Propiedades de navegación
        [JsonIgnore]
        public Usuario Usuario { get; set; } = null!;
        
        [JsonIgnore]
        public Provincia Provincia { get; set; } = null!;
        
        [JsonIgnore]
        public Rol Rol { get; set; } = null!;
        
        [JsonIgnore]
        public Necesitado CreadoPor { get; set; } = null!;
        
        [JsonIgnore]
        public Voluntario? AsignadoA { get; set; }
        
        [JsonIgnore]
        public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }
} 