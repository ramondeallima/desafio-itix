using System;
using System.Collections.Generic;
using System.Text;

namespace UnimedAgendamentos.BLL.Models
{
    public class Medico : Entity
    {
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Telefone { get; set; }

        /* Relações */
        public IEnumerable<Agendamento> Agendamentos { get; set; }
    }
}
