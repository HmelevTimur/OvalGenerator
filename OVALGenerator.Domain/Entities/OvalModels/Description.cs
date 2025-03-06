using System.Text.Json.Serialization;

namespace OVALGenerator.Application.Dtos
{
    public class Description
    {
        [JsonPropertyName("value")] public string Value { get; set; }
    }
}

namespace OVALGenerator.Domain.Entities
{
    public class Description
    {
        [JsonPropertyName("lang")]
        public string Language { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}