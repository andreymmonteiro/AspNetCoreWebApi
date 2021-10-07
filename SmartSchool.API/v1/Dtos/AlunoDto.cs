using System;

namespace SmartSchool.API.v1.Dtos
{
    /// <summary>
    /// Classe aluno Data Transfer Object - Necessário para exibir informações que estão ou não na tabela do BD
    /// </summary>
    public class AlunoDto
    {
        /// <summary>
        /// Código único gerado pelo sistema
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Código definido pelo usuário
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime DataNasc { get; set; }
        public int Idade { get; set;  }
        /// <summary>
        /// Data em que se iniciou na instituição
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string telefone { get; set; }
    }
}
