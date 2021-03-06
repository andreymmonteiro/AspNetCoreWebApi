using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set;  }
        public int Matricula { get; set; }  
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        public Professor(int Id, string Nome, int Matricula, string Sobrenome)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Matricula = Matricula;
            this.Sobrenome = Sobrenome;
        }
    }
}
