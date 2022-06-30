using System.ComponentModel.DataAnnotations;

namespace CinemaWebAPI.ViewModels
{
    public class FilmeReadViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
