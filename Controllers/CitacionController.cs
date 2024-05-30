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
    public class CitacionController : Controller
    {
        private readonly CitacionContext _context;

        private ICitacionService _citacionService;

        public CitacionController(ICitacionService citacionService)
        {
            _citacionService = citacionService;
        }

        // GET: Citacion
        public async Task<IActionResult> Index(string? filter)
        {
            var appointments = _citacionService.GetAll(filter);

            var viewModel = new CitacionViewModel();
            viewModel.Citaciones = appointments;

            return View(viewModel);
        }

        // GET: Citacion/Details/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]

        public async Task<IActionResult> Details(int? id)
        {
            var cita = await _citacionService.GetById(id);
            return View(cita);
        }

        // GET: Citacion/Create
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_citacionService.getContext().Doctor, "Id", "Nombre");            
            ViewData["PacienteId"] = new SelectList(_citacionService.getContext().Paciente, "Id", "Nombre");
            return View();
        }

        // POST: Citacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,DoctorId,PacienteId")] Citacion citacion)
        {
            _citacionService.Create(citacion);
            return RedirectToAction(nameof(Index));
        }

        // GET: Citacion/Edit/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _citacionService.getContext().Citacion == null)
            {
                return NotFound();
            }

            var citacion = await _citacionService.GetById(id);
            if (citacion == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_citacionService.getContext().Doctor, "Id", "Nombre");
            ViewData["PatientId"] = new SelectList(_citacionService.getContext().Paciente, "Id", "Nombre", citacion.PacienteId);
            return View(citacion);
        }

        // POST: Citacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,DoctorId,PacienteId")] Citacion citacion)
        {
            if (id != citacion.Id)
            {
                return NotFound();
            }

            _citacionService.Update(citacion,id);
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Citacion/Delete/5
        [Authorize(Roles = "AdminSupremo")] 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _citacionService.getContext().Citacion == null)
            {
                return NotFound();
            }

            var citacion = await _citacionService.GetById(id);

            if (citacion == null)
            {
                return NotFound();
            }

            return View(citacion);
        }

        // POST: Citacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_citacionService.getContext().Citacion == null)
            {
                return Problem("Entity set 'CitacionContext.Citacion'  is null.");
            }

            var citacion = await _citacionService.GetById(id);
            if (citacion != null)
            {
                _citacionService.Delete(citacion);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CitacionExists(int id)
        {
            return (_citacionService.getContext().Citacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
