using System.Text.Json;

namespace Contact.Core.Extensions;

public class ErrorDetails
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}