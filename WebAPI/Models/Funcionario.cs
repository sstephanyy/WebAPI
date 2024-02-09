using System.ComponentModel.DataAnnotations;
using WebAPI.Enums;

namespace WebAPI.Models
{
    public class Funcionario
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeAlteracao{ get; set; }

    }
}
