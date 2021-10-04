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
        public int CursoId { get; set; }
        public Curso Curso { get; set; }    
        public int CargaHoraria { get; set; }
        public int? PreRequisitoId { get; set; } = null;
        public Disciplina PreRequisito { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

        public Disciplina(int Id, string Nome, int ProfessorId, int? PreRequisitoId, int CursoId)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.ProfessorId = ProfessorId;
            this.PreRequisitoId = PreRequisitoId;
            this.CursoId = CursoId;
        }
    }
}
