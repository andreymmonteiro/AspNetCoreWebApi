using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }
        public Aluno(int Id, string Nome, string Sobrenome, string Telefone, int Matricula, DateTime DataNasc)
        {
            this.Id = Id;
            this.Nome = Nome;   
            this.Sobrenome = Sobrenome;
            this.telefone = Telefone;
            this.Matricula = Matricula;
            this.DataNasc = DataNasc;

        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

    }
}
