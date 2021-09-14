using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
    [Table("setor")]
    public class Setor
    {
        [Key]
        [Column("codigosetor")]
        public Int32 Id { get; set; }
        [Column("nome")]
        public String nome { get; set; }

    }
}
