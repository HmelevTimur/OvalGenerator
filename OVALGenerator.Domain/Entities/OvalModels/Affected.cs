using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class Affected
{
    [XmlElement("family")]
    public string Family { get; set; }

    [XmlElement("product")]
    public string Product { get; set; }
}