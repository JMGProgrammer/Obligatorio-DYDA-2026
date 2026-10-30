# PROJECT-STRUCTURE | Solución .NET

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Árbol base del monorepo
```text
REPORTEROS/
├── Reporteros.sln
├── global.json
├── .editorconfig
├── .github/workflows/ci.yml
├── src/
│   ├── Reporteros.Api/
│   │   ├── Controllers/
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   ├── Models/
│   │   ├── Services/
│   │   ├── Program.cs
│   │   └── appsettings.json
│   └── Reporteros.Web/
│       ├── Components/
│       │   ├── Layout/
│       │   ├── Pages/
│       │   └── Shared/
│       ├── Services/ApiClients/
│       ├── wwwroot/
│       └── Program.cs
├── mobile/                 # Expo + React Native; última etapa
├── docs/
├── assets/
└── README.md
```

La solución contiene únicamente los dos proyectos `.NET`. Las carpetas de API se crean al implementar el primer caso real; no se agregan archivos vacíos solo para representar arquitectura. Los proyectos de pruebas se incorporarán junto con pruebas reales.

## Reglas de separación
- `Controllers`: frontera HTTP, autorización, mapeo y códigos de respuesta; deben ser delgados.
- `Services`: casos de uso y reglas del producto; no dependen de Blazor.
- `DTOs`: contratos JSON; nunca exponen entidades persistentes ni credenciales.
- `Models`: entidades y conceptos internos del negocio.
- `Interfaces`: abstracciones cuando exista más de una implementación o sea útil para probar.
- `Reporteros.Web`: consume **Api por HTTP** mediante `Services/ApiClients`; no referencia el proyecto API.
- `mobile/`: consume el mismo contrato HTTP/OpenAPI y no forma parte de `Reporteros.sln`.

## Convenciones
- PascalCase en tipos, métodos y propiedades C#; camelCase en JSON.
- `CancellationToken` en operaciones async; `async/await` de punta a punta.
- `Get...Query`, `Create...Command` opcionales; evitar CQRS completo si excede curso.
- Controladores delgados; validación de entrada y autorización en API, reglas de dominio en `Services`/`Models`.
- `DateTimeOffset` o UTC representado inequívocamente; mostrar horarios en America/Montevideo en clientes.
- Secrets locales fuera de repositorio; `.gitignore` para bin/obj y archivos privados.

## Primer corte vertical
`GET /api/v1/competitions` → servicio → repositorio → MySQL → JSON → `CompetitionApiClient` → `Competitions.razor`; prueba HTTP y prueba de integración. Repetir patrón para encuentros, noticias y administración.
