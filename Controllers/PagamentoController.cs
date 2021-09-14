using BancoAtendimento.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BancoAtendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {

        public Contexto Contexto { get; set; }
        public PagamentoController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;


        }


        [HttpGet]
        public List<Pagamento> Get()
        {
            return Contexto.Pagamentos.ToList();
        }


        [HttpGet("{id}")]
        public Pagamento Get(int id)
        {
            return Contexto.Pagamentos.First(e => e.CodigoPagamento == id);
        }

        
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Pagamento>> Create(Pagamento Pagamento)
        {
           Pagamento.CodigoPagamento = 0;
            Contexto.Pagamentos.Add(Pagamento);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Pagamento.CodigoPagamento, Pagamento });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Pagamento>> Update(Pagamento Pagamento)
        {
            Contexto.Pagamentos.Update(Pagamento);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Pagamento.CodigoPagamento, Pagamento });
        }

        [HttpDelete]
        public async Task<ActionResult<Pagamento>> Delete(Pagamento Pagamento)
        {
            Contexto.Pagamentos.Remove(Pagamento);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Pagamento.CodigoPagamento, Pagamento });
        }








    }

}
