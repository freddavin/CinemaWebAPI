using CinemaWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaWebAPI.ViewModels
{
    public class CinemaCreateViewModel
    {
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo EnderecoId é obrigatório.")]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "O campo GerenteId é obrigatório.")]
        public int GerenteId { get; set; }

    }
}
