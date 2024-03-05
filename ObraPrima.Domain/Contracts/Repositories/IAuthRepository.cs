using ObraPrima.Domain.Context.Entities;

namespace ObraPrima.Domain.Contracts.Repositories;

public interface IAuthRepository
{
    Task<User?> GetUserByEmailAndPassword(string address, string password);
}