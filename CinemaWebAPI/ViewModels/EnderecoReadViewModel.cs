using System.Text.Json.Serialization;
using CinemaWebAPI.Models;

namespace CinemaWebAPI.ViewModels
{
    public class EnderecoReadViewModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
