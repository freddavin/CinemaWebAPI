using Microsoft.AspNetCore.Identity;

namespace UsuariosWebAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataDeNascimento { get; set; }
    }
}
