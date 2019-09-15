using System;
using System.Threading.Tasks;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Interfaces
{
    public interface IMedicoService : IDisposable
    {
        Task Adicionar(Medico medico);
        Task Atualizar(Medico medico);
        Task Remover(Guid id);
    }
}