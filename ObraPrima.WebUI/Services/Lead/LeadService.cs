using System.Text.Json;
using ObraPrima.WebUI.Models;
using ObraPrima.WebUI.Models.Lead;
using ObraPrima.WebUI.Services.Contracts.Lead;

namespace ObraPrima.WebUI.Services.Lead;

public class LeadService(IHttpClientFactory httpClientFactory) : ILeadService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("HttpClient");
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    
    public async Task<ResultService<LeadDto?>> GetLeadByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return ResultService.Fail<LeadDto?>("Construtora deve ser preenchida");

        var response = await _httpClient.GetAsync($"http://localhost:5106/api/lead/{name}");

        if (!response.IsSuccessStatusCode)
            return ResultService.Fail<LeadDto?>("Ocorreu um erro ao buscar a construtora. Tente novamente mais tarde.");

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var objResponse = JsonSerializer.Deserialize<Response>(jsonResponse, _jsonSerializerOptions);

        if (!objResponse!.IsSuccess)
            return ResultService.Fail<LeadDto?>(objResponse.Message);

        var lead = objResponse.Data.Deserialize<LeadDto>(_jsonSerializerOptions);

        return ResultService.Ok(lead);
    }
}