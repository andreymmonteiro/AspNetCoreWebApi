using System;
namespace SmartSchool.API.Models
{
    public class AlunoCurso
    {
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Curso { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int? Nota { get; set; } = null;
        public AlunoCurso(int AlunoId, int CursoId)
        {
            this.AlunoId = AlunoId;
            this.CursoId = CursoId;

        }
        public AlunoCurso()
        {

        }

    }
}
