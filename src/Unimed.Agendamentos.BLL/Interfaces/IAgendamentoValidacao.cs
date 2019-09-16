using System;
using System.Collections.Generic;
using System.Text;
using UnimedAgendamentos.BLL.Models;


namespace Unimed.Agendamentos.BLL.Interfaces
{
    public interface IAgendamentoValidacao
    {
        bool DateIsValid(Agendamento agendamento);
        bool AgendaLivre (IEnumerable<Agendamento> agendamentos, Agendamento agendamento);
    }
}
