using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class Metadata
{
    [XmlElement("title")]
    public string Title { get; set; }

    [XmlElement("affected")]
    public Affected Affected { get; set; }

    [XmlElement("reference")]
    public List<Reference> References { get; set; } = new();

    [XmlElement("description")]
    public string Description { get; set; }
}