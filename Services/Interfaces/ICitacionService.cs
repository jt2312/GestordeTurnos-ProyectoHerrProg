using HerramientasProgFinal.Data;
using HerramientasProgFinal.Models; 

namespace HerramientasProgFinal.Services;

public interface ICitacionService{
    void Create(Citacion obj);
    List<Citacion> GetAll(string? filter);
    void Update(Citacion obj, int id);
    void Delete(Citacion obj);
    Task<Citacion?> GetById(int? id);
    CitacionContext getContext();
    List<Paciente> GetAllPatients();

}