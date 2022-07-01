using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CinemaReadViewModel AdicionarCinema(CinemaCreateViewModel cinemaCreateViewModel)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaCreateViewModel);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<CinemaReadViewModel>(cinema);
        }

        internal List<CinemaReadViewModel> RecuperarCinemas(string nomeDoFilme)
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
                return cinemasReadViewModel;
            }
            return null;
        }

        internal CinemaReadViewModel RecuperarCinemaPorId(int idCinema)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == idCinema);
            if (cinema != null)
            {
                var cinemaReadViewModel = _mapper.Map<CinemaReadViewModel>(cinema);
                return cinemaReadViewModel;
            }
            return null;
        }
    }
}
