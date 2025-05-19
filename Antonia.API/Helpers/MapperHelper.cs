using Antonia.API.Dtos;
using Antonia.API.Models;

namespace Antonia.API.Helpers
{
    public static class MapperHelper
    {
        public static UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                FechaNacimiento = usuario.FechaNacimiento,
                Direccion = usuario.Direccion,
                ProvinciaId = usuario.ProvinciaId,
                RolId = usuario.RolId
            };
        }

        public static Usuario ToModel(UsuarioDto dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Telefono = dto.Telefono,
                FechaNacimiento = dto.FechaNacimiento,
                Direccion = dto.Direccion,
                ProvinciaId = dto.ProvinciaId,
                RolId = dto.RolId
            };
        }

        public static void UpdateModel(Usuario model, UsuarioDto dto)
        {
            model.Nombre = dto.Nombre;
            model.Apellidos = dto.Apellidos;
            model.Email = dto.Email;
            model.Telefono = dto.Telefono;
            model.FechaNacimiento = dto.FechaNacimiento;
            model.Direccion = dto.Direccion;
            model.ProvinciaId = dto.ProvinciaId;
            model.RolId = dto.RolId;
        }
    }
} 