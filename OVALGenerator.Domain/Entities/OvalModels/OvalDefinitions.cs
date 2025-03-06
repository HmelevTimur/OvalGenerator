using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

[XmlRoot("oval_definitions", Namespace = "http://oval.mitre.org/XMLSchema/oval-definitions-5")]
public class OvalDefinitions
{
    [XmlElement("generator")]
    public OvalGenerator Generator { get; set; } = new();

    [XmlArray("definitions")]
    [XmlArrayItem("definition")]
    public List<Definition> Definitions { get; set; } = new();

    [XmlArray("tests")]
    [XmlArrayItem("registry_test", Namespace = "http://oval.mitre.org/XMLSchema/oval-definitions-5#windows")]
    public List<RegistryTest> Tests { get; set; } = new();

    [XmlArray("objects")]
    [XmlArrayItem("registry_object", Namespace = "http://oval.mitre.org/XMLSchema/oval-definitions-5#windows")]
    public List<RegistryObject> Objects { get; set; } = new();

    [XmlArray("states")]
    [XmlArrayItem("registry_state", Namespace = "http://oval.mitre.org/XMLSchema/oval-definitions-5#windows")]
    public List<RegistryState> States { get; set; } = new();

    [XmlArray("variables")]
    public List<LocalVariable> Variables { get; set; } = new();
}