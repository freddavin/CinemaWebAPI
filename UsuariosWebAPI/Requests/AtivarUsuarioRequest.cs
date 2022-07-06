using System.ComponentModel.DataAnnotations;

namespace UsuariosWebAPI.Requests
{
    public class AtivarUsuarioRequest
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string ChaveDeAtivacao { get; set; }
    }
}
