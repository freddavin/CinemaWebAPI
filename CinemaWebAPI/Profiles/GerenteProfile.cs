using AutoMapper;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<GerenteCreateViewModel, Gerente>();
            CreateMap<Gerente, GerenteReadViewModel>();
        }
    }
}
