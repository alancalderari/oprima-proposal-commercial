using System.Text;

namespace ObraPrima.WebUI.Extensions;

public static class StringExtension
{
    public static string ToBase64(this string text) 
        => Convert.ToBase64String(Encoding.ASCII.GetBytes(text));

    public static byte[] ToStringBase64(this string text)
        => Convert.FromBase64String(text);

    public static string ToJwtBase64(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        
        text = text.Split('.')[1];
        
        switch (text.Length % 4)
        {
            case 2: text += "=="; break;
            case 3: text += "=";  break;
        }

        return text;
    }
}