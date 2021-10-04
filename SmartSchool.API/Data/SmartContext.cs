using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {
        //base é o construtor do DbContext
        //No construtor do SmartConext passamos o options para nosso DbContext
        public SmartContext(DbContextOptions<SmartContext> options) : base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<Curso> Cursos { get; set;  }
        //Método para criar o vínculo aluno disciplina (1 - N)
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>().HasKey(h => new { h.AlunoId, h.DisciplinaId });

            builder.Entity<AlunoCurso>().HasKey(h => new { h.AlunoId, h.CursoId });

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Lauro",321, "Pereira"),
                    new Professor(2, "Roberto",123, "Silva"),
                    new Professor(3, "Ronaldo",654, "Garcia"),
                    new Professor(4, "Rodrigo",789, "Barbosa"),
                    new Professor(5, "Alexandre",951,"Peretti"),
                });

            builder.Entity<Curso>().HasData(new List<Curso> {
                new Curso(1, "Tecnologia da Informação"),
                new Curso(2, "Sistemas de Informação"),
                new Curso(3, "Ciências da Informação")
            });

            //builder.Entity<AlunoCurso>().HasData(new List<AlunoCurso>
            //{
            //    new AlunoCurso(1,1),
            //    new AlunoCurso(7,3),
            //    new AlunoCurso(2,2),
            //    new AlunoCurso(6,1),
            //    new AlunoCurso(3,3),
            //    new AlunoCurso(5,2),
            //    new AlunoCurso(4,1)
            //});

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1,null,1),
                    new Disciplina(2, "Física", 2,1,3),
                    new Disciplina(3, "Português", 3,null,3),
                    new Disciplina(4, "Inglês", 4,null,1),
                    new Disciplina(5, "Programação", 5, 1,2),
                    new Disciplina(6, "Matemática", 1,1,2),
                    new Disciplina(7, "Física", 2,1,3),
                    new Disciplina(8, "Português", 3,3,1),
                    new Disciplina(9, "Inglês", 4,null,3),
                    new Disciplina(10, "Programação", 5,2,2)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Marta", "Kent", "33225555",1, DateTime.Parse("05/09/2005")),
                    new Aluno(2, "Paula", "Isabela", "3354288",2,DateTime.Parse("04/01/2005")),
                    new Aluno(3, "Laura", "Antonia", "55668899",3, DateTime.Parse("11/10/2004")),
                    new Aluno(4, "Luiza", "Maria", "6565659",4, DateTime.Parse("05/12/2010")),
                    new Aluno(5, "Lucas", "Machado", "565685415",5, DateTime.Parse("03/12/2008")),
                    new Aluno(6, "Pedro", "Alvares", "456454545",6, DateTime.Parse("05/10/2006")),
                    new Aluno(7, "Paulo", "José", "9874512",7 , DateTime.Parse("07/07/2006"))
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });
        }
    }
}
