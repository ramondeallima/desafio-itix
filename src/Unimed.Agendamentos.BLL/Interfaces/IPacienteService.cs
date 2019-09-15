using System;
using System.Threading.Tasks;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Interfaces
{
    public interface IPacienteService : IDisposable
    {
        Task Adicionar(Paciente paciente);
        Task Atualizar(Paciente paciente);
        Task Remover(Guid id);
    }
}