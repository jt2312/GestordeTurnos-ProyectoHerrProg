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
    public class ConsultorioController : Controller
    {
        private IConsultorioService _consultorioService;

        public ConsultorioController(IConsultorioService consultorioService)
        {
            _consultorioService = consultorioService;
        }

        // GET: Consultorio

        public async Task<IActionResult> Index(string? filter)
        {
            var queryready = _consultorioService.GetAll(filter);
            
            var viewModel = new ConsultorioViewModel();
            viewModel.Consultorios = queryready;

            return View(viewModel);
        }

        // GET: Consultorio/Details/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin,Noob")]  
        public async Task<IActionResult> Details(int? id)
        {
            var consultorio = _consultorioService.GetById(id);
            return View(await consultorio);
        }

        // GET: Consultorio/Create
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                _consultorioService.Create(consultorio);
                return RedirectToAction(nameof(Index));
            }
            return View(consultorio);
        }

        // GET: Consultorio/Edit/5
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            var consultorio = await _consultorioService.GetById(id); 
            return View(consultorio);
        }

        // POST: Consultorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo,SemiAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion")] Consultorio consultorio)
        {
            if (id != consultorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _consultorioService.Update(consultorio,id);
                return RedirectToAction(nameof(Index));
            }   
            
            return View(consultorio);
        }

        // GET: Consultorio/Delete/5
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> Delete(int? id)
        {

            var consultorio = await _consultorioService.GetById(id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // POST: Consultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AdminSupremo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultorio = await _consultorioService.GetById(id);
            if (consultorio != null)
            {
                _consultorioService.Delete(consultorio);
            }
            
            return RedirectToAction(nameof(Index));
        }

        // private bool ConsultorioExists(int id)
        // {
        //     return _context.Consultorio.Any(e => e.Id == id);
        // }
    }
}
