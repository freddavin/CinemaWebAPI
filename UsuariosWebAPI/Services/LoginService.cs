using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Web;
using UsuariosWebAPI.Models;
using UsuariosWebAPI.Requests;

namespace UsuariosWebAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest loginRequest)
        {
            var resultado = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                    .First(u => u.NormalizedUserName == loginRequest.Username.ToUpper());
                Token token = _tokenService.CriarToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("O login falhou.");
        }

        public Result SolicitarResetSenhaUsuario(SolicitarResetSenhaRequest request)
        {
            CustomIdentityUser? identityUser = RecuperarUsuarioPorId(request.IdUsuario);
            if (identityUser != null)
            {
                string chaveDeAlteracaoDeSenha = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(chaveDeAlteracaoDeSenha);
            }
            return Result.Fail("A solicitação de reset de senha falhou.");
        }

        public Result AlterarSenhaUsuario(AlterarSenhaUsuarioRequest request)
        {
            CustomIdentityUser? identityUser = RecuperarUsuarioPorId(request.IdUsuario);
            if (identityUser != null)
            {
                var resultadoIdentity = _signInManager.UserManager.ResetPasswordAsync(identityUser, request.ChaveDeAlteracaoDeSenha, request.NewPassword);
                if (resultadoIdentity.Result.Succeeded)
                {
                    return Result.Ok().WithSuccess("Senha redefinida com sucesso.");
                }
            }
            return Result.Fail("A alteração de senha falhou.");
        }

        private CustomIdentityUser? RecuperarUsuarioPorId(int idUsuario)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == idUsuario);
        }
    }
}
