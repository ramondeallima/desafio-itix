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
        [Required(ErrorMessage = "É necessário informar o médico")]
        public Guid MedicoId { get; set; }

        [DisplayName("Paciente")]
        [Required(ErrorMessage = "É necessário informar o paciente")]
        public Guid PacienteId { get; set; }

        [DisplayName("Início")]
        [Required(ErrorMessage = "É necessário informar o horário de início")]
        public DateTime InicioAtendimento { get; set; }

        [DisplayName("Término")]
        [Required(ErrorMessage = "É necessário informar o horário de término")]
        public DateTime FimAtendimento { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public PacienteViewModel Paciente { get; set; }
        public MedicoViewModel Medico { get; set; }

        public IEnumerable<PacienteViewModel> Pacientes { get; set; }
        public IEnumerable<MedicoViewModel> Medicos { get; set; }
    }
}
