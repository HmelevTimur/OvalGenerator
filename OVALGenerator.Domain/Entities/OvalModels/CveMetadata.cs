using System.Text.Json.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class CveMetadata
{
    [JsonPropertyName("cveId")]
    public string CveId { get; set; }
}