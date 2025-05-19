namespace Antonia.API.Dtos
{
    public class VoluntarioDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public bool Disponibilidad { get; set; }
        public string Experiencia { get; set; }
        public bool AceptaEmergencias { get; set; }
        public bool TieneVehiculo { get; set; }
        public bool PuedeLlamar { get; set; }
        public string ArchivosVerificacion { get; set; }
    }
    public class VoluntarioCreateDto
    {
        public int UsuarioId { get; set; }
        public bool Disponibilidad { get; set; }
        public string Experiencia { get; set; }
        public bool AceptaEmergencias { get; set; }
        public bool TieneVehiculo { get; set; }
        public bool PuedeLlamar { get; set; }
        public string ArchivosVerificacion { get; set; }
    }
} 