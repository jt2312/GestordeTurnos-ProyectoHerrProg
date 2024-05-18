namespace HerramientasProgFinal.Services;
using HerramientasProgFinal.Models;
using Microsoft.AspNetCore.Identity;

public interface IRolesService
{

    List<IdentityRole> GetAll();
    bool roleExists(string roleName);
    void create(string roleName);

}