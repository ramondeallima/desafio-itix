using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.BLL.Models.Validations;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Services
{
    public class MedicoService : BaseService, IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(INotificador notificador,
                             IMedicoRepository medico) : base(notificador)
        {
            _medicoRepository = medico;
        }

        public async Task Adicionar(Medico medico)
        {
            if (!ExecutarValidacao(new MedicoValidation(), medico)) return;

            await _medicoRepository.Adicionar(medico);
        }

        public async Task Atualizar(Medico medico)
        {
            if (!ExecutarValidacao(new MedicoValidation(), medico)) return;

            await _medicoRepository.Atualizar(medico);
        }

        public async Task Remover(Guid id)
        {
            await _medicoRepository.Remover(id);
        }
        public void Dispose()
        {
            _medicoRepository?.Dispose();
        }
    }
}
