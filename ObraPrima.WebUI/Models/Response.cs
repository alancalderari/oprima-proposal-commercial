using System.Text.Json;

namespace ObraPrima.WebUI.Models;

public class Response
{
    public JsonElement Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}