using System.Net.Http.Headers;
using System.Net.Http.Json;
using OVALGenerator.Application.Clients.Interfaces;
using OVALGenerator.Application.Dtos;

namespace OVALGenerator.Application.Clients.Implementations;

public class CveApiClient : ICveApiClient
{
    private readonly HttpClient _httpClient;

    public CveApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<CveResponse?> GetCveAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CveResponse>();
    }
}