using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        private readonly IConfiguration _config;
        private readonly PasswordHasher<Usuario> _hasher;

        public AuthController(AppDbContext contexto, IConfiguration config)
        {
            _contexto = contexto;
            _config = config;
            _hasher = new PasswordHasher<Usuario>();
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO dto, CancellationToken cancellationToken)
        {
            var usuario = await _contexto.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == dto.Correo, cancellationToken);

            if (usuario is null)
                return Unauthorized(new { error = "Credenciales invalidas." });

            var resultado = _hasher.VerifyHashedPassword(usuario, usuario.PasswordHash, dto.Password);
            if (resultado == PasswordVerificationResult.Failed)
                return Unauthorized(new { error = "Credenciales invalidas." });

            var token = GenerarToken(usuario);
            var expira = DateTime.UtcNow.AddHours(8);

            return Ok(new LoginResponseDTO
            {
                Token = token,
                ExpiraEn = expira,
                Usuario = new UsuarioInfoDTO
                {
                    Id = usuario.Id,
                    Correo = usuario.Correo,
                    NombreMostrado = usuario.NombreMostrado,
                    Rol = usuario.Rol
                }
            });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UsuarioInfoDTO>> Me(CancellationToken cancellationToken)
        {
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idClaim is null || !long.TryParse(idClaim, out var id))
                return Unauthorized();

            var usuario = await _contexto.Usuarios.FindAsync(new object[] { id }, cancellationToken);
            if (usuario is null)
                return Unauthorized();

            return Ok(new UsuarioInfoDTO
            {
                Id = usuario.Id,
                Correo = usuario.Correo,
                NombreMostrado = usuario.NombreMostrado,
                Rol = usuario.Rol
            });
        }

        private string GenerarToken(Usuario usuario)
        {
            var key = _config["Jwt:Key"] ?? "ReporterosDevSigningKey_AtLeast32CharsLong!!";
            var issuer = _config["Jwt:Issuer"] ?? "Reporteros";
            var audience = _config["Jwt:Audience"] ?? "Reporteros";

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Name, usuario.NombreMostrado),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
