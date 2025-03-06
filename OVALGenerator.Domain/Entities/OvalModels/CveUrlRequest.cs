using System.ComponentModel.DataAnnotations;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class CveUrlRequest
{
    [Required]
    [Url]
    public string CveUrl { get; set; }
}