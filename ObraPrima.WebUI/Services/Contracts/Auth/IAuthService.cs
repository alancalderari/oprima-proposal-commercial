using ObraPrima.WebUI.Models.Auth;

namespace ObraPrima.WebUI.Services.Contracts.Auth;

public interface IAuthService
{
    Task<bool> Authenticate(Credential? credential);
}