using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EnderecoReadViewModel AdicionarEndereco(EnderecoCreateViewModel enderecoCreateViewModel)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoCreateViewModel);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<EnderecoReadViewModel>(endereco);
        }

        public List<EnderecoReadViewModel> RecuperarEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if (enderecos != null)
            {
                List<EnderecoReadViewModel> enderecosReadViewModel = _mapper.Map<List<EnderecoReadViewModel>>(enderecos);
                return enderecosReadViewModel;
            }
            return null;
        }

        public EnderecoReadViewModel RecuperarEnderecoPorId(int idEndereco)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(e => e.Id == idEndereco);
            if (endereco != null)
            {
                EnderecoReadViewModel enderecoReadViewModel = _mapper.Map<EnderecoReadViewModel>(endereco);
                return enderecoReadViewModel;
            }
            return null;
        }
    }
}
