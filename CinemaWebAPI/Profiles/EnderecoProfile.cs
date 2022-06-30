using AutoMapper;
using CinemaWebAPI.Models;
using CinemaWebAPI.ViewModels;

namespace CinemaWebAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<EnderecoCreateViewModel, Endereco>();
            CreateMap<Endereco, EnderecoReadViewModel>();
        }
    }
}
