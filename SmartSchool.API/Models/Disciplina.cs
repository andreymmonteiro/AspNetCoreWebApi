using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor {  get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

        public Disciplina(int Id, string Nome, int ProfessorId)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.ProfessorId = ProfessorId;
        }
    }
}
