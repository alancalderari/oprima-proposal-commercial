using System.ComponentModel.DataAnnotations;

namespace ObraPrima.WebUI.Models.Auth;

public class Credential
{
    [Required(ErrorMessage = "E-mail deve ser informado"),EmailAddress(ErrorMessage = "E-mail deve ser informado")]
    public string? EmailAddress { get; set; }
    
    [Required(ErrorMessage = "Senha deve ser informado")]
    public string? Password { get; set; }
}