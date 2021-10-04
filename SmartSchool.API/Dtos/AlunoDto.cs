using System;

namespace SmartSchool.API.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public DateTime DataNasc { get; set; }
        public int Idade { get; set;  }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string telefone { get; set; }
    }
}
