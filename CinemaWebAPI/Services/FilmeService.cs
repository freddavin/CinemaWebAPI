using AutoMapper;
using CinemaWebAPI.Context;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;
using FluentResults;

namespace CinemaWebAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FilmeReadViewModel AdicionarFilme(FilmeCreateViewModel filmeCreateViewModel)
        {
            Filme filme = _mapper.Map<Filme>(filmeCreateViewModel);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<FilmeReadViewModel>(filme);
        }

        public List<FilmeReadViewModel> RecuperarFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            if (filmes != null)
            {
                var filmesReadViewModel = _mapper.Map<List<FilmeReadViewModel>>(filmes);
                return filmesReadViewModel;
            }
            return null;
        }

        public FilmeReadViewModel RecuperarFilmePorId(int idFilme)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == idFilme);
            if (filme != null)
            {
                var filmeReadViewModel = _mapper.Map<FilmeReadViewModel>(filme);
                return filmeReadViewModel;
            }
            return null;
        }

        public Result AtualizarFilme(int idFilme, FilmeCreateViewModel filmeAlterado)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == idFilme);
            if (filme != null)
            {
                _mapper.Map(filmeAlterado, filme);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail($"Não existe o filme com o id: {idFilme}.");
        }

        public Result RemoverFilme(int idFilme)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == idFilme);
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail($"Não existe o filme com o id: {idFilme}.");
        }
    }
}
