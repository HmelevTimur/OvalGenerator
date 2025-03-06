namespace OVALGenerator.Application.Dtos;

public class CveData
{
    public string Id { get; set; }
    public string Product { get; set; }
    public string Description { get; set; }
    public string FixedVersion { get; set; }
    public string Url { get; set; }
    public List<string> Platforms { get; set; } 
}