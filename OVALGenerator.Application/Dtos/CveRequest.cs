namespace OVALGenerator.Application.Dtos;

public class CveRequest
{
    public string CveId { get; set; }
    public string Product { get; set; }
    public string FixedVersion { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}