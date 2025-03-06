using System.Text.Json.Serialization;

namespace OVALGenerator.Application.Dtos;

public class Version
{
    [JsonPropertyName("lessThan")]
    public string LessThan { get; set; }
}