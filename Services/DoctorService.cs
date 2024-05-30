
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HerramientasProgFinal.Data;
using HerramientasProgFinal.Models;

namespace HerramientasProgFinal.Services;
public class DoctorService : IDoctorService
{

    private readonly CitacionContext _context;

    public DoctorService(CitacionContext context)
    {
        _context = context;
    }

    public CitacionContext getContext()
    {
        return _context;
    }

    public void Create(Doctor obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Doctor> GetAll(string? filter)
    {
        var query = from Doctor in _context.Doctor select Doctor;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Nombre.ToLower().Contains(filter.ToLower()) 
            || x.Edad.ToString().ToLower().Contains(filter.ToLower())
            || x.Especialidad.ToLower().Contains(filter.ToLower()));
        }

        var queryOk = query.Include(x => x.Consultorio_).ToList();
        return queryOk;
    }

    public void Update(Doctor obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Doctor obj)
    {
        _context.Doctor.Remove(obj);
        _context.SaveChangesAsync();
    }

    public async Task<Doctor?> GetById(int? id)
    {
        var taskDct = await _context.Doctor.Include(x => x.Consultorio_).FirstOrDefaultAsync(m => m.Id == id);

        return taskDct;
    }
}