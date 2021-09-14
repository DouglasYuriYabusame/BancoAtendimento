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
    public class ClienteController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public ClienteController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return Contexto.Clientes.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return Contexto.Clientes.First(e => e.CodigoCliente == id);
        }

        [HttpGet("nome/{nome}")]
        public List<Cliente> filtrar(String nome)
        {
            return Contexto.Clientes.Where(e => e.Nome == nome).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Cliente>> Create(Cliente Cliente)
        {
            Cliente.CodigoCliente = 0;
            Contexto.Clientes.Add(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.CodigoCliente, Cliente });

        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Cliente>> Update(Cliente Cliente)
        {

            Contexto.Clientes.Update(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.CodigoCliente, Cliente });

        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult<Cliente>> Remove(int id)
        {

            Contexto.Clientes.Remove(Contexto.Clientes.First(e => e.CodigoCliente == id));
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), $"O id n°{id} foi removido");
        }
    }

}