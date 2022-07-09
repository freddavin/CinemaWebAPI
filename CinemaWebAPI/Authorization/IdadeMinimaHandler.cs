using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CinemaWebAPI.Authorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            DateTime dataDeNascimento = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);
            var idadeObtida = DateTime.Today.Year - dataDeNascimento.Year;

            if (dataDeNascimento > DateTime.Today.AddYears(-idadeObtida))
            {
                idadeObtida--;
            }

            if (idadeObtida >= requirement.IdadeMinima)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
