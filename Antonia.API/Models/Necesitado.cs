using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Antonia.API.Models
{
    public class Necesitado
    {
        public int Id { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        public string ContactoAlternativoNombre { get; set; } = string.Empty;
        public string ContactoAlternativoTelefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool AceptaAyuda { get; set; } = true;
        public bool EsUrgente { get; set; } = false;
        public string Observaciones { get; set; } = string.Empty;
        public bool MovilidadReducida { get; set; } = false;
        public bool NecesitaAcompaniamiento { get; set; } = false;
        public bool PuedeLeer { get; set; } = true;
        public bool AceptaLlamadas { get; set; } = true;

        // Propiedades de navegación
        [JsonIgnore]
        public Usuario Usuario { get; set; } = null!;
        
        [JsonIgnore]
        public Cartera? Cartera { get; set; }
        
        [JsonIgnore]
        public ICollection<Tarea> TareasCreadas { get; set; } = new List<Tarea>();
    }
} 