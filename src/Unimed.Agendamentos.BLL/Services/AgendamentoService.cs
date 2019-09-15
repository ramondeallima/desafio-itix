using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.BLL.Models.Validations;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Services
{
    public class AgendamentoService : BaseService, IAgendamentoService
    {
        private readonly IAgendamentosRepository _agendamentosRepository;

        public AgendamentoService(INotificador notificador,
                                  IAgendamentosRepository agendamento) : base(notificador)
        {
            _agendamentosRepository = agendamento;
        }

        public async Task Adicionar(Agendamento agendamento)
        {
            if (!ExecutarValidacao(new AgendamentoValidation(), agendamento)) return;

            await _agendamentosRepository.Adicionar(agendamento);
        }

        public async Task Atualizar(Agendamento agendamento)
        {
            if (!ExecutarValidacao(new AgendamentoValidation(), agendamento)) return;
                
            await _agendamentosRepository.Atualizar(agendamento);
        }

        public async Task Remover(Guid id)
        {
            await _agendamentosRepository.Remover(id);
        }

        public void Dispose()
        {
            _agendamentosRepository?.Dispose();
        }
    }
}
