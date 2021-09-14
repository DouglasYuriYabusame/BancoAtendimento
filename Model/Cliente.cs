using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "O codigo é obrigatório")]
        [Column("codigocliente")]
        public Int32 CodigoCliente { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O tamanho do nome deve ser de 5 ate 50")]
        public string Nome { get; set; }

        [Column("email")]
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O tamanho do nome deve ser de 5 ate 50")]
        public string Email { get; set; }

        [Column("senha")]
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O tamanho do nome deve ser de 5 ate 50")]
        public string Senha { get; set; }
    }
}