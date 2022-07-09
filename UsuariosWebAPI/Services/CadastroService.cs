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
        private UserManager<CustomIdentityUser> _userManager;
        private IMapper _mapper;
        private EmailService _emailService;

        public CadastroService(UserManager<CustomIdentityUser> userManager, IMapper mapper, EmailService emailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
        }

        public Result CadastrarUsuario(UsuarioCreateViewModel usuarioNovo)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioNovo);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            var resultado = _userManager.CreateAsync(usuarioIdentity, usuarioNovo.Password).Result;

            var usuarioRoleResult = _userManager.AddToRoleAsync(usuarioIdentity, "regular").Result;
            
            if (resultado.Succeeded)
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
