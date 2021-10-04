using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository repo;

        public ProfessorController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetAllProfessor(true));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetProfessorById(id,true));
        }
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            repo.Add(Professor);
            if(repo.SaveChanges())
                return Ok(Professor);
            return BadRequest("Erro ao salvaro o Professor");

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var professor = repo.GetProfessorById(id,true);
            
            repo.Update(Professor);
            if (repo.SaveChanges())
                return Ok(professor);
            return BadRequest("Professor não encontrado");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var professor = repo.GetProfessorById(id);

            if (repo.SaveChanges())
                return Ok(professor);
            return BadRequest("Professor não encotrado");
        }

    }
}
