using SmartSchool.API.Helper;
using SmartSchool.API.Models;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        //o tipo que vai sero T deverá ser sempre uma classe
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        #region Alunos
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams,bool includeProfessor = false);
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplina(int id, bool includeProfessor = false);
        Aluno GetAlunosById(int id, bool includeProfessor = false);

        #endregion
        #region Professor
        Task<PageList<Professor>> GetAllProfessor(PageParams pageParams, bool includeAluno= false);
        Professor[] GetAllProfessorByDisciplina(int id, bool includeAluno = false);
        Professor GetProfessorById(int id, bool includeAluno = false);
        #endregion
    }
}
