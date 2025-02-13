using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace APIAbank
{
    public class JwtService
    {

        private readonly string _secretKey = "una_clave_256_bits_o_mas_que_debe_tener_32_bytes_1234"; // Debe ser una clave secreta robusta

        public string GenerateJwtToken(string username)
        {
            // Reclamaciones que incluirá el token
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "usuario") // O cualquier otro rol que tu aplicación necesite
        };

            // Crear la clave secreta para firmar el token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            // Credenciales de firma
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crear el JWT
            var token = new JwtSecurityToken(
                issuer: "mi_api", // Quien emite el token
                audience: "mi_cliente", // A quién va dirigido el token
                claims: claims,  // Las claims (información) del token
                expires: DateTime.Now.AddHours(1), // Expira en 1 hora
                signingCredentials: credentials // Firmado con las credenciales
            );

            // Retornar el token en formato de cadena
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
