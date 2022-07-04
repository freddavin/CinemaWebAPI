using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosWebAPI.Context;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.ViewModels;

namespace UsuariosWebAPI.Services
{
    public class CadastroService
    {
        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;

        public CadastroService(UserManager<IdentityUser<int>> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Result CadastrarUsuario(UsuarioCreateViewModel usuarioNovo)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioNovo);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultado = _userManager.CreateAsync(usuarioIdentity, usuarioNovo.Password);
            
            if (resultado.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao cadastrar usuário.");
        }

    }
}
