using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.UI.ViewModels;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.UI.Controllers
{
    public class AgendamentosController : Controller
    {
        private readonly IAgendamentosRepository _agendamentoRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public AgendamentosController(IAgendamentosRepository agendamentosRepository,
                                      IMedicoRepository medicoRepository,
                                      IPacienteRepository pacienteRepository,
                                      IMapper mapper)
        {
            _agendamentoRepository = agendamentosRepository;
            _medicoRepository = medicoRepository;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AgendamentoViewModel>>(await _agendamentoRepository.ObterAgendamentosPacientes()));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var agendamentoViewModel = await ObterAgendamento(id);

            if (agendamentoViewModel == null)
            {
                return NotFound();
            }

            return View(agendamentoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var agendamentoViewModel = new AgendamentoViewModel();

            agendamentoViewModel.Pacientes = _mapper.Map<IEnumerable<PacienteViewModel>>(await _pacienteRepository.ObterTodos());
            agendamentoViewModel.Medicos = _mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.ObterTodos());

            return View(agendamentoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendamentoViewModel agendamentoViewModel)
        {
            agendamentoViewModel.Pacientes = _mapper.Map<IEnumerable<PacienteViewModel>>(await _pacienteRepository.ObterTodos());
            agendamentoViewModel.Medicos = _mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.ObterTodos());

            if (!ModelState.IsValid) return View(agendamentoViewModel);

            await _agendamentoRepository.Adicionar(_mapper.Map<Agendamento>(agendamentoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var agendamentoViewModel = await ObterAgendamento(id);

            if (agendamentoViewModel == null)
            {
                return NotFound();
            }
            return View(agendamentoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AgendamentoViewModel agendamentoViewModel)
        {
            if (id != agendamentoViewModel.Id) return NotFound();

            var agendamentoAtualizacao = await ObterAgendamento(id);


            if (!ModelState.IsValid) return View(agendamentoViewModel);

            agendamentoAtualizacao.InicioAtendimento = agendamentoViewModel.InicioAtendimento;
            agendamentoAtualizacao.FimAtendimento = agendamentoViewModel.FimAtendimento;
            agendamentoAtualizacao.Observacao = agendamentoViewModel.Observacao;

            await _agendamentoRepository.Atualizar(_mapper.Map<Agendamento>(agendamentoAtualizacao));
            return RedirectToAction("Index");
            

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var agendamento = await ObterAgendamento(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var agendamento = await ObterAgendamento(id);

            if (agendamento == null)
            {
                return NotFound();
            }

            await _agendamentoRepository.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<AgendamentoViewModel> ObterAgendamento(Guid id)
        {
            var agendamento = _mapper.Map<AgendamentoViewModel>(await _agendamentoRepository.ObterAgendamentoPaciente(id));
            agendamento.Medico = _mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(agendamento.MedicoId));
            return agendamento;
        }

    }
}
