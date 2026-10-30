# API | Contrato REST ASP.NET Core

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Base técnica
ASP.NET Core Web API (`ControllerBase`, `[ApiController]`), JSON por HTTPS, prefijo `/api/v1`. La API es la única puerta de acceso a dominio y MySQL para Blazor y móvil. Versionar cambios incompatibles y publicar OpenAPI.

## Endpoints base
| Método | Ruta | Público | Función |
|---|---|---|---|
| GET | `/api/v1/sports` | Sí | Deportes y videojuegos asociados |
| GET | `/api/v1/competitions` | Sí | Listado con filtros |
| GET | `/api/v1/competitions/{id}` | Sí | Ficha de competición |
| GET | `/api/v1/competitions/{id}/seasons` | Sí | Temporadas |
| GET | `/api/v1/seasons/{id}/standings` | Sí | Tabla calculada cuando aplique |
| GET | `/api/v1/matches?date=YYYY-MM-DD&sportId=...` | Sí | Agenda y resultados filtrados |
| GET | `/api/v1/matches/{id}` | Sí | Ficha de partido publicado |
| GET | `/api/v1/teams/{id}` | Sí | Ficha de equipo |
| GET | `/api/v1/articles?page=1&pageSize=20` | Sí | Noticias publicadas |
| GET | `/api/v1/articles/{slug}` | Sí | Detalle editorial |
| POST | `/api/v1/auth/login` | No | Ingreso según esquema acordado |
| POST | `/api/v1/auth/logout` | No | Cierre según esquema acordado |
| POST | `/api/v1/admin/competitions` | Editor/Admin | Crear competencia |
| POST | `/api/v1/admin/matches` | Editor/Admin | Programar partido |
| PUT | `/api/v1/admin/matches/{id}/result` | Revisor/Admin | Publicar/corregir resultado |
| POST | `/api/v1/admin/articles` | Editor/Admin | Crear borrador |
| POST | `/api/v1/admin/articles/{id}/publish` | Revisor/Admin | Publicar noticia |
| GET | `/api/v1/admin/audit` | Admin | Historial paginado |

## Contratos generales
- Respuestas `200`/`201`/`204`; `400` para DTO inválido; `401` no autenticado; `403` sin permiso; `404` no visible/inexistente; `409` versión/estado incompatible; `500` interno sin fuga de detalles.
- `application/json` en solicitudes y respuestas normales; `application/problem+json` para errores usando `ProblemDetails`.
- Paginación obligatoria en colecciones: `page`, `pageSize` con límites de servidor y `total` o cursor.
- Fechas ISO-8601 con zona/UTC; no enviar texto ambiguo como `30/10 21:00`.
- `status`, `source`, `updatedAt` y `isOfficial` o designación equivalente visibles en DTO públicos donde corresponda.
- Nombres de campos camelCase; contratos DTO estables y sin entidades EF ni hashes.

## Autorización
Separar `api/v1/admin/*` de lectura pública; aplicar `[Authorize(Policy=...)]` y validación a nivel de recursos cuando corresponda. **CORS no es autenticación.** En Interactive Server, las solicitudes API pueden ejecutarse desde servidor web; para móvil se requiere esquema compatible con cliente remoto, aún por especificar.

## Ejemplo de request
```http
PUT /api/v1/admin/matches/42/result
Content-Type: application/json
Authorization: Bearer <token>

{"homeScore":2,"awayScore":1,"status":"finished","version":3,"reason":"Acta revisada"}
```
*El encabezado Bearer es ilustrativo y depende de la decisión final de autenticación; no implica tokens emitidos actualmente.*

## Testing obligatorio
Para cada endpoint: happy path, validación, 401, 403, 404, 409 y serialización; ejecutar consultas a través de HTTP, no directamente al servicio desde Blazor.
