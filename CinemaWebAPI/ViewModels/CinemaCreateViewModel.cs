using CinemaWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CinemaWebAPI.ViewModels
{
    public class CinemaCreateViewModel
    {
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }

    }
}
