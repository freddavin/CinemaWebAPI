using Microsoft.AspNetCore.Mvc;
using UsuariosWebAPI.Services;

namespace UsuariosWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LogoutController : ControllerBase
    {
        private LogoutService _serviceLogout;

        public LogoutController(LogoutService serviceLogout)
        {
            _serviceLogout = serviceLogout;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            var resultado = _serviceLogout.DeslogarUsuario();
            if (resultado.IsSuccess)
            {
                return Ok(resultado.Successes.FirstOrDefault());
            }
            return Unauthorized(resultado.Errors.FirstOrDefault());
        }


    }
}
