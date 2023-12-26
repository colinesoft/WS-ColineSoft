using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.WebAPI.Configuration;

namespace WS_ColineSoft.WebAPI.Service
{
    public class TokenService
    {
        public static object GenerateToken(UsuarioDTO usuario)
        {
            //obtem a chave privada (secreta)
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            //configura o token
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim("Id", usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //gera o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenStr = tokenHandler.WriteToken(token);

            return new
            {
                Token = tokenStr,
                Expires = tokenConfig.Expires
            };
        }
    }
}
