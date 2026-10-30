# ROADMAP — Plan de implementación

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

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
