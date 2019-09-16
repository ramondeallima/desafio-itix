using System;
using System.Collections.Generic;
using System.Text;

namespace UnimedAgendamentos.BLL.Models
{
    public class Paciente : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        /* Relações */
        public IEnumerable<Agendamento> Agendamentos { get; set; }

    }
}
