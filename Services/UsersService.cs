using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using HerramientasProgFinal.Data;

namespace HerramientasProgFinal.Services;

public class UsersService : IUsersService
{

    private readonly UserManager<IdentityUser> _UserManager;

    public UsersService(UserManager<IdentityUser> userM)
    {
        _UserManager = userM;
    }

    public List<IdentityUser> GetAll()
    {
        return _UserManager.Users.ToList();
    }

    public async  Task<IdentityUser?> findId(string? id)
    {
        return await _UserManager.FindByIdAsync(id);
    }

    public UserManager<IdentityUser> getManager()
    {
        return _UserManager;
    }
}