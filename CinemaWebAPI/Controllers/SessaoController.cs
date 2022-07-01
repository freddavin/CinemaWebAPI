using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] SessaoCreateViewModel sessaoCreateViewModel)
        {
            var sessao = _mapper.Map<Sessao>(sessaoCreateViewModel);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new { idSessao = sessao.Id }, sessao);
        }

        [HttpGet]
        public IEnumerable<SessaoReadViewModel> RecuperarSessoes()
        {
            var sessoes = _context.Sessoes.ToList();
            var sessoesReadViewModel = _mapper.Map<List<SessaoReadViewModel>>(sessoes);
            return sessoesReadViewModel;
        }

        [HttpGet("{idSessao}")]
        public IActionResult RecuperarSessaoPorId(int idSessao)
        {
            var sessao = _context.Sessoes.FirstOrDefault(s => s.Id == idSessao);
            if (sessao != null)
            {
                var sessaoReadViewModel = _mapper.Map<SessaoReadViewModel>(sessao);
                return Ok(sessaoReadViewModel);
            }
            return NotFound();
        }
    }
}
