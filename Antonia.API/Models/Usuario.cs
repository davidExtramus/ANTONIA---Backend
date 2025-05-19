using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Antonia.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido1 { get; set; } = string.Empty;

        public string Apellido2 { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required]
        public string DocumentoIdentidad { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty; // "Necesitado", "Voluntario", "Administrador"

        public bool EsAdministrador { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        // Relaciones
        public Voluntario Voluntario { get; set; }
        public Necesitado Necesitado { get; set; }
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
        public ICollection<Cartera> Carteras { get; set; } = new List<Cartera>();
        public ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }
} 