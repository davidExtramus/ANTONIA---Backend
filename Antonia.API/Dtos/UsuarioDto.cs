namespace Antonia.API.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string TipoDocumento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public bool EsAdministrador { get; set; }
        public int ProvinciaId { get; set; }
        public DateTime FechaAlta { get; set; }
    }

    public class UsuarioCreateDto
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string ContraseniaHash { get; set; }
        public string TipoDocumento { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public bool EsAdministrador { get; set; }
        public int ProvinciaId { get; set; }
    }
} 