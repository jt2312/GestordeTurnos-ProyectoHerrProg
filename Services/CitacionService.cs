using System.Collections.Generic;
using System.Threading.Tasks;
using HerramientasProgFinal.Models;
using HerramientasProgFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace HerramientasProgFinal.Services;

public class CitacionService : ICitacionService
{

    private readonly CitacionContext _context;

    public CitacionService(CitacionContext context)
    {
        _context = context;
    }

    public CitacionContext getContext()
    {
        return _context;
    }

    public void Create(Citacion obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Citacion> GetAll(string? filter)
    {
        if (!string.IsNullOrEmpty(filter))
        {
            return _context.Citacion
                .Include(a => a.Doctor)
                .Include(a => a.Paciente)
                .Where(a => a.Descripcion.Contains(filter.ToLower())).ToList();
        }

        return _context.Citacion
            .Include(a => a.Doctor)
            .Include(a => a.Paciente).ToList();
    }

    public void Update(Citacion obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Citacion consultorio)
    {
        _context.Citacion.Remove(consultorio);
        _context.SaveChangesAsync();
    }

    public async Task<Citacion?> GetById(int? id)
    {
        var ConsulTask = await _context.Citacion
                                    .Include(a => a.Doctor)
                                    .Include(a => a.Paciente)
                                    .FirstOrDefaultAsync(m => m.Id == id);

        return ConsulTask;
    }

    public List<Paciente> GetAllPatients()
    {
        var query = from _Paciente in _context.Paciente select _Paciente;
        return query.ToList();
    }


}