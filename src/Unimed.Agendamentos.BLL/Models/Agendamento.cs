using System;
using System.Collections.Generic;
using System.Text;

namespace UnimedAgendamentos.BLL.Models
{
    public class Agendamento : Entity
    {
        public Guid MedicoId { get; set; }
        public Guid PacienteId { get; set; }

        public DateTime InicioAtendimento { get; set; }
        public DateTime FimAtendimento { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }

        /* Relações */
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
