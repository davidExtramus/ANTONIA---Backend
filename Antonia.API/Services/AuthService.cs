using System.Security.Cryptography;
using System.Text;
using Antonia.API.Data;
using Antonia.API.Dtos;
using Antonia.API.Helpers;
using Antonia.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Antonia.API.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;

        public AuthService(ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        public async Task<AuthResponseDto> Register(RegisterDto registerDto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == registerDto.Email))
            {
                throw new Exception("El email ya está registrado");
            }

            var usuario = new Usuario
            {
                Nombre = registerDto.Nombre,
                Apellido = registerDto.Apellido,
                Email = registerDto.Email,
                Password = HashPassword(registerDto.Password),
                Rol = registerDto.Rol
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var token = _jwtHelper.GenerateJwtToken(usuario);

            return new AuthResponseDto
            {
                Token = token,
                Email = usuario.Email,
                Rol = usuario.Rol,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido
            };
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (usuario == null || !VerifyPassword(loginDto.Password, usuario.Password))
            {
                throw new Exception("Credenciales inválidas");
            }

            var token = _jwtHelper.GenerateJwtToken(usuario);

            return new AuthResponseDto
            {
                Token = token,
                Email = usuario.Email,
                Rol = usuario.Rol,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido
            };
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
} 