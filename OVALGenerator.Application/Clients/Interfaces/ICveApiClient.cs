using OVALGenerator.Application.Dtos;

namespace OVALGenerator.Application.Clients.Interfaces;

public interface ICveApiClient
{
    Task<CveResponse?> GetCveAsync(string url);
}