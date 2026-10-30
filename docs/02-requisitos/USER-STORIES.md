# USER-STORIES — Historias y aceptación

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## Formato
Cada historia contiene actor, beneficio, criterios en estilo Dado/Cuando/Entonces y dependencia. Los IDs permanecen estables.

### HU-01 — Consultar portada (P0)
Como visitante quiero ver actividad y noticias destacadas para enterarme rápidamente.
- **Dado** que hay encuentros publicados, **cuando** abro Inicio, **entonces** veo próximos y últimos resultados diferenciados.
- **Dado** que no hay contenido, **entonces** veo un estado vacío útil, sin marcadores inventados.

### HU-02 — Filtrar calendario (P0)
Como visitante quiero filtrar por disciplina, competición y fecha.
- **Cuando** aplico filtros, **entonces** solo se muestran encuentros que cumplen todos los criterios.
- **Cuando** limpio filtros, **entonces** recupero la vista predeterminada.

### HU-03 — Consultar partido (P0)
Como visitante quiero ver resultado y contexto.
- Mostrar contendientes, torneo, temporada, hora de Uruguay, estado, marcador si corresponde y fuente disponible.
- Nunca etiquetar EN VIVO por inferencia temporal.

### HU-04 — Ver posiciones (P0)
Como aficionado quiero consultar la tabla según el reglamento.
- **Dado** un conjunto de resultados aprobados, **cuando** se publica un resultado, **entonces** la tabla se recalcula de forma determinística.
- Resultados anulados o borradores no suman.

### HU-05 — Seguir esports (P0)
Como seguidor quiero ver juego, torneo y serie.
- Una serie BO3 puede terminar 2-0 o 2-1; no 3-1.
- Si el formato es eliminación directa, se muestra cuadro o enfrentamientos, no una tabla de liga inventada.

### HU-06 — Leer noticias (P0)
Como visitante quiero acceder a noticias publicadas.
- Solo publicaciones vigentes son visibles.
- Mostrar autor/editor, fecha y actualización, sin revelar borradores.

### HU-07 — Acceder al panel (P0)
Como editor quiero autenticarme para gestionar contenido.
- Un visitante no accede al panel protegido.
- Un editor sin privilegio de usuarios no puede asignar roles.

### HU-08 — Crear encuentro (P0)
Como editor quiero programar encuentros.
- Solo se pueden seleccionar equipos participantes compatibles con la competición/temporada definida.
- Fecha, estado y formato quedan registrados; entradas inválidas muestran error claro.

### HU-09 — Publicar/corregir resultado (P0)
Como revisor autorizado quiero aprobar y corregir información con trazabilidad.
- Una corrección de resultado publicado exige motivo y registra valor anterior y nuevo.
- Una persona no autorizada recibe 403 incluso llamando directamente al API.

### HU-10 — Gestionar noticia (P0)
Como editor quiero redactar y enviar una noticia a revisión.
- Un borrador no aparece públicamente.
- Publicar exige título, cuerpo y autor; la vista previa no publica.

### HU-11 — Buscar contenidos (P1)
Como lector quiero hallar un equipo, torneo o noticia.
- Búsqueda tolera diferencias básicas de mayúsculas y espacios y permite volver al contexto.

### HU-12 — Revisar calidad de datos (P1)
Como admin quiero detectar registros sin fuente y cambios relevantes.
- Puedo filtrar registros pendientes de revisión e inspeccionar auditoría sin modificarla.

## Escenarios extremos
Mismo equipo en local y visitante; marcador negativo; sesión vencida antes de publicar; dos editores cambiando el mismo resultado; partido suspendido; competición sin tabla; noticia con imagen sin autorización; serie esports sin detalle de mapas. Registrar qué comportamiento se espera antes de programar.
