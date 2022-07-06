using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Web;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.Requests;
using UsuariosWebAPI.ViewModels;

namespace UsuariosWebAPI.Services
{
    public class CadastroService
    {
        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;
        private EmailService _emailService;

        public CadastroService(UserManager<IdentityUser<int>> userManager, IMapper mapper, EmailService emailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
        }

        public Result CadastrarUsuario(UsuarioCreateViewModel usuarioNovo)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioNovo);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultado = _userManager.CreateAsync(usuarioIdentity, usuarioNovo.Password);
            
            if (resultado.Result.Succeeded)
            {
                string codigoDeConfirmacao = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCodigo = HttpUtility.UrlEncode(codigoDeConfirmacao);
                _emailService.EnviarEmail(new[] {usuario.Email}, "Link de Ativação do e-mail", usuarioIdentity.Id, encodedCodigo);

                return Result.Ok().WithSuccess(codigoDeConfirmacao);
            }
            return Result.Fail("Falha ao cadastrar usuário.");
        }

        public Result AtivarUsuario(AtivarUsuarioRequest request)
        {
            var usuarioIdentity = _userManager.Users.FirstOrDefault(u => u.Id == request.IdUsuario);
            if (usuarioIdentity != null)
            {
                var resultadoIdentity = _userManager.ConfirmEmailAsync(usuarioIdentity, request.ChaveDeAtivacao);
                if (resultadoIdentity.Result.Succeeded)
                {
                    return Result.Ok();
                }
            }
            return Result.Fail("Não foi possível ativar o e-mail do usuario.");
        }
    }
}
