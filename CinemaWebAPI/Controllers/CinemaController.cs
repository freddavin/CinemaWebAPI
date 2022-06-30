using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IEnumerable<Cinema> RecuperarCinemas()
        {
            return _context.Cinemas.ToList();
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
