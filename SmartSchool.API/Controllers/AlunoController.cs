using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext context;

        public AlunoController(SmartContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Alunos);
        }
        [HttpGet("ById")]
        public IActionResult GetById(int Id)
        {
            return Ok(context.Alunos.FirstOrDefault(f => f.Id == Id)) ;
        }
        [HttpGet("ByName")]
        public IActionResult GetByName(string Nome, string Sobrenome)
        {
            return Ok(context.Alunos.Where(aluno => aluno.Nome.Contains(Nome) && aluno.Sobrenome.Contains(Sobrenome)));
        }
        [HttpPost]
        public IActionResult Post(Aluno Aluno)
        {
            context.Add(Aluno);
            context.SaveChanges();
            return Ok(Aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno Aluno)
        {
            var aluno = context.Alunos.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");
            context.Update(Aluno);
            context.SaveChanges();
            return Ok(Aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno Aluno)
        {
            //AsNoTracking serve para que seja possível salvar o objeto após consultar ele no context
            //O context mantém ele basicamente em "memória" e se tu tenta atualizar ocorre erro, como se fosse um I/O
            //Ele basicamente não trava o recurso
            var aluno = context.Alunos.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado!");
            context.Update(Aluno);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = context.Alunos.FirstOrDefault(f => f.Id == id);
            if(aluno == null)
                return BadRequest("Aluno não encontrado!");

            context.Remove(aluno);
            context.SaveChanges();
            return Ok();
        }
    }
}
