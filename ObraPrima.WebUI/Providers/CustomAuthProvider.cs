using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ObraPrima.WebUI.Extensions;

namespace ObraPrima.WebUI.Providers;

public class CustomAuthProvider(ILocalStorageService localStorageService) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await localStorageService.GetItemAsync<string>("_uSessionUser");
            
            return string.IsNullOrWhiteSpace(token)
                ? EmptyAuthenticationState()
                : new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimFromJwt(token), "JwtAuth")));
        }
        catch
        {
            return EmptyAuthenticationState();
        }
    }

    private static AuthenticationState EmptyAuthenticationState()
        => new(new ClaimsPrincipal(new ClaimsIdentity()));

    private static IEnumerable<Claim> ParseClaimFromJwt(string jwt)
    {
        var jsonBytes = jwt.ToStringBase64();
        var keysValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keysValuePairs!.Select(x => new Claim(x.Key, x.Value.ToString() ?? string.Empty));
    }

    public void NotifyAuthState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}