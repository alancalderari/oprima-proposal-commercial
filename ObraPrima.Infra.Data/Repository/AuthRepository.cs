using Microsoft.EntityFrameworkCore;
using ObraPrima.Domain.Context.Entities;
using ObraPrima.Domain.Contracts.Repositories;
using ObraPrima.Infra.Data.Data;

namespace ObraPrima.Infra.Data.Repository;

public class AuthRepository(AppDbContext context) : IAuthRepository
{
    public async Task<User?> GetUserByEmailAndPassword(string address, string password)
    {
        if (string.IsNullOrWhiteSpace(address))
            return null;

        var user = await context.Users
            .AsNoTracking()
            //.include(rolas)
            .FirstOrDefaultAsync(x => x.Email.Address == address && x.Password == password);

        return user;
    }
}