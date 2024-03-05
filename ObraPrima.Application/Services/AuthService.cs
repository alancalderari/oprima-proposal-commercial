using Microsoft.AspNetCore.Http;
using ObraPrima.Application.DTOs.User;
using ObraPrima.Application.DTOs.User.Validations;
using ObraPrima.Application.Extensions;
using ObraPrima.Application.Services.Contracts;
using ObraPrima.Domain.Contracts.Repositories;

namespace ObraPrima.Application.Services;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public async Task<ResultService<string>> Authenticate(UserDTO? userDTO)
    {
        if (userDTO is null)
            return ResultService.Fail<string>("Object is invalid");

        var result = await new UserDTOValidator().ValidateAsync(userDTO);

        if (!result.IsValid)
            return ResultService.RequestError<string>("Invalid property",result);
        
        var user = await authRepository.GetUserByEmailAndPassword(userDTO.EmailAddress, userDTO.Password);

        return user is null ? ResultService.Fail<string>("User or password invalid") : ResultService.Ok<string>(JwtExtension.Generate(user));
    }
}