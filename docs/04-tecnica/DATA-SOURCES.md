# DATA-SOURCES | Procedencia y publicación de datos

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Fuentes disponibles
El proyecto **no tiene confirmada una API oficial ni acuerdo con AUDV**, federaciones o ligas. El MVP se alimenta de carga editorial manual o datos ficticios etiquetados, gestionados exclusivamente por endpoints de administración de ASP.NET Core.

## Procedencia obligatoria
Cada partido/noticia publicado indica fuente, responsable o método de carga, fecha de actualización y nivel de verificación (comprobado/no comprobado). No llamar «en vivo» a refrescos manuales intermitentes; marcar `En vivo` solo cuando hay una fuente y frecuencia real y verificable.

## Pipeline de datos
`Fuente externa/manual → Editor → Blazor admin → API → Validación y permisos → MySQL → Publicación → API pública → Blazor/móvil`.

## Roles editoriales
Editor guarda borradores, revisor aprueba, admin consulta registro. Ante discrepancia, suspender publicación o indicar revisión y dejar trazabilidad. La fuente externa **no** modifica directamente MySQL.

## Integraciones futuras
Crear adaptadores en `Infrastructure` que llamen APIs autorizadas y transformen a DTO internos; guardar identificador externo, marca temporal y registro de sincronización; revisión antes de actualizar registros oficiales. Respetar licencias, frecuencia y políticas de uso.

## Datos de demo
Crear competiciones, equipos, resultados y artículos sintéticos con rótulo «Datos de demostración» para evaluación sin inducir al público a creer que son oficiales.
