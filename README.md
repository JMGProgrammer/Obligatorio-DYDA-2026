<p align="center">
  <img src="assets/Reporteros-banner.png" alt="REPORTEROS — Centro de información deportiva uruguaya" width="100%">
</p>

# REPORTEROS | Documentación integral v2

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: monorepo base inicializado con .NET 10; persistencia y funcionalidades pendientes.

## Objetivo
REPORTEROS reúne la información del deporte uruguayo: **fútbol, básquetbol y esports**, con especial atención al ecosistema de AUDV cuando existan datos y permisos verificables. El nombre une **reporteros** y **teros** (ave nacional). Es una plataforma editorial e informativa, no una herramienta de inscripción de torneos.

## Arquitectura obligatoria del trabajo integrador
```mermaid
flowchart LR
  U[Usuarios web] --> B[Blazor Web App - .NET]
  B -->|HTTP/JSON| A[ASP.NET Core Web API - C#]
  M[Expo + React Native] -->|HTTP/JSON| A
  A --> S[Servicios / dominio]
  S --> R[Repositorios / EF Core]
  R --> D[(MySQL)]
```
**Regla esencial:** Blazor y móvil **no consultan MySQL directamente**. Toda escritura, autorización, validación y regla de negocio reside detrás de la API. La API es el contrato estable entre materias. Blazor no debe replicar reglas del servidor.

## Decisiones cerradas y pendientes
| Elemento | Estado |
|---|---|
| Marca | REPORTEROS |
| Alcance temático | Fútbol, básquetbol, esports uruguayos |
| Backend | ASP.NET Core Web API en C# |
| Base de datos | MySQL |
| Aplicación web | Blazor Web App (componentes Razor `.razor`), consumidora HTTP de la API |
| Cliente móvil | Expo + React Native, validado en desarrollo con Expo Go; se implementará al final |
| ORM | EF Core + proveedor MySQL **propuesto**, sujeto a compatibilidad de versiones |
| Renderizado Blazor | Interactive Server |
| Auth | ASP.NET Core Identity / tokens o cookies según frontera, decisión por cerrar |
| Competiciones y proveedores de datos | Pendiente de selección y validación |

**Terminología:** en la conversación se indicó «Blazor Pages». La especificación adopta **Blazor Web App con páginas de componentes Razor**, no el framework separado **ASP.NET Core Razor Pages** (`.cshtml`). Confirmar este matiz con el profesor.

## Índice documental
- [OVERVIEW.md](docs/01-producto/OVERVIEW.md)
- [SCOPE.md](docs/01-producto/SCOPE.md)
- [STAKEHOLDERS.md](docs/01-producto/STAKEHOLDERS.md)
- [BUSINESS-RULES.md](docs/02-requisitos/BUSINESS-RULES.md)
- [REQUIREMENTS.md](docs/02-requisitos/REQUIREMENTS.md)
- [USER-STORIES.md](docs/02-requisitos/USER-STORIES.md)
- [DESIGN.md](docs/03-diseno/DESIGN.md)
- [INFORMATION-ARCHITECTURE.md](docs/03-diseno/INFORMATION-ARCHITECTURE.md)
- [API-CONTRACTS.md](docs/04-tecnica/API-CONTRACTS.md)
- [API.md](docs/04-tecnica/API.md)
- [ARCHITECTURE.md](docs/04-tecnica/ARCHITECTURE.md)
- [AUTHENTICATION.md](docs/04-tecnica/AUTHENTICATION.md)
- [BLAZOR.md](docs/04-tecnica/BLAZOR.md)
- [DATA-SOURCES.md](docs/04-tecnica/DATA-SOURCES.md)
- [DATABASE.md](docs/04-tecnica/DATABASE.md)
- [DEPLOYMENT.md](docs/04-tecnica/DEPLOYMENT.md)
- [MOBILE-INTEGRATION.md](docs/04-tecnica/MOBILE-INTEGRATION.md)
- [PROJECT-STRUCTURE.md](docs/04-tecnica/PROJECT-STRUCTURE.md)
- [SECURITY.md](docs/04-tecnica/SECURITY.md)
- [TECH-STACK.md](docs/04-tecnica/TECH-STACK.md)
- [QUALITY.md](docs/05-calidad/QUALITY.md)
- [TEST-PLAN.md](docs/05-calidad/TEST-PLAN.md)
- [DECISIONS.md](docs/06-gestion/DECISIONS.md)
- [RISKS.md](docs/06-gestion/RISKS.md)
- [ROADMAP.md](docs/06-gestion/ROADMAP.md)
- [TEAM-WORKFLOW.md](docs/06-gestion/TEAM-WORKFLOW.md)
- [BRANDING.md](docs/07-identidad/BRANDING.md)
- [MASTER-BRANDING-Y-PRODUCTO.md](docs/07-identidad/MASTER-BRANDING-Y-PRODUCTO.md)

## Estructura del monorepo

```text
Reporteros.sln
├── src/
│   ├── Reporteros.Api/     # HTTP, servicios, modelos y acceso a datos
│   └── Reporteros.Web/     # Blazor Web App; consume la API por HTTP
├── mobile/                 # Expo + React Native (última etapa)
├── docs/
└── assets/
```

La solución `.NET` contiene únicamente `Reporteros.Api` y `Reporteros.Web`. El cliente móvil no forma parte de `Reporteros.sln`; comparte exclusivamente el contrato HTTP/JSON.

## Desarrollo local

### Requisitos

- .NET SDK 10 (el rango compatible está fijado en `global.json`).
- Git.
- MySQL se incorporará al comenzar persistencia.

### Restaurar y compilar

```bash
dotnet restore Reporteros.sln
dotnet build Reporteros.sln
```

### Ejecutar

En dos terminales:

```bash
dotnet run --project src/Reporteros.Api
dotnet run --project src/Reporteros.Web
```

| Servicio | HTTP | HTTPS |
|---|---|---|
| API | `http://localhost:5279` | `https://localhost:7045` |
| Web | `http://localhost:5188` | `https://localhost:7189` |

Comprobación rápida de la API:

```bash
curl http://localhost:5279/health
```

OpenAPI está disponible en desarrollo en `/openapi/v1.json`. La URL local que usa Blazor se configura mediante `Api:BaseUrl` en `src/Reporteros.Web/appsettings.json` y puede sobrescribirse por ambiente.

## Primer corte funcional

Implementar una vertical completa de competiciones: controlador API → servicio → datos → DTO JSON → `ReporterosApiClient` → componente Blazor. Después repetir el patrón para partidos, noticias y administración.

## Criterio de éxito transversal
Una corrección autorizada de resultado realizada por la API actualiza la información que obtiene Blazor y que obtendrá un cliente móvil, sin duplicar consultas SQL, validaciones ni fórmulas de posiciones en cada frontend.
