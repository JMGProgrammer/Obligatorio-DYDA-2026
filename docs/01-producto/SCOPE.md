# SCOPE — Alcance, MVP y prioridades

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## 1. Criterio de selección
El MVP debe demostrar valor como **centro de información**, no convertirse en una plataforma de organización federativa. Priorizar los recorridos completos sobre listas largas de pantallas vacías.

## 2. MVP propuesto (Must)
| ID | Capacidad | Entrega mínima verificable |
|---|---|---|
| M01 | Home | Próximos partidos, resultados recientes, noticias y entradas por deporte |
| M02 | Catálogos | Disciplinas, competiciones, temporadas y equipos consultables |
| M03 | Calendario | Filtros por deporte, competición y fecha |
| M04 | Partido | Contendientes, fecha/hora Uruguay, estado, marcador y fuente |
| M05 | Posiciones | Tabla calculada sobre resultados publicados cuando aplique |
| M06 | Esports | Juego, competición, serie BOx y resultado agregado; mapas opcionales |
| M07 | Noticias | Listado, detalle, categorías y publicación editorial |
| M08 | Administración | Login, roles, ABM de catálogos y carga/publicación de datos |
| M09 | Control | Corrección auditada, validaciones, estados y fuente |
| M10 | UX | Responsive, accesibilidad esencial, carga y estados vacíos |

## 3. Should (si hay margen)
Búsqueda global con filtros; perfiles ampliados de jugadores; estadísticas individuales; panel de calidad de datos; imágenes y escudos con licencia; SEO avanzado; importación CSV validada.

## 4. Could (futuro)
Actualización automática desde proveedores; marcadores realmente en vivo; favoritos y notificaciones; comparativas avanzadas; widgets embebibles; comunidad y encuestas; app móvil; integraciones institucionales.

## 5. Explícitamente fuera del MVP
Gestión de inscripciones/transferencias de equipos; designación de árbitros; sanciones automáticas; apuestas y probabilidades; streaming de partidos; scraping no autorizado; pagos; chat; predicciones por IA; creación pública de torneos; verificación automática de resultados oficiales.

## 6. Estrategia de recorte
Si los tiempos se reducen: mantener un solo formato clasificatorio completamente implementado, restringir estadísticas a las derivadas del resultado, cargar manualmente y conservar las tres categorías mediante ejemplos coherentes; posponer histórico extenso y automatización. Nunca recortar control de acceso, validación o trazabilidad de resultados.

## 7. Límites y dependencias
El dato inicial puede ser ficticio para demostración si se identifica como tal. La cobertura real depende de disponibilidad y permisos. El alcance definitivo requiere aprobación docente y confirmación del calendario académico.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Límites tecnológicos del MVP
**Incluye:** API ASP.NET Core, DB MySQL, UI Blazor, clientes HTTP, pruebas de integración y documentación OpenAPI. **Excluye:** React como frontend principal, Node como backend, SQL Server como fuente, acceso directo del móvil a MySQL, app móvil obligatoria, resultados realmente en vivo sin proveedor. La compatibilidad móvil se verifica con cliente HTTP independiente.
