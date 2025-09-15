using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]        
        public required string Nome { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail informado é inválido")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "O Celular é obrigatório")]
        [Phone(ErrorMessage = "O Celular informado é inválido")]
        public required string Celular { get; set; }

    }
}
