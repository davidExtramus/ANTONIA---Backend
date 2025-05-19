namespace Antonia.API.Dtos
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Requerimientos { get; set; }
    }
    public class RolCreateDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Requerimientos { get; set; }
    }
} 