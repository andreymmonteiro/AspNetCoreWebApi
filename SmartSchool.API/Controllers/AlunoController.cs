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
        public readonly IRepository repo;

        public AlunoController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAllAlunos(true));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(repo.GetAlunosById(Id,true)) ;
        }
        
        [HttpPost]
        public IActionResult Post(Aluno Aluno)
        {
            repo.Add(Aluno);
            if (repo.SaveChanges())
                return Ok(Aluno);
            return BadRequest("Deu merda com o Aluno mermão");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno Aluno)
        {
            var aluno = repo.GetAlunosById(id);
            
            repo.Update(Aluno);
            if(repo.SaveChanges())
                return Ok(Aluno);
            return BadRequest("Aluno não encontrado!");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno Aluno)
        {
            //AsNoTracking serve para que seja possível salvar o objeto após consultar ele no context
            //O context mantém ele basicamente em "memória" e se tu tenta atualizar ocorre erro, como se fosse um I/O
            //Ele basicamente não trava o recurso
            var aluno = repo.GetAlunosById(id);
            
            repo.Update(Aluno);
            if (repo.SaveChanges())                
                return Ok();
            return BadRequest("Aluno não encontrado!");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = repo.GetAlunosById(id);
            
            repo.Delete(aluno);
            if (repo.SaveChanges())
                return Ok();
            return BadRequest("Aluno não encontrado!");
        }
    }
}
