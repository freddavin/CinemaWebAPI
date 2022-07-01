using AutoMapper;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<SessaoCreateViewModel, Sessao>();
            CreateMap<Sessao, SessaoReadViewModel>();
        }
    }
}
