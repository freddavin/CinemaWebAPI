using System.ComponentModel.DataAnnotations;

namespace CinemaWebAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo EnderecoId é obrigatório.")]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O campo GerenteId é obrigatório.")]
        public int GerenteId { get; set; }
        public virtual Gerente Gerente { get; set; }
    }
}
