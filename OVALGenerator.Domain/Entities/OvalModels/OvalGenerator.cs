using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class OvalGenerator
{
    [XmlElement("product_name", Namespace = "http://oval.mitre.org/XMLSchema/oval-common-5")]
    public string ProductName { get; set; }
    
    [XmlElement("schema_version", Namespace = "http://oval.mitre.org/XMLSchema/oval-common-5")]
    public string SchemaVersion { get; set; }
    
    [XmlElement("timestamp", Namespace = "http://oval.mitre.org/XMLSchema/oval-common-5")]
    public DateTime Timestamp { get; set; }
}