﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
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
        private readonly IMapper mapper;

        public ProfessorController(IRepository repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Professor = repo.GetAllProfessor(true);

            return Ok(mapper.Map<IEnumerable<ProfessorDto>>(Professor));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = repo.GetProfessorById(id, true);
            return Ok(mapper.Map<ProfessorDto>(Professor));
        }
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var Professor = mapper.Map<Professor>(model);
            repo.Add(Professor);
            if(repo.SaveChanges())
                return Created($"/api/professor/{model.Id}", mapper.Map<ProfessorDto>(Professor));
            return BadRequest("Erro ao salvaro o Professor");

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professorRepo = repo.GetProfessorById(id,true);
            var Professor = mapper.Map<Professor>(model);

            repo.Update(Professor);
            if (repo.SaveChanges())
                return Created($"/api/professor/{model.Id}", mapper.Map<ProfessorDto>(Professor));
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
