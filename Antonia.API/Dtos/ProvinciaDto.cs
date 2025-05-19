namespace Antonia.API.Dtos
{
    public class ProvinciaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public string Descripcion { get; set; }
    }
    public class ProvinciaCreateDto
    {
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public string Descripcion { get; set; }
    }
} 