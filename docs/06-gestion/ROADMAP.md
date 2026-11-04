# ROADMAP — Plan de implementación

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

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
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Estrategia de implementación: API-first (DB + API antes que Web)
La prioridad del equipo es **asentar primero la base de datos y la API**, con datos de prueba en abundancia, y solo cuando la API esté validada con un cliente independiente (curl/Postman) se aborda la Web. Esto evita duplicar lógica y permite probar el contrato HTTP sin depender de Blazor.

Reglas derivadas:
- No se implementan pantallas Blazor con datos hardcodeados ni se consumen endpoints no estabilizados.
- Cada vertical nuevo se cierra primero en la API (endpoint + servicio + persistencia + tests) y después se conecta a la Web.
- La semilla de datos debe ser abundante y representativa (las 3 disciplinas, resultados en borrador/aprobado/corregido, un partido suspendido, serie BO3, standings con empate, noticia borrador) antes de considerar estable la API.
- El gate de paso a la Web es: API corriendo, migraciones aplicadas, seed reproducible, tests de integración verdes y validación con cliente HTTP independiente (TC-API-01..07).

## Secuencia vertical obligatoria (API-first)
| Fase | Entregable verificable | Dependencias |
|---|---|---|
| A0 | Versión .NET/proveedor MySQL confirmados; solución creada | Docentes y entorno |
| A1 | MySQL + migración inicial + seed mínimo (`GET /sports`) | A0 |
| A2 | API de competiciones/partidos con JSON/OpenAPI y pruebas de integración | A1 |
| A3 | Seed de datos de prueba abundante y representativo (3 disciplinas) | A2 |
| A4 | Validación de la API con cliente HTTP independiente (curl/Postman) + TC-API | A3 |
| **GATE API** | **API estable y testeada; recién aquí se inicia la Web** | A4 |
| W1 | Blazor lista/filtra partidos mediante `HttpClient` | Gate API |
| W2 | Auth y administración de resultados con auditoría en Blazor | W1 |
| W3 | Noticias y fichas con DTO; clasificaciones validadas | W2 |
| W4 | Evidencia cliente HTTP independiente como futuro móvil | W3 |
| W5 | Tests, documentación, demo, backup y presentación | W4 |

No intentar comenzar por todas las pantallas con datos hardcodeados: entregar primero un flujo entero MySQL → API → Blazor, luego ampliar. Los hitos no tienen fechas inventadas.
