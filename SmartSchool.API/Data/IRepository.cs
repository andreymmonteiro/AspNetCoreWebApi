using SmartSchool.API.Models;

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
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplina(int id, bool includeProfessor = false);
        Aluno GetAlunosById(int id, bool includeProfessor = false);

        #endregion
        #region Professor
        Professor[] GetAllProfessor(bool includeAluno= false);
        Professor[] GetAllProfessorByDisciplina(int id, bool includeAluno = false);
        Professor GetProfessorById(int id, bool includeAluno = false);
        #endregion
    }
}
