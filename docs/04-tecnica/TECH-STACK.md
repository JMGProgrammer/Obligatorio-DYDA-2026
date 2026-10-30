# TECH-STACK | Tecnologías acordadas

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## 1. Stack establecido
| Capa | Tecnología | Responsabilidad |
|---|---|---|
| Backend | C#, ASP.NET Core Web API | Endpoints REST, validación, autorización, casos de uso, reglas de negocio |
| Presentación web | Blazor Web App (.NET, Razor Components) | Rutas, componentes, formularios, interacción y consumo HTTP de API |
| Persistencia | MySQL | BD central relacional, índices, restricciones, transacciones |
| Acceso a datos | Entity Framework Core **propuesto** | `DbContext`, mapeos, migraciones; si la materia exige ADO.NET u otro acceso, sustituir esta capa sin romper API |
| Contratos | JSON vía HTTPS + OpenAPI | Comunicación independiente del cliente |
| Cliente móvil posterior | Tecnología **no definida** | Consumir el mismo contrato; jamás conectar directamente a BD |
| Testing | xUnit o equivalente .NET; pruebas HTTP | Lógica, servicios, endpoints, integración MySQL |
| Herramientas | .NET SDK, IDE, Git, MySQL Workbench u otro gestor | Desarrollo y control de versiones |

## 2. Por qué no React, Node ni SQL Server
El stack no está abierto a elección libre: reemplazarlo por React/TypeScript, Node o SQL Server contradice los contenidos de la asignatura y la integración transversal. CSS y JavaScript auxiliar son admisibles para frontend, **no** como reimplementación del negocio.

## 3. Aclaración Blazor Pages
Microsoft denomina **Blazor Web App** al modelo moderno de interfaz por componentes `.razor`. **Razor Pages** usa `.cshtml` y es un modelo diferente. La recomendación técnica para esta guía es Blazor Web App con `InteractiveServer` para pantallas dinámicas; otras modalidades pueden revisarse. Documentación: https://learn.microsoft.com/aspnet/core/blazor/components/render-modes ; https://learn.microsoft.com/aspnet/core/web-api .

## 4. Versionado y dependencias
- No fijar números de versión en documentación antes de confirmar versión de .NET instalada y permitida por docentes.
- EF Core y el proveedor de MySQL deben compartir **versiones compatibles**; validar el soporte real antes de agregar paquetes.
- Usar un único SDK en `global.json` si el equipo lo necesita y una versión de MySQL reproducible.
- Compilar API y Blazor desde la misma solución; usar proyectos independientes para impedir acceso directo de Web a Infrastructure.

## 5. Decisiones técnicas sugeridas
| Decisión | Recomendación | Estado |
|---|---|---|
| API | Controladores `[ApiController]` + `ControllerBase` para facilitar evaluación académica | Propuesto |
| JSON | DTO separados de entidades EF | Recomendado |
| Renderizado | Interactive Server | Propuesto |
| Inyección de dependencias | Contenedor integrado de ASP.NET Core | Recomendado |
| Autenticación | Identity + esquema de acceso documentado para web/móvil | Pendiente |
| Logs | `ILogger<T>` y correlación de solicitudes | Recomendado |
| Versionado API | Prefijo `/api/v1` | Propuesto |
| Datos externos | Carga manual validada inicialmente | MVP |

## 6. Flujo de dependencia
`Blazor → HTTP → Api → Application → Domain` y `Api → Infrastructure → MySQL`. Un cliente móvil futuro recorre exactamente el mismo camino desde HTTP. Nunca `Blazor → DbContext` ni `Móvil → MySQL`.
