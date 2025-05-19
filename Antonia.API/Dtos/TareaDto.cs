using System;

namespace Antonia.API.Dtos
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Precio { get; set; }
        public string Direccion { get; set; }
        public string ArchivoAdjunto { get; set; }
        public int ProvinciaId { get; set; }
        public int RolId { get; set; }
        public int CreadoPorId { get; set; }
        public int? AsignadoAId { get; set; }
    }
    public class TareaCreateDto
    {
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Precio { get; set; }
        public string Direccion { get; set; }
        public string ArchivoAdjunto { get; set; }
        public int ProvinciaId { get; set; }
        public int RolId { get; set; }
        public int CreadoPorId { get; set; }
        public int? AsignadoAId { get; set; }
    }
} 