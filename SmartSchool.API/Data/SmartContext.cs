using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {
        //base é o construtor do DbContext
        //No construtor do SmartConext passamos o options para nosso DbContext
        public SmartContext(DbContextOptions<SmartContext> options) :base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set;  }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        //Método para criar o vínculo aluno disciplina (1 - N)
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.Entity<AlunoDisciplina>().HasKey(h => new { h.AlunoId, h.DisciplinaId });
        }
    }
}
