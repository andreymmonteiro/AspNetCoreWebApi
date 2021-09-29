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
        private readonly SmartContext context;

        public ProfessorController(SmartContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Professores);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var professor = context.Professores.FirstOrDefault(professor => professor.Id == id);
            return Ok(professor);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string Nome)
        {
            var professor = context.Professores.Where(professor => professor.Nome.Contains(Nome));
            return Ok(professor);
        }
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            context.Add(Professor);
            context.SaveChanges();
            return Ok(Professor);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var professor = context.Professores.AsNoTracking().FirstOrDefault(professor => professor.Id == id);
            if (professor == null)
                return BadRequest("Professor não encontrado");
            context.Update(Professor);

            return Ok(professor);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var professor = context.Professores.FirstOrDefault(professor => professor.Id == id);
            if (professor == null)
                BadRequest("Professor não encotrado");
            context.Remove(professor);
            return Ok();
        }

    }
}
