using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosWebAPI.Requests;
using UsuariosWebAPI.Services;

namespace UsuariosWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService service)
        {
            _loginService = service;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest loginRequest)
        {
            Result resultado = _loginService.LogarUsuario(loginRequest);
            if (resultado.IsSuccess)
            {
                return Ok(resultado.Successes.FirstOrDefault());
            }
            return Unauthorized(resultado.Errors.FirstOrDefault());
        }



    }
}
