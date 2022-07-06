using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Text;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.Requests;

namespace UsuariosWebAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest loginRequest)
        {
            var resultado = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                    .First(u => u.NormalizedUserName == loginRequest.Username.ToUpper());
                Token token = _tokenService.CriarToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("O login falhou.");
        }
    }
}
