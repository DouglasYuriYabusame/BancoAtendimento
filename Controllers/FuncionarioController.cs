using BancoAtendimento.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly Contexto _Contexto;
        public FuncionarioController(Contexto contexto)
        {
            _Contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<Funcionario>> Get()
        {            
            return Ok(await _Contexto.Funcionarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> Get(int id)
        {
            return Ok(await _Contexto.Funcionarios.FindAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Funcionario>> Create(Funcionario funcionario)
        {
            _Contexto.Funcionarios.Add(funcionario);
            await _Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Create),funcionario);
        }

        [HttpPut]
        public async Task<ActionResult<Funcionario>> Update(Funcionario funcionario)
        {
            _Contexto.Funcionarios.Update(funcionario);
            await _Contexto.SaveChangesAsync();
            return Ok(funcionario);
        }


        [HttpDelete]
        public async Task<ActionResult<Funcionario>> Remove(Funcionario funcionario)
        {
            _Contexto.Funcionarios.Remove(funcionario);
            await _Contexto.SaveChangesAsync();
            return Ok(funcionario);
        }
    }
}
