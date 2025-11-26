namespace Infra.Data.Repositories.Implementation;

using Domain.Entities;
using Infra.Data.Context;
using Infra.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly ApiContext _db;

    public RefreshTokenRepository(ApiContext db)
    {
        _db = db;
    }

    public Task<RefreshToken?> Get(string token)
    {
        return _db.RefreshTokens.SingleOrDefaultAsync(x => x.Token == token);
    }

    public async Task Insert(Domain.Entities.RefreshToken refreshToken)
    {
        _db.RefreshTokens.Add(refreshToken);
        await _db.SaveChangesAsync();
    }

    
}
