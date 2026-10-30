# API-CONTRACTS | DTO y compatibilidad de clientes

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Contrato externo central
La Web Blazor y el móvil futuro deben recibir **la misma estructura JSON**, sin filtrar modelos EF ni depender de componentes Razor.

### MatchSummaryDto (ejemplo)
```json
{
  "id": 42,
  "sport": {"id": 1, "slug": "futbol", "name": "Fútbol"},
  "competition": {"id": 4, "name": "Competencia de demostración"},
  "scheduledAt": "2026-10-30T20:00:00Z",
  "status": "finished",
  "home": {"id": 100, "name": "Equipo A", "score": 2},
  "away": {"id": 101, "name": "Equipo B", "score": 1},
  "source": {"label": "Carga editorial de prueba", "verified": false},
  "updatedAt": "2026-10-30T22:30:00Z",
  "version": 3
}
```
Datos enteramente **ficticios**; no son resultados oficiales.

### PagedResponse<T>
```json
{"items": [], "page": 1, "pageSize": 20, "totalItems": 0}
```

### ProblemDetails ilustrativo
```json
{"type":"https://httpstatuses.com/409","title":"Conflicto de versión","status":409,"detail":"El registro cambió desde su última lectura.","traceId":"example"}
```

## Política de compatibilidad
- Agregar campos opcionales sin romper clientes previos.
- No renombrar ni modificar semántica de campos en `/v1`.
- Si cambia contrato de modo incompatible, negociar `/api/v2`.
- Nunca interpretar `0` como dato desconocido: para marcador no informado, usar `null` y `status` apropiado.
- Clientes deben manejar propiedades opcionales, estados desconocidos y `429/503` con reintentos limitados.

## Catálogos compartidos
Valores de estado recomendados: `scheduled`, `in_progress` **solo con fuente genuina**, `pending_review`, `finished`, `postponed`, `cancelled`. Para noticias: `draft`, `in_review`, `published`, `archived`. Acordar nombres exactos con implementación y documentar enums.

## Pruebas de contrato
Capturar esquema OpenAPI y validar: Serialización, compatibilidad con `Reporteros.Web` y consumidor de demostración independiente (curl/Postman). El cliente móvil futuro puede incorporar pruebas automáticas basadas en OpenAPI.
