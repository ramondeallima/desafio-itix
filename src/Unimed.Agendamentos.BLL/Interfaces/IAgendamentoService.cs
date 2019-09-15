using System;
using System.Threading.Tasks;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Interfaces
{
    public interface IAgendamentoService : IDisposable
    {
        Task Adicionar(Agendamento agendamento);
        Task Atualizar(Agendamento agendamento);
        Task Remover(Guid id);
    }
}