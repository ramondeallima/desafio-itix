using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.UI.Data;
using Unimed.Agendamentos.UI.ViewModels;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.UI.Controllers
{
    [DisplayColumn("Médicos")]
    public class MedicosController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicosController(IMedicoRepository  medicoRepository,
                                 IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var medicoViewModel = _mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null)
            {
                return NotFound();
            }

            return View(medicoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicoViewModel medicoViewModel)
        {
            if (!ModelState.IsValid) return View(medicoViewModel);

            var medico = _mapper.Map<Medico>(medicoViewModel);
            await _medicoRepository.Adicionar(medico);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var medicoViewModel = await _medicoRepository.ObterPorId(id);
            if (medicoViewModel == null)
            {
                return NotFound();
            }
            return View(medicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MedicoViewModel medicoViewModel)
        {
            if (id != medicoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(medicoViewModel);

            var medico = _mapper.Map<Medico>(medicoViewModel);
            await _medicoRepository.Atualizar(medico);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var medicoViewModel = _mapper.Map<PacienteViewModel>(await _medicoRepository.ObterPorId(id));

            if (medicoViewModel == null) return NotFound();

            return View(medicoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medicoViewModel = _mapper.Map<PacienteViewModel>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null) return NotFound();

            await _medicoRepository.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
