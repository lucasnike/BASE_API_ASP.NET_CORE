namespace Infra.Data.Repositories.Implementation;

using Application.Data.Exceptions;
using Application.Data.Exceptions.User;
using Domain.Entities;
using Infra.Data.Context;
using Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly ApiContext _db;

    public UserRepository(ApiContext db)
    {
        _db = db;
    }

    public async Task<User> GetAsync(string username)
    {
        var user = await _db.Users
            .Include(x => x.Permissions)
            .SingleOrDefaultAsync(x => x.Username == username);

        if (user is null)
            throw new UserNotFoundException();

        return user;
    }
}
