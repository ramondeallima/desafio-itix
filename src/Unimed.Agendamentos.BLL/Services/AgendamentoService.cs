using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.BLL.Models.Validations;
using Unimed.Agendamentos.BLL.Notifications;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Services
{
    public class AgendamentoService : BaseService, IAgendamentoService
    {
        private readonly IAgendamentosRepository _agendamentosRepository;
        private readonly IAgendamentoValidacao _agendamentoValidacao;


        public AgendamentoService(INotificador notificador,
                                  IAgendamentosRepository agendamentosRepository,
                                  IAgendamentoValidacao agendamentoValidacao) : base(notificador)
        {
            _agendamentosRepository = agendamentosRepository;
            _agendamentoValidacao = agendamentoValidacao;
        }

        public async Task Adicionar(Agendamento agendamento)
        {
            if (!ExecutarValidacao(new AgendamentoValidation(), agendamento)) return;

            var agendamentos = _agendamentosRepository.ObterAgendamentosPorMedico(agendamento.MedicoId).Result;

            if (_agendamentoValidacao.DateIsValid(agendamento))
            {
                if (_agendamentoValidacao.AgendaLivre(agendamentos, agendamento))
                {
                    await _agendamentosRepository.Adicionar(agendamento);

                }
            }


        }

        public async Task Atualizar(Agendamento agendamento)
        {
            if (!ExecutarValidacao(new AgendamentoValidation(), agendamento)) return;
            var agendamentos = _agendamentosRepository.ObterAgendamentosPorMedico(agendamento.MedicoId).Result;

            if (_agendamentoValidacao.DateIsValid(agendamento))
            {
                if (_agendamentoValidacao.AgendaLivre(agendamentos, agendamento))
                {
                    await _agendamentosRepository.Atualizar(agendamento);

                }
            }
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
