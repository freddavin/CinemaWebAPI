using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosWebAPI.Requests;

namespace UsuariosWebAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogarUsuario(LoginRequest loginRequest)
        {
            var resultado = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("O login falhou.");
        }
    }
}
