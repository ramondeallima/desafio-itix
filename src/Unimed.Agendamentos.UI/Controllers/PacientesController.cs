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

    public class PacientesController : BaseController
    {
        private readonly IPacienteRepository _pacientesRepository;
        private readonly IMapper _mapper;
        public PacientesController(IPacienteRepository pacientesRepository,
                                   IMapper mapper)
        {
            _pacientesRepository = pacientesRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PacienteViewModel>>(await _pacientesRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));
            if (pacienteViewModel == null)
            {
                return NotFound();
            }

            return View(pacienteViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteViewModel pacienteViewModel)
        {
            if (!ModelState.IsValid) return View(pacienteViewModel);

            var paciente = _mapper.Map<Paciente>(pacienteViewModel);
            await _pacientesRepository.Adicionar(paciente);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));
            if (pacienteViewModel == null)
            {
                return NotFound();
            }
            return View(pacienteViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel pacienteViewModel)
        {
            if (id != pacienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pacienteViewModel);

            var paciente = _mapper.Map<Paciente>(pacienteViewModel);
            await _pacientesRepository.Atualizar(paciente);

            return RedirectToAction("Index");
        }
         
        public async Task<IActionResult> Delete(Guid id)
        {

            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));
            if (pacienteViewModel == null)
            {
                return NotFound(); 
            }

            return View(pacienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pacienteViewModel = _mapper.Map<PacienteViewModel>(await _pacientesRepository.ObterPorId(id));

            if (pacienteViewModel == null) return NotFound();

            await _pacientesRepository.Remover(id);
            return RedirectToAction("Index");
        }

    }
}
