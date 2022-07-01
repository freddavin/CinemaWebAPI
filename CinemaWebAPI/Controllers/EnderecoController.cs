using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;
using CinemaWebAPI.Services;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] EnderecoCreateViewModel enderecoCreateViewModel)
        {
            EnderecoReadViewModel enderecoReadViewModel = _enderecoService.AdicionarEndereco(enderecoCreateViewModel);
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), 
                new { idEndereco = enderecoReadViewModel.Id }, enderecoReadViewModel);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            List<EnderecoReadViewModel>? enderecosReadViewModel = _enderecoService.RecuperarEnderecos();
            if (enderecosReadViewModel != null)
            {
                return Ok(enderecosReadViewModel);
            }
            return NotFound();
        }

        [HttpGet("{idEndereco}")]
        public IActionResult RecuperarEnderecoPorId(int idEndereco)
        {
            EnderecoReadViewModel enderecoReadViewModel = _enderecoService.RecuperarEnderecoPorId(idEndereco);
            if (enderecoReadViewModel != null)
            {
                return Ok(enderecoReadViewModel);
            }
            return NotFound();
        }


    }
}
