# BLAZOR | Aplicación web y consumo real de API

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Modelo elegido
**Blazor Web App** con páginas `.razor`, componentes reutilizables y modo **Interactive Server**. La expresión coloquial «Blazor Pages» se implementa aquí como páginas de componentes; **no** se sustituye por ASP.NET Core Razor Pages `.cshtml`.

## Regla de separación
`Reporteros.Web` no referencia `Reporteros.Api`, no contiene `DbContext` ni cadenas de conexión a MySQL. Todas las lecturas/escrituras de información deportiva van a `Reporteros.Api` mediante clientes `HttpClient` tipados. La base URL se obtiene de `Api:BaseUrl`; nunca se codifica dentro de componentes.

## Componentes/rutas
| Ruta | Página `.razor` | Servicio API |
|---|---|---|
| `/` | Home | `GetHighlightsAsync`, `GetMatchesAsync` |
| `/futbol` | SportLanding | `GetCompetitionsAsync` |
| `/basquetbol` | SportLanding | `GetCompetitionsAsync` |
| `/esports` | EsportsLanding | `GetCompetitionsAsync` |
| `/partidos` | Matches | `GetMatchesAsync` |
| `/partidos/{id}` | MatchDetail | `GetMatchAsync` |
| `/competiciones/{id}` | CompetitionDetail | `GetCompetitionAsync`, `GetStandingsAsync` |
| `/noticias` | News | `GetArticlesAsync` |
| `/noticias/{slug}` | ArticleDetail | `GetArticleAsync` |
| `/admin/*` | Backoffice | Endpoints protegidos de administración |

## Ejemplo orientativo de cliente tipado
```csharp
public sealed class MatchesApiClient(HttpClient http)
{
    public async Task<MatchSummaryDto?> GetAsync(long id, CancellationToken ct = default)
        => await http.GetFromJsonAsync<MatchSummaryDto>($"api/v1/matches/{id}", ct);
}
```
Registro orientativo en `Program.cs`:
```csharp
builder.Services.AddHttpClient<MatchesApiClient>(http =>
    http.BaseAddress = new Uri(builder.Configuration["Api:BaseUrl"]!));
```
La configuración real incorpora timeouts, errores, auth y seguridad. Este ejemplo **no** implementa token forwarding ni autoriza por sí solo solicitudes.

## Interacción y estados
Cada página maneja `loading`, `empty`, `error` y `success`; red local cortada produce aviso y reintento accesible. Formularios utilizan `EditForm`, validación de presentación y DTO de API; nunca confían exclusivamente en validación de UI.

## Autenticación y Interactive Server
Interactive Server ejecuta los componentes en el servidor y mantiene conexión interactiva con el navegador. Cuidar manejo de sesiones/circuitos y las credenciales en llamadas HTTP desde el servidor. No poner tokens sensibles en localStorage por defecto. Definir un esquema de sesión web con credenciales de API verificables, no asumir que compartir cookie entre API y Web funciona sin configuración explícita.

## Reutilización UI
Componentes: `ScoreCard`, `SportFilter`, `CompetitionCard`, `StandingsTable`, `NewsCard`, `SourceBadge`, `ErrorState`, `LoadingSkeleton`, `AdminForm`. No codificar resultados ni reglas del campeonato dentro de componentes.

## CSS y branding
Dark sports tech con azul noche, celeste, blanco y estados semánticos; variables en BRANDING.md. Objetivos: accesibilidad AA, 360px en móvil, foco visible, etiquetas y contrastes.

## Demostración evaluable
Cambiar resultado vía API y verificar que Blazor muestra la actualización al recargar; desconectar API y comprobar error, no fallback a MySQL. Probar un segundo cliente HTTP reutilizando endpoint.
