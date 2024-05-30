using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HerramientasProgFinal.Data;
using HerramientasProgFinal.Models;

namespace HerramientasProgFinal.Services;

public class PacienteService : IPacienteService
{

    private readonly CitacionContext _context;

    public PacienteService(CitacionContext context)
    {
        _context = context;
    }

    public CitacionContext getContext()
    {
        return _context;
    }

    public void Create(Paciente obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Paciente> GetAll(string? filter)
    {
        var query = from _Paciente in _context.Paciente select _Paciente;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Nombre.ToLower().Contains(filter.ToLower()) || x.Edad.ToString().ToLower().Contains(filter.ToLower()));
        }

        return query.ToList();
    }

    public void Update(Paciente obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Paciente obj)
    {
        _context.Paciente.Remove(obj);
        _context.SaveChangesAsync();
    }

    public async Task<Paciente?> GetById(int? id)
    {
        var taskpacnt = await _context.Paciente.FirstOrDefaultAsync(m => m.Id == id);

        return taskpacnt;
    }
}