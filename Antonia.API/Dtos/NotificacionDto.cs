using System;

namespace Antonia.API.Dtos
{
    public class NotificacionDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TareaId { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public bool Leida { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class NotificacionCreateDto
    {
        public int UsuarioId { get; set; }
        public int TareaId { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public bool Leida { get; set; }
        public DateTime Fecha { get; set; }
    }
} 