using SmartSchool.API.Models;
using System;
using System.Collections.Generic;

namespace SmartSchool.API.Dtos
{
    public class AlunoRegistrarDto
    {
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
