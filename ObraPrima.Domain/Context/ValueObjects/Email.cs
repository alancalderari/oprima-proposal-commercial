using System.Text.RegularExpressions;
using ObraPrima.Domain.SharedContext.Extensions;
using ObraPrima.Domain.SharedContext.ValueObjects;

namespace ObraPrima.Domain.Context.ValueObjects;

public partial class Email : ValueObject
{
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

    protected Email() {} //Only EF
    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new Exception("E-mail is invalid");
        
        if (address.Length < 5)
            throw new Exception("E-mail is invalid");
        
        if(!EmailRegex().IsMatch(address))
            throw new Exception("E-mail is invalid");
        
        Address = address.Trim().ToLower();
    }
    public string Address { get; }
    public string Hash => Address.ToBase64();

    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string address)
        => new(address);
    
    //escreva uma função que valida se o email é válido
    public static bool IsValid(string email)
        => EmailRegex().IsMatch(email);

    public override string ToString()
        => Address;
            
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
}
