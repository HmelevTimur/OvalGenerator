using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace OVALGenerator.Application.Helpers;

public static class FileResultHelper
{
    public static FileContentResult CreateXmlFile(string content, string fileName)
    {
        var xmlBytes = Encoding.UTF8.GetBytes(content);
        return new FileContentResult(xmlBytes, "application/xml")
        {
            FileDownloadName = $"{fileName}.xml"
        };
    }
}