# API — Contrato HTTP preliminar

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Contexto
API orientativa, independiente de lenguaje. Prefijo sugerido `/api/v1`. JSON UTF-8, timestamps ISO 8601 UTC, UI en zona `America/Montevideo`. La URL y autenticación finales dependen del stack.

## 2. Endpoints públicos
| Método | Ruta | Respuesta |
|---|---|---|
| GET | `/sports` | Disciplinas |
| GET | `/competitions?sport=football` | Lista paginada |
| GET | `/competitions/{id}/seasons` | Temporadas |
| GET | `/seasons/{id}/standings` | Tabla si aplica |
| GET | `/matches?date=YYYY-MM-DD&sport=football&page=1` | Agenda paginada |
| GET | `/matches/{id}` | Ficha y fuente |
| GET | `/teams/{id}` | Ficha de equipo |
| GET | `/articles?page=1` | Noticias publicadas |
| GET | `/articles/{slug}` | Detalle publicado |

## 3. Endpoints privados
| Método | Ruta | Rol mínimo |
|---|---|---|
| POST | `/admin/competitions` | Editor |
| POST | `/admin/seasons` | Editor |
| POST | `/admin/matches` | Editor |
| PATCH | `/admin/matches/{id}` | Editor |
| POST | `/admin/matches/{id}/results` | Editor (borrador) |
| POST | `/admin/results/{id}/approve` | Revisor |
| POST | `/admin/results/{id}/corrections` | Revisor |
| POST | `/admin/articles` | Editor |
| POST | `/admin/articles/{id}/publish` | Revisor |
| GET | `/admin/audit?entityType=match&entityId=...` | Admin/revisor según política |
| PATCH | `/admin/users/{id}/roles` | Admin |

## 4. Ejemplo de respuesta de encuentro
```json
{
  "id": "demo-match-001",
  "sport": "football",
  "competition": { "id": "demo-league", "name": "Liga de demostración" },
  "startsAt": "2026-11-07T19:00:00Z",
  "displayTimeZone": "America/Montevideo",
  "status": "final",
  "home": { "id": "team-01", "name": "Equipo A", "score": 2 },
  "away": { "id": "team-02", "name": "Equipo B", "score": 1 },
  "source": { "name": "Dataset de demostración", "verified": false },
  "updatedAt": "2026-11-08T00:00:00Z"
}
```
**Importante:** el ejemplo es ficticio y `verified: false` significa no oficial; si el sistema solo publica aprobados, diferenciar aprobación editorial de certificación institucional.

## 5. Errores
Formato propuesto `{ "error": { "code": "VALIDATION_ERROR", "message": "...", "fields": {"homeScore":"..."} } }`. HTTP 400 validación mal formada, 401 sin sesión, 403 sin privilegio, 404 no existe/no visible, 409 versión en conflicto, 422 regla de dominio, 500 error inesperado sin traza expuesta.

## 6. Paginación y filtros
`page`, `pageSize` con tope server-side, orden whitelist; parámetros validados; no concatenar entradas directamente en SQL. Exponer `total` o `hasNext` según coste.

## 7. Idempotencia, concurrencia y publicación
PATCH/POST de cambios relevantes incluyen `version` o `If-Match`; cambios en resultados/versiones generan auditoría transaccional. Publicar dos veces no debe duplicar resultado. Documentar permisos y respuesta por endpoint en OpenAPI si se elige API separada.
