using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public SessaoReadViewModel AdicionarSessao(SessaoCreateViewModel sessaoCreateViewModel)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoCreateViewModel);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<SessaoReadViewModel>(sessao);
        }

        public List<SessaoReadViewModel> RecuperarSessoes()
        {
            List<Sessao> sessoes = _context.Sessoes.ToList();
            if (sessoes != null)
            {
                List<SessaoReadViewModel> sessoesReadViewModel = _mapper.Map<List<SessaoReadViewModel>>(sessoes);
                return sessoesReadViewModel;
            }
            return null;
        }

        public SessaoReadViewModel RecuperarSessaoPorId(int idSessao)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(s => s.Id == idSessao);
            if (sessao != null)
            {
                var sessaoReadViewModel = _mapper.Map<SessaoReadViewModel>(sessao);
                return sessaoReadViewModel;
            }
            return null;
        }
    }
}
