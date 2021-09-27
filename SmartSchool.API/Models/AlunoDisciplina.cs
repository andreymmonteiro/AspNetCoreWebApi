namespace SmartSchool.API.Models
{
    public class AlunoDisciplina
    {
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public AlunoDisciplina(int AlunoId, int DisciplinaId)
        {
            this.AlunoId = AlunoId;
            this.DisciplinaId = DisciplinaId;

        }
        public AlunoDisciplina()
        {

        }

    }
}
