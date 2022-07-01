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

    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] GerenteCreateViewModel gerenteCreateViewModel)
        {
            GerenteReadViewModel gerenteReadViewModel = _gerenteService.AdicionarGerente(gerenteCreateViewModel);
            return CreatedAtAction(nameof(RecuperarGerentePorId), 
                new { idGerente = gerenteReadViewModel.Id }, gerenteReadViewModel);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            List<GerenteReadViewModel> gerentesReadViewModel = _gerenteService.RecuperarGerentes();
            if (gerentesReadViewModel != null)
            {
                return Ok(gerentesReadViewModel);
            }
            return NotFound();
        }

        [HttpGet("{idGerente}")]
        public IActionResult RecuperarGerentePorId(int idGerente)
        {
            GerenteReadViewModel gerenteReadViewModel = _gerenteService.RecuperarGerentePorId(idGerente);
            if (gerenteReadViewModel != null)
            {
                return Ok(gerenteReadViewModel);
            }
            return NotFound();
        }

    }
}
