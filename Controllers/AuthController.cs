using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace GeometriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        // Usuario y contraseña fijos para autenticación
        private const string _usuarioPredeterminado = "admin";
        private const string _contrasenaPredeterminada = "1234";

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario credenciales)
        {
            // Validar usuario y contraseña fijos
            if (credenciales.NombreUsuario != _usuarioPredeterminado || credenciales.Contrasena != _contrasenaPredeterminada)
            {
                return Unauthorized("Credenciales inválidas");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, credenciales.NombreUsuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }

    // Clase simple para recibir credenciales en el login
    public class Usuario
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}
