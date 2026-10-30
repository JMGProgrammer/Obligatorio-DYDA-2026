# ARCHITECTURE | Arquitectura API-first

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Principio rector
Un único backend ASP.NET Core concentra la lógica. Blazor es **un consumidor** de la API, al igual que la futura app móvil. Comparten datos, autorizaciones y decisiones de negocio.

```mermaid
flowchart TB
  W[Blazor Web App] -->|HTTPS JSON| API[ASP.NET Core Web API]
  MOB[Expo + React Native] -->|HTTPS JSON| API
  TEST[Cliente de prueba / Postman] -->|HTTPS JSON| API
  API --> APP[Services: casos de uso]
  APP --> DOMAIN[Models: entidades y reglas]
  API --> AUTH[Autenticación / autorización]
  APP --> PORT[Interfaces / repositorios]
  PORT --> DB[(MySQL)]
  APP --> AUD[Auditoría y trazabilidad]
```

## Módulos de dominio
1. Catálogo: deportes, videojuegos, competiciones, temporadas, equipos.
2. Partidos: agenda, estados, participantes, marcadores, confirmación y correcciones.
3. Clasificaciones: cálculo según reglamento de cada modalidad; sin forzar un criterio universal.
4. Editorial: noticias, borradores, revisión, publicación y procedencia.
5. Usuarios: roles, autorización y sesiones.
6. Fuentes: origen, fecha, fiabilidad declarada y responsable de carga.
7. Auditoría: acciones sensibles y versiones.

## Responsabilidades estrictas
| Área | Puede | No puede |
|---|---|---|
| `Api/Controllers` | HTTP, auth, mapeo DTO, status codes, OpenAPI | Concentrar reglas o SQL ad hoc |
| `Api/Services` | Casos de uso, validaciones y políticas de publicación | Componentes UI |
| `Api/Models` | Entidades, value objects e invariantes | Depender de Blazor |
| `Api/DTOs` | DTO públicos y esquemas de contrato | Exponer entidades persistentes / DbContext |
| `Api/Repositories` | Acceso a datos y consultas | Definir reglas de presentación |
| `Reporteros.Web` | Rutas, componentes, cliente HTTP tipado, estados UI | Acceder a MySQL, calcular tablas oficiales |
| `mobile/` | UI React Native, estado local y consumo HTTP | Referenciar C# o acceder a MySQL |

## Escenario completo: publicación de resultado
1. Editor inicia sesión y registra marcador desde Blazor.
2. Blazor envía `PUT /api/v1/admin/matches/{id}/result` con token/cookie según diseño definitivo y `version`.
3. API valida autorización y estructura de entrada; `Services` comprueba coherencia y transición de estado.
4. La capa de acceso a datos actualiza MySQL y auditoría en **una transacción**.
5. API responde JSON con nuevo estado, versión y `updatedAt`.
6. Blazor vuelve a consultar `GET /api/v1/matches/{id}`; cualquier cliente móvil obtiene la misma información pública.
7. Posiciones se recalculan de resultados oficiales de manera definida; los borradores no afectan resultados visibles.

## Gestión de fallos
- API fuera de servicio: web muestra error recuperable, sin lectura directa de BD como atajo.
- MySQL fuera de servicio: API responde estado adecuado y registra fallo interno sin revelar credenciales.
- Token expirado: cliente reautentica; nunca conserva permisos de forma local como autoridad.
- Error de validación: `400/422`, `ProblemDetails` y errores por campo.
- Edición concurrente: `409 Conflict` con explicación y recarga de entidad.

## Integridad y transacciones
Los cambios en resultado y bitácora son atómicos; FK y unicidad en BD complementan las validaciones del dominio. Evitar microservicios, colas o actualización en vivo compleja para el MVP. La arquitectura es **monolito modular con API pública interna**.
