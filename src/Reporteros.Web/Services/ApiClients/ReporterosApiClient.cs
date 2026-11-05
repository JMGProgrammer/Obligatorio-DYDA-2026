namespace Reporteros.Web.Services.ApiClients;

using System.Net.Http.Json;
using Reporteros.Web.DTOs;

// Cliente tipado de la API: las paginas inyectan esta clase y llaman metodos,
// sin conocer URLs ni detalles de HTTP. La BaseAddress se fija en Program.cs.
public sealed class ReporterosApiClient(HttpClient httpClient)
{
    private readonly HttpClient _http = httpClient;

    public async Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await _http.GetAsync("health", cancellationToken);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
        catch (TaskCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            return false;
        }
    }

    public async Task<List<DeporteReadDTO>> GetDeportesAsync(CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<DeporteReadDTO>>("api/v1/deportes", cancellationToken)
               ?? new List<DeporteReadDTO>();
    }

    public async Task<List<CompeticionReadDTO>> GetCompeticionesAsync(CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<CompeticionReadDTO>>("api/v1/competiciones", cancellationToken)
               ?? new List<CompeticionReadDTO>();
    }

    public async Task<List<TemporadaReadDTO>> GetTemporadasPorCompeticionAsync(long competicionId, CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<TemporadaReadDTO>>($"api/v1/temporadas/por-competicion/{competicionId}", cancellationToken)
               ?? new List<TemporadaReadDTO>();
    }

    public async Task<List<EquipoReadDTO>> GetEquiposAsync(CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<EquipoReadDTO>>("api/v1/equipos", cancellationToken)
               ?? new List<EquipoReadDTO>();
    }

    public async Task<List<StandingsReadDTO>> GetStandingsAsync(long temporadaId, CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<StandingsReadDTO>>($"api/v1/temporadas/{temporadaId}/clasificacion", cancellationToken)
               ?? new List<StandingsReadDTO>();
    }

    public async Task<List<PartidoReadDTO>> GetPartidosPorTemporadaAsync(long temporadaId, CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<PartidoReadDTO>>($"api/v1/partidos/por-temporada/{temporadaId}", cancellationToken)
               ?? new List<PartidoReadDTO>();
    }

    public async Task<List<PartidoReadDTO>> GetPartidosPorFechaAsync(DateTime fecha, long? deporteId = null, CancellationToken cancellationToken = default)
    {
        var url = $"api/v1/partidos?fecha={fecha:yyyy-MM-dd}";
        if (deporteId.HasValue)
            url += $"&deporteId={deporteId.Value}";
        return await _http.GetFromJsonAsync<List<PartidoReadDTO>>(url, cancellationToken)
               ?? new List<PartidoReadDTO>();
    }

    public async Task<CompeticionReadDTO> CrearCompeticionAsync(CompeticionCreateDTO input, CancellationToken cancellationToken = default)
    {
        var response = await _http.PostAsJsonAsync("api/v1/competiciones", input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var detalle = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Error {(int)response.StatusCode}: {detalle}");
        }
        return await response.Content.ReadFromJsonAsync<CompeticionReadDTO>(cancellationToken)
               ?? throw new InvalidOperationException("La API respondio sin datos.");
    }

    public async Task<PartidoReadDTO> CrearPartidoAsync(PartidoCreateDTO input, CancellationToken cancellationToken = default)
    {
        var response = await _http.PostAsJsonAsync("api/v1/partidos", input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var detalle = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Error {(int)response.StatusCode}: {detalle}");
        }
        return await response.Content.ReadFromJsonAsync<PartidoReadDTO>(cancellationToken)
               ?? throw new InvalidOperationException("La API respondio sin datos.");
    }

    public async Task<List<ArticuloReadDTO>> GetArticulosAsync(CancellationToken cancellationToken = default)
    {
        return await _http.GetFromJsonAsync<List<ArticuloReadDTO>>("api/v1/articulos", cancellationToken)
               ?? new List<ArticuloReadDTO>();
    }

    public async Task<ArticuloReadDTO?> GetArticuloPorSlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var response = await _http.GetAsync($"api/v1/articulos/{slug}", cancellationToken);
        if (!response.IsSuccessStatusCode)
            return null;
        return await response.Content.ReadFromJsonAsync<ArticuloReadDTO>(cancellationToken);
    }

    public async Task<ArticuloReadDTO> CrearArticuloAsync(ArticuloCreateDTO input, CancellationToken cancellationToken = default)
    {
        var response = await _http.PostAsJsonAsync("api/v1/admin/articulos", input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var detalle = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Error {(int)response.StatusCode}: {detalle}");
        }
        return await response.Content.ReadFromJsonAsync<ArticuloReadDTO>(cancellationToken)
               ?? throw new InvalidOperationException("La API respondio sin datos.");
    }

    public async Task<PartidoReadDTO> PublicarResultadoAsync(long id, long editorId, PartidoResultadoDTO input, CancellationToken cancellationToken = default)
    {
        var response = await _http.PutAsJsonAsync($"api/v1/partidos/{id}/resultado?editorId={editorId}", input, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var detalle = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Error {(int)response.StatusCode}: {detalle}");
        }
        return await response.Content.ReadFromJsonAsync<PartidoReadDTO>(cancellationToken)
               ?? throw new InvalidOperationException("La API respondio sin datos.");
    }

    public async Task<ArticuloReadDTO> PublicarArticuloAsync(long id, CancellationToken cancellationToken = default)
    {
        var response = await _http.PostAsync($"api/v1/admin/articulos/{id}/publish", null, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var detalle = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Error {(int)response.StatusCode}: {detalle}");
        }
        return await response.Content.ReadFromJsonAsync<ArticuloReadDTO>(cancellationToken)
               ?? throw new InvalidOperationException("La API respondio sin datos.");
    }
}
