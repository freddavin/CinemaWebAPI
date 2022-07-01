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

    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CinemaCreateViewModel cinemaCreateViewModel)
        {
            CinemaReadViewModel cinemaReadViewModel = _cinemaService.AdicionarCinema(cinemaCreateViewModel);            
            return CreatedAtAction(nameof(RecuperarCinemaPorId), 
                new { idCinema = cinemaReadViewModel.Id }, cinemaReadViewModel);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<CinemaReadViewModel> cinemasReadViewModel = _cinemaService.RecuperarCinemas(nomeDoFilme);
            if (cinemasReadViewModel != null)
            {
                return Ok(cinemasReadViewModel);
            }
            return NotFound();
        }

        [HttpGet("{idCinema}")]
        public IActionResult RecuperarCinemaPorId(int idCinema)
        {
            CinemaReadViewModel cinemaReadViewModel = _cinemaService.RecuperarCinemaPorId(idCinema);
            if (cinemaReadViewModel != null)
            {
                return Ok(cinemaReadViewModel);
            }
            return NotFound();            
        }


    }
}
