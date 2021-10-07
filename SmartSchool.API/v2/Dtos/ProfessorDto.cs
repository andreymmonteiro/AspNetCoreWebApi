using System;

namespace SmartSchool.API.v2.Dtos
{
    /// <summary>
    /// Data transfer object -um objeto usado para exibição na interface do usuário
    /// </summary>
    public class ProfessorDto
    {
        /// <summary>
        /// Identificação do Professor - gerado automaticamente pelo BD
        /// </summary>
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Matricula { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;
    }
}
