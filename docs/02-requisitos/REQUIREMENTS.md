# REQUIREMENTS — Especificación funcional y no funcional

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## 1. Convenciones
**RF** requisito funcional; **RNF** no funcional. Prioridad **P0** crítica para MVP, **P1** recomendable, **P2** futura. Verificable mediante un caso de prueba documentado. En discrepancias prevalece una decisión revisada en DECISIONS.md.

## 2. Requisitos funcionales
| ID | Prioridad | Requisito verificable |
|---|---|---|
| RF-01 | P0 | El visitante consulta inicio sin autenticar |
| RF-02 | P0 | Filtra encuentros por fútbol, básquetbol y esports |
| RF-03 | P0 | Filtra por competición y rango de fechas |
| RF-04 | P0 | Consulta ficha con estado, participantes, resultado, fuente y última actualización |
| RF-05 | P0 | Consulta competición con temporada y formato |
| RF-06 | P0 | Consulta listado y ficha de equipos |
| RF-07 | P0 | Visualiza clasificación si el reglamento soporta tabla |
| RF-08 | P0 | Consulta cuadro/serie esports identificado por videojuego y formato |
| RF-09 | P0 | Consulta noticias publicadas y su fecha de actualización |
| RF-10 | P0 | Editor inicia sesión y termina sesión |
| RF-11 | P0 | Admin asigna/revoca roles autorizados |
| RF-12 | P0 | Editor gestiona competiciones, temporadas, equipos y encuentros |
| RF-13 | P0 | Editor guarda contenido en borrador sin publicarlo |
| RF-14 | P0 | Revisor autorizado publica/corrige resultado con validaciones |
| RF-15 | P0 | El sistema registra usuario, instante y motivo de corrección de resultado |
| RF-16 | P0 | Los datos públicos excluyen borradores y resultados no aprobados |
| RF-17 | P0 | El sistema bloquea relaciones inconsistentes y marcadores inválidos |
| RF-18 | P0 | Una noticia puede estar en borrador, revisión y publicada |
| RF-19 | P1 | Busca por equipo, competición y noticia |
| RF-20 | P1 | Muestra ficha ampliada de jugador con estadísticas disponibles |
| RF-21 | P1 | Permite filtros por temporada, región, género o categoría si el dato existe |
| RF-22 | P1 | Editor previsualiza noticia y registra procedencia de imagen |
| RF-23 | P2 | Importa datos mediante integración autorizada y registra sincronizaciones |
| RF-24 | P2 | Usuario guarda favoritos y recibe notificaciones |

## 3. Requisitos no funcionales
| ID | Criterio propuesto | Verificación |
|---|---|---|
| RNF-01 | Operaciones protegidas autorizadas también en servidor | Prueba de acceso directo a endpoints |
| RNF-02 | Formularios validan cliente y servidor | Entradas inválidas y límites |
| RNF-03 | Interfaz operable desde 360px y desktop | Inspección responsive |
| RNF-04 | Navegación por teclado y etiquetas accesibles | Recorrido manual / auditoría |
| RNF-05 | Contraste objetivo WCAG AA | Comprobación de pares reales |
| RNF-06 | No se publica información marcada provisional | Prueba de consulta pública |
| RNF-07 | Fechas almacenadas como instante y presentadas en America/Montevideo | Casos con zonas horarias |
| RNF-08 | Se respaldan datos y se documenta recuperación | Ensayo de restauración si despliegue lo permite |
| RNF-09 | Contraseñas almacenadas con hash de algoritmo moderno | Revisión técnica |
| RNF-10 | Errores internos no revelan secretos | Pruebas de errores y logs |
| RNF-11 | El sitio debe ser usable en equipos y conexiones modestos | Auditoría de peso y carga |

## 4. Reglas de coherencia
Las estadísticas y clasificaciones solo derivan de encuentros publicados/finalizados bajo reglas de temporada. Esports no se fuerza al mismo esquema de puntos que fútbol. Los datos incompletos se muestran como no disponibles, no como cero. Estado EN VIVO solo con actualización auténtica.

## 5. Trazabilidad
RF-04/14/15/16 corresponden a historias HU-03/HU-09 y pruebas TC-06/07/08; RF-07 a HU-04 y TC-10; RF-08 a HU-05 y TC-11. Mantener esta tabla actualizada al cambiar alcance.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Requisitos de integración entre materias (nuevos)
| ID | Prioridad | Requisito y verificación |
|---|---|---|
| RF-API-01 | P0 | Todos los datos públicos de Blazor provienen de endpoints ASP.NET Core vía HTTP/JSON; verificar tráfico/cliente tipado |
| RF-API-02 | P0 | Todas las operaciones editoriales pasan por endpoints autenticados y autorizados; probar petición directa sin UI |
| RF-API-03 | P0 | La única capa que opera MySQL es Infrastructure detrás de API; inspeccionar referencias de solución |
| RF-API-04 | P0 | Los DTO no serializan entidades EF ni campos secretos; validar respuestas OpenAPI |
| RF-API-05 | P0 | La API admite un segundo cliente independiente; consultar mismo partido desde Blazor y Postman/curl |
| RF-API-06 | P0 | Cambios de marcador afectan la vista pública por consulta posterior sin código SQL en Blazor |
| RF-API-07 | P1 | OpenAPI documenta rutas, estados, autenticación y errores de contrato |
| RNF-API-01 | P0 | Base MySQL central, protegida contra acceso directo público y con migraciones versionadas |
| RNF-API-02 | P0 | Respuestas HTTP JSON reproducibles con errores `ProblemDetails` |
| RNF-API-03 | P0 | Los cambios de resultado y auditoría son atómicos en base de datos |
| RNF-API-04 | P1 | Infraestructura permite integrar móvil remoto sin reescribir lógica C# |
