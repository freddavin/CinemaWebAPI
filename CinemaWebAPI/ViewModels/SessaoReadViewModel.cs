using CinemaWebAPI.Models;

namespace CinemaWebAPI.ViewModels
{
    public class SessaoReadViewModel
    {
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
