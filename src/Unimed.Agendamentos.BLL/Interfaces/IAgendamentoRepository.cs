using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Interfaces
{
    public interface IAgendamentosRepository : IRepository<Agendamento>
    {
        Task<IEnumerable<Agendamento>> ObterAgendamentosPorPaciente(Guid pacienteId);
        Task<IEnumerable<Agendamento>> ObterAgendamentosPorMedico(Guid medicoId);
        Task<IEnumerable<Agendamento>> ObterAgendamentosPacientes();
        Task<Agendamento> ObterAgendamentoPaciente(Guid id);

    }
}
