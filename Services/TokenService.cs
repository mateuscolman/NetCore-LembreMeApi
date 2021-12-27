using LembreMeApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LembreMeApi.Services
{
    public static class TokenService
    {
        public static string? BuscarChaveToken(string? token, string chave, bool obrigatorio = true)
        {
            var jwtInput = token.Replace("Bearer", string.Empty).Trim();
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(jwtInput);
            var chaveToken = jwtToken.Claims.FirstOrDefault(i => i.Type == chave)?.Value;

            if (obrigatorio && string.IsNullOrWhiteSpace(chaveToken))
                throw new UnauthorizedAccessException("Sessão de usuário ínvalida");

            return chaveToken;
        }

        public static string GenerateToken(UsuarioModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigCompartilhada.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim("Id", usuario.Id)
                }), 
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
