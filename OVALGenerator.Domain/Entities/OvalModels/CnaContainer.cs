using System.Text.Json.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class CnaContainer
{
    [JsonPropertyName("affected")]
    public List<Affected> Affected { get; set; } = new();

    [JsonPropertyName("descriptions")]
    public List<Description> Descriptions { get; set; } = new();

    [JsonPropertyName("references")]
    public List<Reference> References { get; set; } = new();
}