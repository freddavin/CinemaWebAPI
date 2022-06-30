using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarEndereco([FromBody] EnderecoCreateViewModel enderecoCreateViewModel)
        {
            var endereco = _mapper.Map<Endereco>(enderecoCreateViewModel);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEnderecoPorId), new { idEndereco = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<EnderecoReadViewModel> RecuperarEnderecos()
        {
            var enderecos = _context.Enderecos.ToList();
            var enderecosReadViewModel = _mapper.Map<List<EnderecoReadViewModel>>(enderecos);
            return enderecosReadViewModel;
        }

        [HttpGet("{idEndereco}")]
        public IActionResult RecuperarEnderecoPorId(int idEndereco)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == idEndereco);
            if (endereco != null)
            {
                var enderecoReadViewModel = _mapper.Map<EnderecoReadViewModel>(endereco);
                return Ok(enderecoReadViewModel);
            }
            return NotFound();
        }


    }
}
