using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] GerenteCreateViewModel gerenteCreateViewModel)
        {
            var gerente = _mapper.Map<Gerente>(gerenteCreateViewModel);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerentePorId), new { idGerente = gerente.Id }, gerente);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperarGerentes()
        {
            return _context.Gerentes.ToList();
        }

        [HttpGet("{idGerente}")]
        public IActionResult RecuperarGerentePorId(int idGerente)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == idGerente);
            if (gerente != null)
            {
                var gerenteReadViewModel = _mapper.Map<GerenteReadViewModel>(gerente);
                return Ok(gerenteReadViewModel);
            }
            return NotFound();
        }

    }
}
