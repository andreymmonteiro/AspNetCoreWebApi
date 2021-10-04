using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Curso
    {
        public Curso(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
        public int Id { get; set;  }
        public string Nome { get; set;  }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
