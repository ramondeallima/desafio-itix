using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.UI.ViewModels
{
    public class AgendamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Médico")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid MedicoId { get; set; }

        [DisplayName("Paciente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid PacienteId { get; set; }

        [DisplayName("Inicio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime InicioAtendimento { get; set; }

        [DisplayName("Término")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime FimAtendimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Observacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public PacienteViewModel Paciente { get; set; }
        public MedicoViewModel Medico { get; set; }
    }
}
