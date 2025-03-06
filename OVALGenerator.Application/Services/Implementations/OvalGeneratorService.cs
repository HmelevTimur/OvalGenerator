using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using OVALGenerator.Application.Dtos;
using OVALGenerator.Application.Repositoryes.Interfaces;
using OVALGenerator.Application.Services.Interfaces;
using OVALGenerator.Domain.Entities;
using OVALGenerator.Domain.Entities.OvalModels;
using Affected = OVALGenerator.Domain.Entities.OvalModels.Affected;
using Reference = OVALGenerator.Domain.Entities.OvalModels.Reference;

namespace OVALGenerator.Application.Services.Implementations;

public class OvalGeneratorService(
    IOvalReportRepository repository,
    IMapper mapper) : IOvalGeneratorService
{
    public async Task<string> GenerateAndSaveOvalAsync(CveRequest request)
    {
        var cveData = mapper.Map<CveData>(request);
        var oval = GenerateOvalDefinition(cveData);
        var xml = SerializeOval(oval);
        
        await SaveReportAsync(cveData.Id, xml);
        return xml;
    }

    private async Task SaveReportAsync(string cveId, string xml)
    {
        var report = new SecurityBulletinReport
        {
            CveId = cveId,
            OvalXml = xml
        };
        await repository.SaveReportAsync(report);
    }

    private OvalDefinitions GenerateOvalDefinition(CveData cve)
    {
        return new OvalDefinitions
        {
            Generator = new OvalGenerator
            {
                ProductName = "Acronis OVAL Generator",
                SchemaVersion = "5.11.1",
                Timestamp = DateTime.UtcNow
            },
            Definitions = { CreateVulnerabilityDefinition(cve) },
            Tests = { CreateInstallationTest(), CreateVersionTest() },
            Objects = CreateRegistryObjects(),
            States = { CreateVersionState(cve) },
            Variables = { CreatePathVariable() }
        };
    }

    private Definition CreateVulnerabilityDefinition(CveData cve)
    {
        var definition = new Definition
        {
            Id = $"oval:com.acronis.def:{cve.Id}",
            Metadata = new Metadata
            {
                Title = $"{cve.Product} Vulnerability ({cve.Id})", 
                Description = cve.Description,
                Affected = new Affected
                {
                    Family = "windows",
                    Product = cve.Product
                },
                References = new List<Reference>()
            },
            Criteria = new Criteria
            {
                Operator = "AND",
                Criterions =
                {
                    new Criterion
                    {
                        TestRef = "oval:com.acronis.tst:installation",
                        Comment = "Product installation check"
                    },
                    new Criterion
                    {
                        TestRef = "oval:com.acronis.tst:version",
                        Comment = "Version vulnerability check"
                    }
                }
            }
        };

        definition.Metadata.References.Add(new Reference
        {
            Source = "CVE",
            RefId = cve.Id,
            RefUrl = cve.Url
        });

        return definition;
    }

    private RegistryTest CreateVersionTest()
    {
        return new RegistryTest
        {
            Id = "oval:com.acronis.tst:version",
            Comment = "Check product version",
            Object = new TestObject { ObjectRef = "oval:com.acronis.obj:version" },
            State = new TestState { StateRef = "oval:com.acronis.ste:version" }
        };
    }

    private List<RegistryObject> CreateRegistryObjects()
    {
        return new List<RegistryObject>
        {
            new RegistryObject
            {
                Id = "oval:com.acronis.obj:install",
                Hive = "HKEY_LOCAL_MACHINE",
                Key = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\*",
                Name = "DisplayName"
            },
            new RegistryObject
            {
                Id = "oval:com.acronis.obj:version",
                Hive = "HKEY_LOCAL_MACHINE",
                Key = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\*",
                Name = "DisplayVersion"
            }
        };
    }

    private LocalVariable CreatePathVariable()
    {
        return new LocalVariable
        {
            Id = "oval:com.acronis.var:path",
            DataType = "string",
            Component = new ObjectComponent
            {
                ItemField = "key",
                ObjectRef = "oval:com.acronis.obj:install"
            }
        };
    }

    private string SerializeOval(OvalDefinitions oval)
    {
        var serializer = new XmlSerializer(typeof(OvalDefinitions));
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("oval", "http://oval.mitre.org/XMLSchema/oval-definitions-5");
        namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

        using var writer = new StringWriter();
        using var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            OmitXmlDeclaration = false
        });

        serializer.Serialize(xmlWriter, oval, namespaces);
        return writer.ToString();
    }

    private RegistryTest CreateInstallationTest()
    {
        return new RegistryTest
        {
            Id = "oval:com.acronis.tst:installation",
            Comment = "Check product installation",
            Object = new TestObject { ObjectRef = "oval:com.acronis.obj:install" }
        };
    }

    private RegistryState CreateVersionState(CveData cve)
    {
        return new RegistryState
        {
            Id = "oval:com.acronis.ste:version",
            Value = new StateValue
            {
                DataType = "version",
                Operation = "less than",
                Value = cve.FixedVersion ?? "0"
            }
        };
    }
}