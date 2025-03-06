using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class RegistryTest
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute("comment")]
    public string Comment { get; set; }

    [XmlAttribute("check")]
    public string Check { get; set; } = "at least one";

    [XmlElement("object")]
    public TestObject Object { get; set; }
    
    [XmlElement("state")]
    public TestState State { get; set; }
}