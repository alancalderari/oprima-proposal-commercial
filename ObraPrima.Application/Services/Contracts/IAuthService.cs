using ObraPrima.Application.DTOs.User;

namespace ObraPrima.Application.Services.Contracts;

public interface IAuthService
{
    Task<ResultService<string>> Authenticate(UserDTO? userDTO);
}