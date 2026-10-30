# DECISIONS — Registro de decisiones (ADR)

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

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
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## ADR-016 — Stack académico fijado (APROBADO POR EL EQUIPO)
- **Decisión:** API ASP.NET Core/C#, MySQL, web Blazor Web App, móvil futuro consumidor de API.
- **Contexto:** integración entre materias; lógica única compartida; contenidos enseñados en curso.
- **Consecuencia:** se descartan alternativas React/Node/SQL Server del documento anterior; API-first y solución .NET.
- **Aún pendientes:** versión .NET, proveedor MySQL/ORM, modo de hosting Blazor, esquema de auth, competiciones y datos.

## ADR-017 — Modo de renderizado Blazor (PENDIENTE)
Blazor Web App + Interactive Server, manteniendo peticiones HTTP a API separada; aprobar con docencia.

## ADR-018 — Estrategia de acceso a datos (PENDIENTE)
EF Core y migraciones si existe proveedor compatible con la versión del SDK de la materia; alternativa de repositorios ADO.NET con scripts versionados si lo exigen.
