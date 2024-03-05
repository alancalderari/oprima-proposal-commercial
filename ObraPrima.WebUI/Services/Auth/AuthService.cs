using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ObraPrima.WebUI.Extensions;
using ObraPrima.WebUI.Models;
using ObraPrima.WebUI.Models.Auth;
using ObraPrima.WebUI.Providers;
using ObraPrima.WebUI.Services.Contracts.Auth;

namespace ObraPrima.WebUI.Services.Auth;

public class AuthService(AuthenticationStateProvider authenticationState, IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService) : IAuthService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HttpClient");
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    public async Task<bool> Authenticate(Credential? credential)
    {
        if (credential is null)
            return false;

        if (string.IsNullOrWhiteSpace(credential.EmailAddress))
            return false;
        
        if (string.IsNullOrWhiteSpace(credential.Password))
            return false;

        var payload = JsonSerializer.Serialize(credential);
        var requestContent = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:5106/api/Auth/jwt/create",requestContent);

        if (!response.IsSuccessStatusCode)
            return false;

        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        var objResponse = JsonSerializer.Deserialize<Response>(jsonResponse, _jsonSerializerOptions);
        var jwt = objResponse!.Data.Deserialize<string>() ?? string.Empty;

        await localStorageService.SetItemAsync("_uSessionUser",jwt.ToJwtBase64());
        
        (authenticationState as CustomAuthProvider)?.NotifyAuthState();
        
        return true;
    }
}