using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.v1.Dtos;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    
    //Defini a versão da WebApi
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository repo;
        private readonly IMapper mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        /// <summary>
        /// Método responsavel por retornar todos os Alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = repo.GetAllAlunos(true);
            return Ok(mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }
        /// <summary>
        /// Retorna Alunos pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = repo.GetAlunosById(id, true);
            return Ok(mapper.Map<AlunoDto>(aluno));
        }
        
        /// <summary>
        /// Método para salvar alunos novos
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var Aluno = mapper.Map<Aluno>(model);
            repo.Add(Aluno);
            if (repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}",mapper.Map<AlunoDto>(Aluno));
            return BadRequest("Deu merda com o Aluno mermão");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var Aluno = mapper.Map<Aluno>(model);
            var alunoRepo = repo.GetAlunosById(id);
            
            repo.Update(Aluno);
            if(repo.SaveChanges())
                return Created($"/api/aluno/{model.Id}", mapper.Map<Aluno>(alunoRepo));
            return BadRequest("Aluno não encontrado!");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var Aluno = mapper.Map<Aluno>(model);
            //AsNoTracking serve para que seja possível salvar o objeto após consultar ele no context
            //O context mantém ele basicamente em "memória" e se tu tenta atualizar ocorre erro, como se fosse um I/O
            //Ele basicamente não trava o recurso
            var alunoRepo = repo.GetAlunosById(id);
            
            repo.Update(Aluno);
            if (repo.SaveChanges())                
                return Created($"/api/aluno/{model.Id}",mapper.Map<AlunoDto>(alunoRepo));
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
