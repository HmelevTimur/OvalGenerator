using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class RegistryState
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlElement("value")]
    public StateValue Value { get; set; }
}