namespace Infra.Data.Repositories.Interfaces;

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

public interface IUserRepository : IRepository
{
    Task<User> GetAsync(string username);
}
