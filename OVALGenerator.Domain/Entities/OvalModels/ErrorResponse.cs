namespace OVALGenerator.Domain.Entities.OvalModels;

public class ErrorResponse
{
    public string Error { get; set; }
    public string? Details { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    public static ErrorResponse Create(string error, string? details = null) 
        => new() { Error = error, Details = details };
}