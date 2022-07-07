using System.ComponentModel.DataAnnotations;

namespace UsuariosWebAPI.Requests
{
    public class SolicitarResetSenhaRequest
    {
        [Required]
        public int IdUsuario { get; set; }
    }
}
