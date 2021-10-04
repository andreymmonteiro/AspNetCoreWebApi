using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext context;

        public Repository(SmartContext context)
        {
            this.context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = context.Alunos;

            if (includeProfessor)
                query = query.Include(i => i.AlunosDisciplinas)
                            .ThenInclude(i => i.Disciplina)
                            .ThenInclude(i => i.Professor);

            query = query.AsNoTracking().OrderBy(o => o.Id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplina(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> queryAlunos = context.Alunos;

            if (includeProfessor)
                queryAlunos = queryAlunos.Include(i => i.AlunosDisciplinas)
                                        .ThenInclude(i => i.Disciplina)
                                        .ThenInclude(i => i.Professor);

            queryAlunos = queryAlunos.AsNoTracking()
                                    .OrderBy(order => order.Id)
                                    .Where(alunos => alunos.AlunosDisciplinas.Any(alunoDisciplina => alunoDisciplina.DisciplinaId == id));
            
            return queryAlunos.ToArray();
        }

        public Aluno GetAlunosById(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> queryAlunos = context.Alunos;
            if (includeProfessor)
                queryAlunos = queryAlunos.Include(i => i.AlunosDisciplinas)
                                         .ThenInclude(i => i.Disciplina)
                                         .ThenInclude(i => i.Professor);
            return queryAlunos.AsNoTracking().FirstOrDefault(aluno => aluno.Id == id);
        }

        public Professor[] GetAllProfessor(bool includeAluno = false)
        {
            IQueryable<Professor> queryProfessor = context.Professores;
            if (includeAluno)
                queryProfessor = queryProfessor.Include(i => i.Disciplinas)
                                               .ThenInclude(i => i.AlunosDisciplinas)
                                               .ThenInclude(i => i.Aluno);
            return queryProfessor.AsNoTracking().OrderBy(order =>order.Id).ToArray();
        }

        public Professor[] GetAllProfessorByDisciplina(int id, bool includeAluno = false)
        {
            IQueryable<Professor> queryProfessor = context.Professores;
            if (includeAluno)
                queryProfessor = queryProfessor.Include(i => i.Disciplinas)
                                                .ThenInclude(i => i.AlunosDisciplinas)
                                                .ThenInclude(i => i.Aluno);

            return queryProfessor.AsNoTracking().Where(professor => professor.Disciplinas.Any(disciplina => disciplina.Id == id)).ToArray();
        }

        public Professor GetProfessorById(int id, bool includeAluno = false)
        {
            IQueryable<Professor> queryProfessor = context.Professores;
            if (includeAluno)
                queryProfessor = queryProfessor.Include(i => i.Disciplinas)
                                                .ThenInclude(i => i.AlunosDisciplinas)
                                                .ThenInclude(i => i.Aluno);
            return queryProfessor.AsNoTracking().FirstOrDefault(professor => professor.Id == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }
    }
}
