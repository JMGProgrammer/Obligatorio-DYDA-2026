# ROADMAP — Plan de implementación

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Plan por hitos, no por fechas inventadas
Las duraciones se ajustarán a calendario del obligatorio, cargas del equipo y feedback docente. Cada hito tiene salida demostrable y puerta de calidad.

### H0 — Descubrimiento y aprobación
Confirmar competiciones de muestra, stack, requisitos de materias, contenido real/demo, referente. Entregables: OVERVIEW, SCOPE, DECISIONS, requisitos priorizados. **Gate:** docente acepta el recorte.

### H1 — Diseño y fundación
Prototipo de portada, calendario, ficha y admin; MER, migraciones, repositorio, CI básica, autenticación. **Gate:** aplicación arranca en dos PCs con seed.

### H2 — Vertical deportiva completa
Catálogos → fixture → cargar borrador → aprobar resultado → consulta pública → clasificación y auditoría. Empezar con una competición y luego generalizar. **Gate:** TC críticos de publicación pasan.

### H3 — Cobertura de tres disciplinas
Adaptar fútbol, básquetbol y esports; aplicar reglas de formatos; filtros y detalle de serie. **Gate:** demos coherentes de los tres deportes.

### H4 — Editorial e integración
Noticias, fuentes, publicaciones, búsqueda si P1; home completa y responsive. **Gate:** flujo de noticia completo, enlaces funcionales.

### H5 — Calidad y entrega
Pruebas integrales, corrección de bugs, datos demo auditables, documentación final, ensayo de presentación. **Gate:** no S1/S2, demo reproducible.

## Backlog inicial priorizado
P0: esquema mínimo, login/permisos, competición/temporada/equipos, calendario, ficha encuentro, resultado y auditoría, clasificación, esports serie, noticia, home. P1: búsqueda, media, estadísticas detalladas, calidad de datos. P2: proveedores externos, vivo, perfiles y comunidad.

## Dependencias críticas
Clasificaciones requieren resultado confirmado y regla por temporada; detalle público requiere catálogo consistente; noticias requieren edición/revisión; visualización esports requiere videojuego/formato; dominio y hosting público no son necesarios para primera demo local.

## Demostración sugerida
1. Visitante consulta encuentros. 2. Editor entra al panel y propone resultado. 3. Revisor lo aprueba. 4. Público lo ve reflejado en tabla. 5. Revisor corrige con motivo. 6. Auditoría conserva antes/después. 7. Mostrar serie esports y noticia.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Secuencia vertical obligatoria para evitar duplicar lógica
| Hito | Entregable verificable | Dependencias |
|---|---|---|
| H0 | Versión .NET/proveedor MySQL confirmados; solución creada | Docentes y entorno |
| H1 | MySQL + migración inicial + API `GET /sports` | H0 |
| H2 | API de competiciones/partidos con JSON/OpenAPI y pruebas | H1 |
| H3 | Blazor lista/filtra partidos mediante `HttpClient` | H2 |
| H4 | Auth y administración de resultados con auditoría | H3 |
| H5 | Noticias y fichas con DTO; clasificaciones validadas | H4 |
| H6 | Evidencia cliente HTTP independiente como futuro móvil | H5 |
| H7 | Tests, documentación, demo, backup y presentación | H6 |

No intentar comenzar por todas las pantallas con datos hardcodeados: entregar primero un flujo entero MySQL → API → Blazor, luego ampliar. Los hitos no tienen fechas inventadas.
