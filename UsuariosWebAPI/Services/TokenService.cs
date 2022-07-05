using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosWebAPI.Models;

namespace UsuariosWebAPI.Services
{
    public class TokenService
    {
        public Token CriarToken(IdentityUser<int> usuario)
        {
            var atributosUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: atributosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.Now.AddHours(1)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);

        }
    }
}
