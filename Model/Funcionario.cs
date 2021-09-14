using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int CodigoSetor { get; set; }
    }
}
