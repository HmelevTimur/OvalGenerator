using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OVALGenerator.Domain.Entities;

public class SecurityBulletinReport
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    
    [Required]
    [StringLength(20)]
    public string CveId { get; set; }
    
    [Required]
    [Column(TypeName = "xml")]
    public string OvalXml { get; set; }
}