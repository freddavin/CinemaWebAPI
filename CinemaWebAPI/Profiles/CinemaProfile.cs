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
            CreateMap<Cinema, CinemaReadViewModel>();
        }
    }
}
