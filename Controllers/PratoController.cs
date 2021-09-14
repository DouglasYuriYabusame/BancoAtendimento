using BancoAtendimento.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : Controller
    {

        public Contexto Contexto { get; set; }

        public PratoController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Prato> Get()
        {
            return Contexto.Prato.ToList();
        }

        [HttpGet("{id}")]
        public Prato Get(int id)
        {
            return Contexto.Prato.First(e => e.codigoprato == id);
        }

        [HttpGet("nome/{nome}")]
        public List<Prato> filtrar(String descricao)
        {
            return Contexto.Prato.Where(e => e.Descricao == descricao).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Prato>> Create(Prato Prato)
        {
            Prato.codigoprato = 0;
            Contexto.Prato.Add(Prato);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Prato.codigoprato, Prato });

        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Prato>> Update(Prato Prato)
        {

            Contexto.Prato.Update(Prato);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Prato.codigoprato, Prato });

        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<Prato>> Remove(int id)
        {

            Contexto.Prato.Remove(Contexto.Prato.First(e => e.codigoprato == id));
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), $"O id n°{id} foi removido");
        }
    }
}
