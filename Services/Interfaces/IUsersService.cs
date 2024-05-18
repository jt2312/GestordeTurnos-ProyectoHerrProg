namespace HerramientasProgFinal.Services;
using HerramientasProgFinal.Models;
using Microsoft.AspNetCore.Identity;
using HerramientasProgFinal.Data;

public interface IUsersService
{

    List<IdentityUser> GetAll();
    Task<IdentityUser?> findId(string? id);
    UserManager<IdentityUser> getManager();
}