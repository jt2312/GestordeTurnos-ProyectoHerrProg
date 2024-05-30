using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HerramientasProgFinal.Data;
using HerramientasProgFinal.Models;
using HerramientasProgFinal.Services;
using HerramientasProgFinal.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace HerramientasProgFinal.Controllers
{
    public class PacienteController : Controller
    {

        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // GET: Paciente
        public async Task<IActionResult> Index(string? filter)
        {
            var pacientes = _pacienteService.GetAll(filter);

            var viewModel = new PacienteViewModel();
            viewModel.Pacientes = pacientes;

            return View(viewModel);
        }

        // GET: Paciente/Details/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _pacienteService.getContext().Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteService.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Paciente/Create
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad")] Paciente paciente)
        {
                _pacienteService.Create(paciente);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Paciente/Edit/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _pacienteService.getContext().Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteService.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            _pacienteService.Update(paciente,id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Paciente/Delete/5
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _pacienteService.getContext().Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteService.getContext().Paciente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_pacienteService.getContext().Paciente == null)
            {
                return Problem("Entity set 'CitacionContext.Paciente'  is null.");
            }

            var paciente = await _pacienteService.GetById(id);
            if (paciente != null)
            {
                _pacienteService.Delete(paciente);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return (_pacienteService.getContext().Paciente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
