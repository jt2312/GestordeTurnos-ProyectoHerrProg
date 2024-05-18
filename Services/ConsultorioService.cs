using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HerramientasProgFinal.Data;
using HerramientasProgFinal.Models;


namespace HerramientasProgFinal.Services;


public class ConsultorioService : IConsultorioService
{
    private readonly CitacionContext _context;

    public ConsultorioService(CitacionContext context)
    {
        _context = context;
    }

    public CitacionContext getContext()
    {
        return _context;
    }

    public void Create(Consultorio obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Consultorio> GetAll(string? filter)
    {

        if (!string.IsNullOrEmpty(filter))
        {
            return _context.Consultorio
                .Include(a => a.Doctores)
                .Where(a => a.Nombre.ToLower().Contains(filter.ToLower()) || a.Direccion.ToLower().Contains(filter.ToLower())).ToList();
        }

        return _context.Consultorio
                .Include(a => a.Doctores).ToList();
    }

    public void Update(Consultorio obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Consultorio _consultorio)
    {
        _context.Consultorio.Remove(_consultorio);
        _context.SaveChangesAsync();
    }

    public async Task<Consultorio?> GetById(int? id)
    {
        var consultorioTask = await _context.Consultorio.Include(a => a.Doctores).FirstOrDefaultAsync(m => m.Id == id);

        return consultorioTask;
    }
}