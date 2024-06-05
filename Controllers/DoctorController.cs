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
    public class DoctorController : Controller
    {
        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: Doctor
        public async Task<IActionResult> Index(string? filter)
        {

            var doctores = _doctorService.GetAll(filter);

            var viewModel = new DoctorViewModel();
            viewModel.Doctores = doctores;

            return View(viewModel);
        }

        // GET: Doctor/Details/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]
        public async Task<IActionResult> Details(int? id)
        {
            var doctor = await _doctorService.GetById(id);
            return View(doctor);
        }


        // GET: Doctor/Create
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public IActionResult Create()
        {
            ViewData["ConsultorioId"] = new SelectList(_doctorService.getContext().Consultorio, "Id", "Nombre");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,,Especialidad,ConsultorioId")] Doctor doctor)
        {
            _doctorService.Create(doctor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Edit/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _doctorService.getContext().Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["ConsultorioId"] = new SelectList(_doctorService.getContext().Consultorio, "Id", "Nombre", doctor.ConsultorioId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Especialidad,ConsultorioId")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            _doctorService.Update(doctor,id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Delete/5
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> Delete(int? id)
        {
            var doctor = await _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _doctorService.GetById(id);
            if (doctor != null)
            {
                _doctorService.Delete(doctor);
            }
            
            return RedirectToAction(nameof(Index));
        }

        // private bool DoctorExists(int id)
        // {
        //     return _context.Doctor.Any(e => e.Id == id);
        // }
    }
}
