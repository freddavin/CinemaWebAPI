using AutoMapper;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CinemaCreateViewModel, Cinema>();
            CreateMap<Cinema, CinemaReadViewModel>()
                .ForMember(c => c.Sessoes, options => options
                .MapFrom(c => c.Sessoes.Select(
                    c => new { c.Id, c.Filme })));
        }
    }
}
