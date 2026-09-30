using System;
using Backend.Domain.DTO;
using LlmService.DataAccessLayer;
using LlmService.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer.repositories;

//UserRepositorys Job is the link to database.
//--
//Evry method in this class is related to User Actions on the database.
public class UserRepository : IUserRepository
{
    private readonly DataAccessContext _db;

    public UserRepository(DataAccessContext db)
    {
        _db = db;
    }
    public async Task<User>? GetUserByIdAsync(int id)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
    }


    //This part has the db access
    public async Task CreateUserAsync(User user)
    {

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        await _db.SaveChangesAsync();
    }

    //Complete this method
    public async Task DeleteUser(User user)
    {

    }
}
