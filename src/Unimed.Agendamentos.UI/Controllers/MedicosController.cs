using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unimed.Agendamentos.BLL.Interfaces;
using Unimed.Agendamentos.UI.Data;
using Unimed.Agendamentos.UI.ViewModels;
using UnimedAgendamentos.BLL.Models;

namespace Unimed.Agendamentos.UI.Controllers
{
    [Authorize]
    [Route("medicos")]
    public class MedicosController : BaseController
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMedicoService _medicoService;
        private readonly IMapper _mapper;

        public MedicosController(IMedicoRepository  medicoRepository,
                                 IMedicoService medicoService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)                                 
        {
            _medicoRepository = medicoRepository;
            _medicoService = medicoService;
            _mapper = mapper;
        }

        [Route("lista-de-medicos")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MedicoViewModel>>(await _medicoRepository.ObterTodos()));
        }

        [Route("detalhes-do-medico/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var medicoViewModel = _mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null)
            {
                return NotFound();
            }

            return View(medicoViewModel);
        }

        [Route("novo-medico")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-medico")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicoViewModel medicoViewModel)
        {
            if (!ModelState.IsValid) return View(medicoViewModel);

            var medico = _mapper.Map<Medico>(medicoViewModel);
            await _medicoService.Adicionar(medico);
            if (!OperacaoValida()) return View(medicoViewModel);

            TempData["Sucesso"] = "Médico cadastrado com sucesso!";

            return RedirectToAction("Index");
        }

        [Route("editar-medico/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var medicoViewModel = _mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null)
            {
                return NotFound();
            }
            return View(medicoViewModel);
        }

        [Route("editar-medico/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MedicoViewModel medicoViewModel)
        {
            if (id != medicoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(medicoViewModel);

            var medico = _mapper.Map<Medico>(medicoViewModel);
            await _medicoService.Atualizar(medico);
            if (!OperacaoValida()) return View(medicoViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-medico/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var medicoViewModel = _mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id));

            if (medicoViewModel == null) return NotFound();

            return View(medicoViewModel);
        }

        [Route("excluir-medico/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var medicoViewModel = _mapper.Map<MedicoViewModel>(await _medicoRepository.ObterPorId(id));
            if (medicoViewModel == null) return NotFound();

            await _medicoService.Remover(id);
            if (!OperacaoValida()) return View(medicoViewModel);

            TempData["Sucesso"] = "Médico excluído com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
