using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HerramientasProgFinal.Services;

public class RolesService : IRolesService
{

    private readonly RoleManager<IdentityRole> _RoleManager;

    public RolesService(RoleManager<IdentityRole> RoleManager_)
    {
        _RoleManager = RoleManager_;
    }

    public List<IdentityRole> GetAll()
    {
        return _RoleManager.Roles.ToList();
    }

    public bool roleExists(string roleName)
    {
        return _RoleManager.RoleExistsAsync(roleName).Result;
    }

    public void create(string roleName)
    {
        var role = new IdentityRole(roleName);
        _RoleManager.CreateAsync(role);
    }
}