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
            CreateMap<Gerente, GerenteReadViewModel>()
                .ForMember(g => g.CinemasGerenciados, options => options
                .MapFrom(g => g.CinemasGerenciados.Select(
                    c => new { c.Id, c.Nome, c.EnderecoId, c.Endereco })));
        }
    }
}
