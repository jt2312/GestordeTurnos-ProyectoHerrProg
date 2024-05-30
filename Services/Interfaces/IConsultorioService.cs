using HerramientasProgFinal.Data;
using HerramientasProgFinal.Models;
namespace HerramientasProgFinal.Services;

public interface IConsultorioService {
    void Create(Consultorio obj);
    List<Consultorio> GetAll(string? filter);
    void Delete(Consultorio obj);
    void Update(Consultorio obj, int id);
    Task<Consultorio?> GetById(int? id);
    CitacionContext getContext();
}