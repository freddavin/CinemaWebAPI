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
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest loginRequest)
        {
            Result resultado = _service.LogarUsuario(loginRequest);
            if (resultado.IsSuccess)
            {
                return Ok();
            }
            return Unauthorized();
        }



    }
}
