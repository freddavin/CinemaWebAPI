using CinemaWebAPI.Services;
using CinemaWebAPI.ViewModels;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarFilme([FromBody] FilmeCreateViewModel filmeCreateViewModel)
        {
            FilmeReadViewModel filmeReadViewModel = _filmeService.AdicionarFilme(filmeCreateViewModel);
            return CreatedAtAction(nameof(RecuperarFilmePorId), 
                new { idFilme = filmeReadViewModel.Id }, filmeReadViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<FilmeReadViewModel> filmeReadViewModel = _filmeService.RecuperarFilmes(classificacaoEtaria);
            if (filmeReadViewModel != null)
            {
                return Ok(filmeReadViewModel);
            }
            return NotFound();
        }

        [HttpGet("{idFilme}")]
        public IActionResult RecuperarFilmePorId(int idFilme)
        {
            FilmeReadViewModel filmeReadViewModel = _filmeService.RecuperarFilmePorId(idFilme);
            if (filmeReadViewModel != null)
            {
                return Ok(filmeReadViewModel);
            }
            return NotFound();
        }

        [HttpPut("{idFilme}")]
        public IActionResult AtualizarFilme(int idFilme, [FromBody] FilmeCreateViewModel filmeAlterado)
        {
            Result resultadoAlteracao = _filmeService.AtualizarFilme(idFilme, filmeAlterado);
            if (resultadoAlteracao.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{idFilme}")]
        public IActionResult RemoverFilme(int idFilme)
        {
            Result resultadoRemocao = _filmeService.RemoverFilme(idFilme);
            if (resultadoRemocao.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
