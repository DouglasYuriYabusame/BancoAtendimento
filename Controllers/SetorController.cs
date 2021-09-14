using BancoAtendimento.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : Controller
    {
        public Contexto Contexto;
        public SetorController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }
        [HttpGet]
        public List<Setor> Index()
        {
            return Contexto.Setores.ToList();
        }

        [HttpGet("{id}")]
        public Setor Get(int id)
        {
            return Contexto.Setores.First(e => e.Id == id);
        }

        [HttpGet("nome/{nome}")]
        public List<Setor> filtrar(String nome)
        {
            return Contexto.Setores.Where(e => e.nome == nome).ToList();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Setor>> Create(Setor Setor)
        {
            Setor.Id = 0;
            Contexto.Setores.Add(Setor);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Setor.Id, Setor });

        }
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Setor>> Update(Setor Setor)
        {
            Contexto.Setores.Update(Setor);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Setor.Id, Setor });

        }
        [HttpGet("delete/{id}")]
        public async Task<ActionResult<Setor>> Remove(int id)
        {
            var setor = Contexto.Setores.First(e => e.Id == id);
            Contexto.Setores.Remove(setor);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),new {id = setor.Id, setor.nome});

        }
    }
}
