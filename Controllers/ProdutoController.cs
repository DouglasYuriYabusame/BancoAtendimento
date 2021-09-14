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
    public class ProdutoController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public ProdutoController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return Contexto.Produtos.ToList();
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return Contexto.Produtos.First(e => e.Codigo == id);
        }

        [HttpGet("nome/{nome}")]
        public List<Produto> Filtrar(String nome)
        {
            return Contexto.Produtos.Where(e => e.Nome == nome).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Produto>> Create(Produto Produto)
        {
            Produto.Codigo = 0;
            Contexto.Produtos.Add(Produto);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Produto.Codigo, Produto });

        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Produto>> Update(Produto Produto)
        {

            Contexto.Produtos.Update(Produto);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Produto.Codigo, Produto });

        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<Produto>> Remove(int id)
        {

            Contexto.Produtos.Remove(Contexto.Produtos.First(e => e.Codigo == id));
            await Contexto.SaveChangesAsync();
            return RedirectToAction("Get");
        }
    }
}
