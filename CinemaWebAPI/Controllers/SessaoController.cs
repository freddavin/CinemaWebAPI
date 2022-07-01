using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.Services;
using CinemaWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] SessaoCreateViewModel sessaoCreateViewModel)
        {
            SessaoReadViewModel sessaoReadViewModel = _sessaoService.AdicionarSessao(sessaoCreateViewModel);
            return CreatedAtAction(nameof(RecuperarSessaoPorId), 
                new { idSessao = sessaoReadViewModel.Id }, sessaoReadViewModel);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            List<SessaoReadViewModel> sessoesReadViewList = _sessaoService.RecuperarSessoes();
            if (sessoesReadViewList != null)
            {
                return Ok(sessoesReadViewList);
            }
            return NotFound();
        }

        [HttpGet("{idSessao}")]
        public IActionResult RecuperarSessaoPorId(int idSessao)
        {
            SessaoReadViewModel sessaoReadViewModel = _sessaoService.RecuperarSessaoPorId(idSessao);
            if (sessaoReadViewModel != null)
            {
                return Ok(sessaoReadViewModel);
            }
            return NotFound();
        }
    }
}
