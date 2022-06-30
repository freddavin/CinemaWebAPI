using AutoMapper;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeCreateViewModel, Filme>();
            CreateMap<Filme, FilmeReadViewModel>();
        }
    }
}
