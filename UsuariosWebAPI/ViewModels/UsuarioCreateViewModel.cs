using System.ComponentModel.DataAnnotations;

namespace UsuariosWebAPI.ViewModels
{
    public class UsuarioCreateViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public DateTime DataDeNascimento { get; set; }
    }
}
