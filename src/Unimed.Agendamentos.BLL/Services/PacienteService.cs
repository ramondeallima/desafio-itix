using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.BLL.Models.Validations;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.BLL.Services
{
    public class PacienteService : BaseService, IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository,
                               INotificador notificador) : base(notificador)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task Adicionar(Paciente paciente)
        {

            if (!ExecutarValidacao(new PacienteValidation(), paciente)) return;

            if (_pacienteRepository.Buscar(p => p.Cpf == paciente.Cpf).Result.Any())
            {
                Notificar("Já existe um paciente com o CPF informado.");
                return;
            }

            await _pacienteRepository.Adicionar(paciente);

            // Validar se a data de nascimento é valida

        }

        public async Task Atualizar(Paciente paciente)
        {
            if (!ExecutarValidacao(new PacienteValidation(), paciente)) return;

            if (_pacienteRepository.Buscar(p => p.Cpf == paciente.Cpf).Result.Any())
            {
                Notificar("Já existe um paciente com o CPF informado.");
                return;
            }

            await _pacienteRepository.Atualizar(paciente);
        }

        public async Task Remover(Guid id)
        {
            if (_pacienteRepository.ObterPacienteAgendamentos(id).Result.Agendamentos.Any())
            {
                Notificar("O paciente possui consultas agendadas!");
                return;
            }

            await _pacienteRepository.Remover(id);
        }
        public void Dispose()
        {
            _pacienteRepository?.Dispose();
        }
    }
}
