using CinemaWebAPI.Models;

namespace CinemaWebAPI.ViewModels
{
    public class CinemaReadViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Gerente Gerente { get; set; }

        public virtual object Sessoes { get; set; }
    }
}
