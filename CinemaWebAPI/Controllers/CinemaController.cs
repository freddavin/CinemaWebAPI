﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarCinema([FromBody] CinemaCreateViewModel cinemaCreateViewModel)
        {
            var cinema = _mapper.Map<Cinema>(cinemaCreateViewModel);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCinemaPorId), new { idCinema = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            List<Cinema> cinemas;
            if (string.IsNullOrEmpty(nomeDoFilme))
            {
                cinemas = _context.Cinemas.ToList();
            }
            else
            {
                cinemas = _context.Sessoes
                    .Where(s => s.Filme.Titulo == nomeDoFilme)
                    .Select(s => s.Cinema)
                    .ToList();
            }
            if (cinemas != null)
            {
                var cinemasReadViewModel = _mapper.Map<List<CinemaReadViewModel>>(cinemas);
                return Ok(cinemasReadViewModel);
            }
            return NotFound();
        }

        [HttpGet("{idCinema}")]
        public IActionResult RecuperarCinemaPorId(int idCinema)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == idCinema);
            if (cinema != null)
            {
                var cinemaReadViewModel = _mapper.Map<CinemaReadViewModel>(cinema);
                return Ok(cinemaReadViewModel);
            }
            return NotFound();
        }


    }
}
