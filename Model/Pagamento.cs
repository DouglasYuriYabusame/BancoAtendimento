using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Key]
        [Column("codigopagamento")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public Int32 CodigoPagamento { get; set; }
        [Column("codigopedido")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public Int32 CodigoPedido { get; set; }
        [Column("valorpago")]
        public Decimal ValorPago { get; set; }



    }
}
