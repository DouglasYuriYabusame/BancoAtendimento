using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
        
        [Table("prato")]
        public class Prato
        {
            [Key]
            [Required(ErrorMessage = "O Id é obrigatório")]
            [Column("codigoprato")]
            public int codigoprato { get; set; }

            [Column("descricao")]
            [Required]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "O tamanho do nome deve ser de 5 ate 50")]
            public string Descricao { get; set; }

            [Column("preco")]
            [Required]
            public decimal Preco { get; set; }            
        }    
}
