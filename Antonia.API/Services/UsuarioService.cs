using Antonia.API.Dtos;
using Antonia.API.Models;
using Antonia.API.Repositories.Interfaces;
using Antonia.API.Services.Interfaces;
using Antonia.API.Helpers;

namespace Antonia.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(u => MapperHelper.ToDto(u));
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return usuario != null ? MapperHelper.ToDto(usuario) : null;
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto usuarioDto)
        {
            var usuario = MapperHelper.ToModel(usuarioDto);
            var createdUsuario = await _usuarioRepository.AddAsync(usuario);
            return MapperHelper.ToDto(createdUsuario);
        }

        public async Task<UsuarioDto> UpdateAsync(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado");

            MapperHelper.UpdateModel(usuario, usuarioDto);
            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
            return MapperHelper.ToDto(updatedUsuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<UsuarioDto?> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            return usuario != null ? MapperHelper.ToDto(usuario) : null;
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _usuarioRepository.ExistsByEmailAsync(email);
        }
    }
} 