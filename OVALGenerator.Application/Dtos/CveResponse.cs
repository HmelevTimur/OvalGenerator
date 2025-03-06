using System.Text.Json.Serialization;
using OVALGenerator.Domain.Entities;
using OVALGenerator.Domain.Entities.OvalModels;

namespace OVALGenerator.Application.Dtos;

public class CveResponse
{
    [JsonPropertyName("cveMetadata")]
    public CveMetadata CveMetadata { get; set; }

    [JsonPropertyName("containers")]
    public Containers Containers { get; set; }
}