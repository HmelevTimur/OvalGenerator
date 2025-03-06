using System.Xml.Serialization;

namespace OVALGenerator.Domain.Entities.OvalModels;

public class Definition
{
    [XmlAttribute("class")]
    public string Class { get; set; } = "vulnerability";

    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute("version")]
    public int Version { get; set; } = 1;

    [XmlElement("metadata")]
    public Metadata Metadata { get; set; }

    [XmlElement("criteria")]
    public Criteria Criteria { get; set; }
}

public class Reference
{
    [XmlAttribute("source")]
    public string Source { get; set; }

    [XmlAttribute("ref_id")]
    public string RefId { get; set; }

    [XmlAttribute("ref_url")]
    public string RefUrl { get; set; }
}

public class Criteria
{
    [XmlAttribute("operator")]
    public string Operator { get; set; } = "AND"; 

    [XmlElement("criterion")]
    public List<Criterion> Criterions { get; set; } = new();
}

public class Criterion
{
    [XmlAttribute("comment")]
    public string Comment { get; set; }

    [XmlAttribute("test_ref")]
    public string TestRef { get; set; }
}

public class LocalVariable
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute("datatype")]
    public string DataType { get; set; }

    [XmlElement("object_component")]
    public ObjectComponent Component { get; set; }
}

public class TestObject
{
    [XmlAttribute("object_ref")]
    public string ObjectRef { get; set; }
}

public class StateValue
{
    [XmlAttribute("datatype")]
    public string DataType { get; set; }

    [XmlAttribute("operation")]
    public string Operation { get; set; }

    [XmlText]
    public string Value { get; set; }
}

public class ObjectComponent
{
    [XmlAttribute("item_field")]
    public string ItemField { get; set; }

    [XmlAttribute("object_ref")]
    public string ObjectRef { get; set; }
}