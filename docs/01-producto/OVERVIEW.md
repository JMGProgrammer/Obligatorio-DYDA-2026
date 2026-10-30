# OVERVIEW — Visión de producto

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## 1. Problema y oportunidad
La información deportiva uruguaya se publica en diversos medios, redes sociales, sitios de federaciones y comunidades. Para seguir fútbol, básquetbol y esports puede ser necesario consultar varias fuentes, con formatos heterogéneos, escasa trazabilidad o diferencias en actualización. Este es el **problema planteado por el equipo**; debe validarse con entrevistas y revisión de fuentes, no presentarse como estudio demostrado.

## 2. Solución
Portal editorial multideportivo donde el público encuentre noticias, fichas de competiciones, participantes, programación, resultados y tablas. Un panel de administración permite carga, revisión, publicación y rectificación controlada. Cada dato deportivo tiene contexto: disciplina, competición, temporada, fuente, estado y fecha de actualización.

## 3. Objetivos SMART propuestos para el obligatorio
- Entregar un recorrido completo de consulta pública por las tres disciplinas.
- Publicar datos de demostración coherentes de al menos una competición de ejemplo por disciplina; los torneos concretos se acordarán con docentes.
- Garantizar que un usuario sin permisos no pueda publicar ni corregir resultados.
- Conservar registro de autor, fecha, fuente y justificación en las correcciones relevantes.
- Probar al menos una tabla de clasificación de fútbol/básquetbol y un cuadro o serie de esports con reglas explícitas.

## 4. Usuarios
| Actor | Necesidad | Resultado esperado |
|---|---|---|
| Visitante/hincha | Enterarse de qué se juega y quién ganó | Buscar y consultar sin crear cuenta |
| Seguidor de esports | Encontrar partidas por juego o torneo | Ver series, mapas y resultados con formatos apropiados |
| Periodista/aficionado | Consultar contexto | Ubicar fuentes y fecha de actualización |
| Editor | Publicar noticias y datos | Borradores, revisión, vista previa y publicación |
| Administrador | Mantener calidad y seguridad | Usuarios, permisos, auditoría y catálogos |

## 5. Diferenciación
Identidad uruguaya mediante el nombre REPORTEROS y el tero; deportes tradicionales y esports en la misma interfaz; lenguaje editorial consistente; estados honestos de verificación. **No se promete exclusividad de cobertura, actualización automática, derechos de imágenes ni acuerdos oficiales.**

## 6. Principios
1. Exactitud antes que velocidad. 2. Fuente antes que afirmación de oficialidad. 3. Núcleo de datos compartido, reglas deportivas especializadas. 4. Mobile-first. 5. Administración simple y auditable. 6. Accesible y rápida en equipos modestos.

## 7. Indicadores para demostración
Porcentaje de casos de prueba críticos aprobados; cantidad de entidades y encuentros de muestra coherentes; tiempo para completar un flujo editorial; errores de clasificación detectados; cobertura de pantallas móviles; ausencia de publicaciones no autorizadas.

## 8. Preguntas por validar
Qué torneos se incluirán; fuentes y derechos de uso; datos disponibles para esports; si incluir jugadores individuales en MVP; hosting, stack y requisitos de la asignatura; nivel de profundidad de estadísticas.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Alcance integrador preciso
El proyecto consta de **dos aplicaciones desplegables**: `Reporteros.Api` y `Reporteros.Web` más la base MySQL; el móvil es cliente posterior, no funcionalidad exigida para el primer entregable. El valor académico principal es demostrar que web y móvil pueden reutilizar **la misma lógica central**. Se prioriza primera entrega de consultas públicas, resultados aprobados, noticias y administración básica; las reglas de deportes se codifican en servicios C# del backend.
