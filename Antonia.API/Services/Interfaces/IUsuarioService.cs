using Antonia.API.Dtos;
using Antonia.API.Models;

namespace Antonia.API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(int id);
        Task<UsuarioDto> CreateAsync(UsuarioDto usuarioDto);
        Task<UsuarioDto> UpdateAsync(int id, UsuarioDto usuarioDto);
        Task DeleteAsync(int id);
        Task<UsuarioDto?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
    }
} 