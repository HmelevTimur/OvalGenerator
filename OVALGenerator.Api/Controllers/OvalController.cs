using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OVALGenerator.Application.Clients.Interfaces;
using OVALGenerator.Application.Dtos;
using OVALGenerator.Application.Services.Interfaces;
using OVALGenerator.Domain.Entities.OvalModels;

namespace OVALGenerator.Api.Controllers;

[ApiController]
[Route("api/oval")]
public class OvalController(
    IOvalGeneratorService ovalService,
    ICveApiClient cveApiClient,
    IMapper mapper)
    : ControllerBase
{
    [HttpPost("from-json")]
    public async Task<IActionResult> GenerateFromJson([FromBody] CveRequest cveRequest)
    {
        try
        {
            var xml = await ovalService.GenerateAndSaveOvalAsync(cveRequest);
            return Content(xml, "application/xml");
        }
        catch (AutoMapperMappingException ex)
        {
            return BadRequest($"Некорректный формат CVE: {ex.Message}");
        }
    }

    [HttpPost("from-url")]
    public async Task<IActionResult> GenerateFromUrl([FromBody] CveUrlRequest urlRequest)
    {
        try
        {
            var cveResponse = await cveApiClient.GetCveAsync(urlRequest.CveUrl);

            var cveRequest = mapper.Map<CveRequest>(cveResponse);

            var xml = await ovalService.GenerateAndSaveOvalAsync(cveRequest);
            return Content(xml, "application/xml");
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(502, $"Ошибка CVE апи: {ex.Message}");
        }
    }
}