using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        [Required(ErrorMessage = "O codigo é obrigatório")]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O tamanho do nome deve ser de 5 ate 50")]
        public string Nome { get; set; }

        [Column("preco")]
        [Required]
        public decimal Preco { get; set; }

        [Column("quantidade")]
        [Required]
        public decimal Quantidade { get; set; }

    }
}
