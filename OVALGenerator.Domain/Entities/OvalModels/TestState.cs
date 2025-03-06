using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class TestState
{
    [XmlAttribute("state_ref")]
    public string StateRef { get; set; }
}