using OVALGenerator.Application.Dtos;
using OVALGenerator.Domain.Entities;

namespace OVALGenerator.Application.Services.Interfaces;

public interface IOvalGeneratorService
{
    Task<string> GenerateAndSaveOvalAsync(CveRequest request);
}