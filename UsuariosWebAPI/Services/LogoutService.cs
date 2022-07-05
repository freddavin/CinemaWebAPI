using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosWebAPI.Requests;

namespace UsuariosWebAPI.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signoutManager;

        public LogoutService(SignInManager<IdentityUser<int>> signoutManager)
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
