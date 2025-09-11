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
        public string Nome { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Celular é obrigatório")]
        public string Celular { get; set; }

    }
}
