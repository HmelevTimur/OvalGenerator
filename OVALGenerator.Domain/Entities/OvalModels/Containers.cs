using System.Text.Json.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class Containers
{
    [JsonPropertyName("cna")]
    public CnaContainer Cna { get; set; }
}