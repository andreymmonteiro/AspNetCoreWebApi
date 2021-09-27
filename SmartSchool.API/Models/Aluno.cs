using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }
        public Aluno(int Id, string Nome, string Sobrenome, string Telefone)
        {
            this.Id = Id;
            this.Nome = Nome;   
            this.Sobrenome = Sobrenome;
            this.telefone = Telefone;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

    }
}
