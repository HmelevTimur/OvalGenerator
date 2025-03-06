using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class RegistryObject
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlElement("hive")]
    public string Hive { get; set; }

    [XmlElement("key")]
    public string Key { get; set; }

    [XmlElement("name")]
    public string Name { get; set; }
}