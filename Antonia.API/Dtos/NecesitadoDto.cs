namespace Antonia.API.Dtos
{
    public class NecesitadoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Observaciones { get; set; }
        public bool MovilidadReducida { get; set; }
        public bool NecesitaAcompaniamiento { get; set; }
        public bool PuedeLeer { get; set; }
        public bool AceptaLlamadas { get; set; }
        public string ContactoAlternativoNombre { get; set; }
        public string ContactoAlternativoTelefono { get; set; }
        public string Direccion { get; set; }
    }
    public class NecesitadoCreateDto
    {
        public int UsuarioId { get; set; }
        public string Observaciones { get; set; }
        public bool MovilidadReducida { get; set; }
        public bool NecesitaAcompaniamiento { get; set; }
        public bool PuedeLeer { get; set; }
        public bool AceptaLlamadas { get; set; }
        public string ContactoAlternativoNombre { get; set; }
        public string ContactoAlternativoTelefono { get; set; }
        public string Direccion { get; set; }
    }
} 