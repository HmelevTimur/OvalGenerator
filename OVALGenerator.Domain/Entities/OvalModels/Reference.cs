using System.Text.Json.Serialization;

namespace OVALGenerator.Application.Dtos;

public class Reference
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}