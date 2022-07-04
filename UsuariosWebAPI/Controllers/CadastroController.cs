using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosWebAPI.Services;
using UsuariosWebAPI.ViewModels;

namespace UsuariosWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CadastroController : ControllerBase
    {
        private CadastroService _serviceCadastro;

        public CadastroController(CadastroService serviceCadastro)
        {
            _serviceCadastro = serviceCadastro;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioCreateViewModel usuarioNovo)
        {
            Result resultadoCadastro = _serviceCadastro.CadastrarUsuario(usuarioNovo);
            if (resultadoCadastro.IsSuccess)
            {
                return Ok();
            }
            return StatusCode(500);
        }
    }
}
