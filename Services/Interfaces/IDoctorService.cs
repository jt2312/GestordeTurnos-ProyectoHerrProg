
using HerramientasProgFinal.Models;
using Microsoft.EntityFrameworkCore;
using HerramientasProgFinal.Data;

namespace HerramientasProgFinal.Services;
public interface IDoctorService {
    void Create(Doctor obj);
    List<Doctor> GetAll(string? filter);
    void Update(Doctor obj, int id);
    void Delete(Doctor obj);
    Task<Doctor?> GetById(int? id);
    CitacionContext getContext();
}