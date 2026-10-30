# CHANGELOG — Registro de cambios del proyecto

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## Convenciones
- Formato inspirado en Keep a Changelog; versionado por hitos **H0–H5** de [ROADMAP](docs/06-gestion/ROADMAP.md) en lugar de versiones de software: no hay liberaciones todavía.
- Una entrada por gate de hito cerrado o cambio significativo; nunca un registro por commit ni por archivo. La historia fina vive en Git.
- Categorías: **Añadido**, **Cambiado**, **Corregido**, **Eliminado**. La fecha de la entrada es la del cierre real (commit o gate), nunca estimada.

## [No liberado]
Trabajo en curso según el plan de iteraciones: ver [ITERATION-PLAN](docs/ITERATION-PLAN.md). Pendientes de decisión docente/equipo: ADR-009 (stack), ADR-010 (competiciones demo), ADR-015 (responsables).

- Propuesta de reglas de desarrollo y versionado: [DEVELOPMENT-RULES](docs/DEVELOPMENT-RULES.md) (v0.0.1 por fix, v0.1 por iteración cerrada, estable = MAJOR); pendiente de adopción por el equipo.

## H0 — Documentación inicial · 2026-10-30
### Añadido
- Estructura documental `docs/` con siete áreas y 22 documentos indexados en README.
- Producto: visión y propuesta de valor, alcance con MVP propuesto (M01–M10), interesados, escenarios e historias de usuario con criterios de aceptación.
- Requisitos: RF-01–RF-24 y RNF-01–RNF-11 con prioridades, reglas de coherencia y trazabilidad a HU/TC.
- Técnica: arquitectura, modelo relacional lógico preliminar, contratos HTTP propuestos, fuentes de datos y análisis de seguridad.
- Calidad: plan de pruebas (funcionales, seguridad y aceptación) y requisitos no funcionales con Definition of Done.
- Gestión: roadmap por hitos H0–H5, flujo de trabajo del equipo, registro de riesgos y decisiones ADR-001–ADR-015.
- Identidad: manual operativo de marca, documento maestro consolidado y insignia del proyecto (`assets/Reporteros-banner.png`).
- Licencia del repositorio y README con índice de la documentación.

### Cambiado
- Se consolida la documentación previa del equipo en la estructura por áreas; el material original permanece en [MASTER-BRANDING-Y-PRODUCTO](docs/07-identidad/MASTER-BRANDING-Y-PRODUCTO.md) y en el documento raíz `docs/REPORTEROS_IDENTIDAD_Y_PROYECTO.md`.

### Notas
- Único contenido confirmado en esta etapa: ADR-001 a ADR-004 (nombre, producto, disciplinas y enfoque esports); el resto queda como propuesta hasta validación docente (ver [DECISIONS](docs/06-gestion/DECISIONS.md)).
- Este archivo y el plan de iteraciones se incorporan al cerrar la fase de documentación de H0.
