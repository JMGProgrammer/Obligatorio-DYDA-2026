# DECISIONS — Registro de decisiones (ADR)

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Decisiones acordadas
| ID | Tema | Estado | Resolución | Justificación |
|---|---|---|---|---|
| ADR-001 | Nombre | **Aprobado** | REPORTEROS | Reporteros + teros, identidad nacional |
| ADR-002 | Producto | **Aprobado** | Centro de información deportiva de Uruguay | Enfoque editorial e informativo |
| ADR-003 | Disciplinas | **Aprobado** | Fútbol, básquetbol, esports | Foco expresado por el equipo |
| ADR-004 | Esports | **Aprobado como enfoque** | Contemplar AUDV como referencia de ecosistema | No afirma asociación ni acceso a datos |
| ADR-005 | Identidad visual | **Propuesta** | Sports Editorial/Dark Tech, celeste/azul noche | Requiere aprobación final visual |
| ADR-006 | Eslogan | **Propuesta** | «El deporte uruguayo tiene quien lo cuente.» | Mensaje institucional; no aprobación explícita |
| ADR-007 | MVP | **Propuesta** | Portal + administración/editorial + resultados aprobados | Evita excesos de alcance |
| ADR-008 | Datos en vivo | **Fuera de MVP propuesto** | Sin garantía de tiempo real | Dependencia de fuentes |

## Decisiones abiertas o por concretar
| ID | Pregunta | Alternativas | Criterio para resolver |
|---|---|---|---|
| ADR-009 | Stack académico | **Cerrado: ASP.NET Core Web API + Blazor Web App + MySQL** | Integración entre materias |
| ADR-010 | Competiciones específicas | Reales con licencia / sintéticas | Disponibilidad y verificación |
| ADR-011 | Modelo de clasificación | Reglas por competición/formato | Confirmación de reglas |
| ADR-012 | Autorización editorial | Editor publica / revisor separado | Carga de equipo y seguridad |
| ADR-013 | Hosting | Local / demo / público | Recursos y exigencia docente |
| ADR-014 | Representación de brackets | Entidad fase/enfrentamiento dedicada | Formatos elegidos |
| ADR-015 | Responsables | Asignación por integrantes | Acuerdo del equipo |

## Plantilla ADR
**Contexto:** problema y restricciones. **Opciones:** alternativas con ventajas y costos. **Decisión:** una sola, fecha, personas. **Consecuencias:** migraciones, código, pruebas, documentación. **Revisión:** condiciones para reconsiderar.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## ADR-016 — Stack académico fijado (APROBADO POR EL EQUIPO)
- **Decisión:** API ASP.NET Core/C# sobre .NET 10, MySQL, web Blazor Web App y móvil Expo + React Native consumidor de API.
- **Contexto:** integración entre materias; lógica única compartida; contenidos enseñados en curso.
- **Consecuencia:** se descartan alternativas React/Node/SQL Server del documento anterior; API-first y solución .NET.
- **Aún pendientes:** proveedor MySQL/ORM, esquema de auth, competiciones y datos.

## ADR-017 — Modo de renderizado Blazor (APROBADO POR EL EQUIPO)
Blazor Web App + Interactive Server, manteniendo peticiones HTTP a API separada. La aplicación base fue generada con este modo.

## ADR-018 — Estrategia de acceso a datos (PENDIENTE)
EF Core y migraciones si existe proveedor compatible con la versión del SDK de la materia; alternativa de repositorios ADO.NET con scripts versionados si lo exigen.

## ADR-019 — Monorepo simplificado (APROBADO POR EL EQUIPO)
- **Decisión:** mantener un único repositorio con una solución clásica `Reporteros.sln` que contiene solo `Reporteros.Api` y `Reporteros.Web`; `mobile/`, documentación y recursos conviven fuera de la solución.
- **Contexto:** el equipo conoce una organización API por carpetas (`Controllers`, `Services`, `DTOs`, `Models`) y prioriza una curva de aprendizaje gradual.
- **Consecuencia:** no se crean proyectos separados Domain/Application/Infrastructure/Contracts. Los límites se aplican mediante estructura, revisión de PR y reglas documentadas. Si el proyecto crece, las carpetas pueden extraerse a proyectos sin cambiar el contrato HTTP.

## ADR-021 — Secuenciación API-first (DB + API antes que Web)
- **Decisión:** asentar primero la base de datos y la API con datos de prueba en abundancia; la Web (Blazor) se aborda recién cuando la API esté validada con un cliente HTTP independiente (curl/Postman) y tests de integración verdes (TC-API-01..07).
- **Contexto:** evitar pantallas Blazor con datos hardcodeados y consumo de endpoints no estabilizados; validar el contrato HTTP sin depender del frontend.
- **Consecuencias:** gate explícito "API estable" antes de W1; seed de datos abundante y representativo como requisito previo; la Web reutiliza el mismo cliente HTTP y no duplica reglas.
- **Revisión:** si la docencia exige demo temprana de UI, se puede usar un cliente HTTP independiente como evidencia sin adelantar Blazor.
