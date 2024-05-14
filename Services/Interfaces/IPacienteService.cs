using HerramientasProgFinal.Models;
using Microsoft.EntityFrameworkCore;
using HerramientasProgFinal.Data;

namespace HerramientasProgFinal.Services;
public interface IPacienteService {
    void Create(Paciente obj);
    List<Paciente> GetAll(string? filter);
    void Update(Paciente obj, int id);
    void Delete(Paciente obj);
    Task<Paciente?> GetById(int? id);
    CitacionContext getContext();
}