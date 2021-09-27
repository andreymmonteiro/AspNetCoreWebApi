using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Professor(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
