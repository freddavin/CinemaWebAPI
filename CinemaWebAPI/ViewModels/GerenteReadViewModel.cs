using CinemaWebAPI.Models;

namespace CinemaWebAPI.ViewModels
{
    public class GerenteReadViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual List<Cinema> CinemasGerenciados { get; set; }

    }
}
