namespace Infra.Data.Repositories.Interfaces;

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

public interface IRefreshTokenRepository : IRepository
{
    Task Insert(RefreshToken refreshToken);
    Task<RefreshToken?> Get(string token);
}
