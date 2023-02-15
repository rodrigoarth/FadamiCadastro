using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FadamiCadastroInfra.Entities
{
    [Table("Usuários")]
    public class Usuario : BaseEntity
    {

        [Required]
        [MaxLength(50, ErrorMessage = "{0} Não pode exceder {1} caracteres. ")]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "{0} Não pode exceder {1} caracteres. ")]
        public string? Login { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "{0} Deve conter {1} caracteres. ")]
        public string? CPF { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo {0} caracteres")]
        [MaxLength(20, ErrorMessage = "{0} Não pode exceder {1} caracteres. ")]
        public string? Senha { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime UltimoAcesso { get; set; }

        public int QtdErros { get; set; }

        public bool BloqueioAtivo { get; set; }


    }
}
