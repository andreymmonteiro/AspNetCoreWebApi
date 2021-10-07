using SmartSchool.API.Models;
using System;
using System.Collections.Generic;

namespace SmartSchool.API.v1.Dtos
{
    /// <summary>
    /// Classe aluno Data Transfer Object - Necessário para Salvar informações que estão ou não na interface do usuário com a tabela do BD
    /// </summary>
    public class AlunoRegistrarDto
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
        /// <summary>
        /// Data em que se iniciou na instituição
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data de término
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Se o aluno esta ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}
