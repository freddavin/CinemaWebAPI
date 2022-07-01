using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GerenteReadViewModel AdicionarGerente(GerenteCreateViewModel gerenteCreateViewModel)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteCreateViewModel);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<GerenteReadViewModel>(gerente);
        }

        public List<GerenteReadViewModel> RecuperarGerentes()
        {
            List<Gerente> gerentes = _context.Gerentes.ToList();
            if (gerentes != null)
            {
                List<GerenteReadViewModel> gerentesReadViewModel = _mapper.Map<List<GerenteReadViewModel>>(gerentes);
                return gerentesReadViewModel;
            }
            return null;
        }

        public GerenteReadViewModel RecuperarGerentePorId(int idGerente)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(g => g.Id == idGerente);
            if (gerente != null)
            {
                GerenteReadViewModel gerenteReadViewModel = _mapper.Map<GerenteReadViewModel>(gerente);
                return gerenteReadViewModel;
            }
            return null;
        }
    }
}
