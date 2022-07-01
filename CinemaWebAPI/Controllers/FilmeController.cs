using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] FilmeCreateViewModel filmeCreateViewModel)
        {
            var filme = _mapper.Map<Filme>(filmeCreateViewModel);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { idFilme = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            } else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            if (filmes != null)
            {
                var filmesReadViewModel = _mapper.Map<List<FilmeReadViewModel>>(filmes);
                return Ok(filmesReadViewModel);
            }
            return NotFound();

        }

        [HttpGet("{idFilme}")]
        public IActionResult RecuperarFilmePorId(int idFilme)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == idFilme);
            if (filme != null)
            {
                var filmeReadViewModel = _mapper.Map<FilmeReadViewModel>(filme);
                return Ok(filmeReadViewModel);
            }
            return NotFound();
        }

    }
}
