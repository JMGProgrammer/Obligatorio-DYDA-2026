# PROJECT-STRUCTURE | Solución .NET

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Árbol recomendado (propuesta, no código generado)
```text
REPORTEROS/
├── Reporteros.sln
├── src/
│   ├── Reporteros.Api/
│   │   ├── Controllers/
│   │   ├── Middleware/
│   │   ├── Program.cs
│   │   └── appsettings.json
│   ├── Reporteros.Application/
│   │   ├── Abstractions/
│   │   ├── Matches/
│   │   ├── Competitions/
│   │   └── Articles/
│   ├── Reporteros.Domain/
│   │   ├── Entities/
│   │   ├── Enums/
│   │   ├── Rules/
│   │   └── Exceptions/
│   ├── Reporteros.Infrastructure/
│   │   ├── Persistence/
│   │   │   ├── ReporterosDbContext.cs
│   │   │   ├── Configurations/
│   │   │   └── Migrations/
│   │   ├── Repositories/
│   │   └── Identity/
│   ├── Reporteros.Contracts/
│   │   ├── Matches/
│   │   ├── Competitions/
│   │   └── Articles/
│   └── Reporteros.Web/
│       ├── Components/
│       │   ├── Layout/
│       │   ├── Pages/
│       │   └── Shared/
│       ├── Services/ApiClients/
│       ├── wwwroot/
│       └── Program.cs
├── tests/
│   ├── Reporteros.Domain.Tests/
│   ├── Reporteros.Api.IntegrationTests/
│   └── Reporteros.Web.Tests/
├── docs/
└── README.md
```

## Reglas de referencias
`Domain` sin referencias internas; `Application` depende de `Domain`; `Infrastructure` depende de `Application` y `Domain`; `Api` compone `Application`, `Infrastructure`, `Contracts`; `Web` depende de `Contracts` y consume **Api por HTTP**, nunca `Infrastructure`. Los DTO del contrato no contienen modelos EF ni contraseñas.

## Convenciones
- PascalCase en tipos, métodos y propiedades C#; camelCase en JSON.
- `CancellationToken` en operaciones async; `async/await` de punta a punta.
- `Get...Query`, `Create...Command` opcionales; evitar CQRS completo si excede curso.
- Controladores delgados; validación de entrada y autorización en API, reglas de dominio en Application/Domain.
- `DateTimeOffset` o UTC representado inequívocamente; mostrar horarios en America/Montevideo en clientes.
- Secrets locales fuera de repositorio; `.gitignore` para bin/obj y archivos privados.

## Primer corte vertical
`GET /api/v1/competitions` → servicio → repositorio → MySQL → JSON → `CompetitionApiClient` → `Competitions.razor`; prueba HTTP y prueba de integración. Repetir patrón para encuentros, noticias y administración.
