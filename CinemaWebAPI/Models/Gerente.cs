using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CinemaWebAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<Cinema> CinemasGerenciados { get; set; }

    }
}
