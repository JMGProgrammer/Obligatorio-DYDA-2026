# TEST-PLAN — Plan de verificación

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## 1. Estrategia
Pirámide: unitarias para reglas y clasificación; integración para persistencia/autorización/API; E2E para navegación y flujo editorial; pruebas manuales de responsive y accesibilidad. Evidencia: ID, versión, datos, pasos, esperado, obtenido, captura/log y responsable.

## 2. Casos prioritarios
| ID | Escenario | Esperado |
|---|---|---|
| TC-01 | Visitante abre home | Datos públicos sin sesión |
| TC-02 | Filtro por deporte/fecha | Resultados pertinentes |
| TC-03 | Partido sin fuente | Aviso de disponibilidad/verificación según política |
| TC-04 | Resultado en borrador | No visible como final público |
| TC-05 | Editor intenta gestionar usuarios | 403 |
| TC-06 | Usuario anónimo publica resultado | 401/403 |
| TC-07 | Revisor aprueba resultado válido | Se publica y registra auditoría |
| TC-08 | Corrección sin motivo | Rechazada sin afectar marcador |
| TC-09 | Dos revisores envían versiones distintas | Segundo obtiene 409 y no sobreescribe |
| TC-10 | Tabla de fútbol con 3-1-0 y varios partidos | Clasificación calculada conforme reglamento de demo |
| TC-11 | BO3 esports 3-1 | Rechazado por formato |
| TC-12 | Básquetbol empate final no permitido | Validación correspondiente |
| TC-13 | Búsqueda sin coincidencias | Estado vacío accesible |
| TC-14 | Artículo no publicado | Invisible para visitante |
| TC-15 | XSS en cuerpo de noticia | Script no ejecutado |
| TC-16 | Hora UTC presentada al usuario | Hora correcta Uruguay |
| TC-17 | Móvil 360px | Sin controles fuera de pantalla ni pérdida de acciones |
| TC-18 | Navegación con teclado | Foco visible, controles operables |

## 3. Datos de prueba
Semillas sintéticas identificadas, incluyendo competiciones y partidos por tres deportes; un partido suspendido; un resultado provisional; una noticia borrador; marcador corregido; serie BO3 y conjunto de standings con empate por puntos.

## 4. Defectos
Severidad S1: acceso indebido, datos públicos falsos por bug, pérdida/corrupción. S2: flujo principal roto. S3: visual o funcional secundario. Para cerrar S1/S2 debe existir prueba de regresión.

## 5. Criterio de salida propuesto
Todos los P0 implementados o excepciones aprobadas por docentes; 100% de pruebas críticas ejecutadas y aprobadas; ningún S1/S2 abierto; demostración de publicación/corrección sin datos reales mal atribuidos; documentación y seed reproducibles.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Pirámide de pruebas adaptada al stack
1. **Domain.Tests:** clasificaciones fútbol/básquetbol/esports, estados y transiciones, entradas inválidas.
2. **Application.Tests:** autorización por caso de uso, fuentes, auditoría y validación mediante dobles de repositorio.
3. **Api.IntegrationTests:** ASP.NET Core test host + MySQL de prueba real/efímera, DTO, HTTP 200/400/401/403/404/409 y transacciones.
4. **Web.Tests/manual:** componente Blazor con respuesta API simulada; navegación y formularios.
5. **Cliente independiente:** curl/Postman reproduce consulta y comprueba igualdad con Blazor; evidencia de preparación móvil.

### Casos obligatorios adicionales
| ID | Prueba | Esperado |
|---|---|---|
| TC-API-01 | Blazor lista partidos con API online | Renderiza JSON sin consulta MySQL directa |
| TC-API-02 | API detenida | Mensaje recuperable; no fallback a DB |
| TC-API-03 | Editor sin permiso llama PUT directo | 403 |
| TC-API-04 | Móvil simulado llama GET | 200 con mismo DTO |
| TC-API-05 | Corrección versión antigua | 409 sin pérdida de datos |
| TC-API-06 | Fallo al guardar auditoría | Se revierte la transacción de resultado |
| TC-API-07 | API entrega error validación | ProblemDetails consistente |
