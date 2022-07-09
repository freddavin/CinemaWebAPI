using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.Requests;

namespace UsuariosWebAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signoutManager;

        public LogoutService(SignInManager<CustomIdentityUser> signoutManager)
        {
            _signoutManager = signoutManager;
        }

        public Result DeslogarUsuario()
        {
            var resultado = _signoutManager.SignOutAsync();
            if (resultado.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }
            return Result.Fail("O logout falhou.");

        }
    }
}
