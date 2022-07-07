using System.ComponentModel.DataAnnotations;

namespace UsuariosWebAPI.Requests
{
    public class AlterarSenhaUsuarioRequest
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string RePassword { get; set; }
        [Required]
        public string ChaveDeAlteracaoDeSenha { get; set; }

    }
}
