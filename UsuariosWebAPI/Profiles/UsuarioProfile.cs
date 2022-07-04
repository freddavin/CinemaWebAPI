using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.ViewModels;

namespace UsuariosWebAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioCreateViewModel, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
