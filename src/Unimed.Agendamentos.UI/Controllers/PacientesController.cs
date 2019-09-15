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
    [Route("pacientes")]
    public class PacientesController : BaseController
    {
        private readonly IPacienteRepository _pacientesRepository;
        private readonly IPacienteService _pacientesService;
        private readonly IMapper _mapper;
        public PacientesController(IPacienteRepository pacientesRepository,
                                   IMapper mapper,
                                   IPacienteService pacienteService,
                                   INotificador notificador) : base(notificador)
        {
            _pacientesRepository = pacientesRepository;
            _mapper = mapper;
            _pacientesService = pacienteService;
        }

        [Route("lista-de-pacientes")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PacienteViewModel>>(await _pacientesRepository.ObterTodos()));
        }

        [Route("detalhes-do-paciente/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));
            if (pacienteViewModel == null)
            {
                return NotFound();
            }

            return View(pacienteViewModel);
        }

        [Route("novo-paciente")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-paciente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteViewModel pacienteViewModel)
        {
            if (!ModelState.IsValid) return View(pacienteViewModel);

            var paciente = _mapper.Map<Paciente>(pacienteViewModel);
            await _pacientesService.Adicionar(paciente);

            if (!OperacaoValida()) return View(pacienteViewModel);

            TempData["Sucesso"] = "Paciente cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [Route("editar-paciente/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));
            if (pacienteViewModel == null)
            {
                return NotFound();
            }
            return View(pacienteViewModel);
        }

        [Route("editar-paciente/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel pacienteViewModel)
        {
            if (id != pacienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pacienteViewModel);

            var paciente = _mapper.Map<Paciente>(pacienteViewModel);
            await _pacientesService.Atualizar(paciente);

            if (!OperacaoValida()) return View(pacienteViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-paciente/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));
            if (pacienteViewModel == null)
            {
                return NotFound(); 
            }

            return View(pacienteViewModel);
        }

        [Route("excluir-paciente/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));

            if (pacienteViewModel == null) return NotFound();

            await _pacientesService.Remover(id);

            if (!OperacaoValida()) return View(pacienteViewModel);

            TempData["Sucesso"] = "Médico excluído com sucesso!";

            return RedirectToAction("Index");
        }

    }
}
