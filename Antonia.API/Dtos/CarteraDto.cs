using System;

namespace Antonia.API.Dtos
{
    public class CarteraDto
    {
        public int Id { get; set; }
        public int NecesitadoId { get; set; }
        public decimal Saldo { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
    public class CarteraCreateDto
    {
        public int NecesitadoId { get; set; }
        public decimal Saldo { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
} 