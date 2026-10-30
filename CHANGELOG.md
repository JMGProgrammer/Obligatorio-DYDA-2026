# CHANGELOG — Registro de cambios del proyecto

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado:** base del monorepo inicializada. **Confirmado:** ASP.NET Core Web API y Blazor Web App sobre .NET 10; MySQL; cliente móvil Expo + React Native; fútbol, básquetbol y esports. **Pendiente:** estrategia de acceso a datos, autenticación, competiciones exactas, calendario y fuentes.

## Convenciones
- Formato inspirado en Keep a Changelog; versionado por hitos **H0–H5** de [ROADMAP](docs/06-gestion/ROADMAP.md) en lugar de versiones de software: no hay liberaciones todavía.
- Una entrada por gate de hito cerrado o cambio significativo; nunca un registro por commit ni por archivo. La historia fina vive en Git.
- Categorías: **Añadido**, **Cambiado**, **Corregido**, **Eliminado**. La fecha de la entrada es la del cierre real (commit o gate), nunca estimada.

## [No liberado]
Pendientes de decisión docente/equipo: ADR-010 (competiciones demo), ADR-015 (responsables) y ADR-018 (estrategia de acceso a datos).

### Añadido
- Monorepo con solución clásica `Reporteros.sln`, API ASP.NET Core y Blazor Web App en modo Interactive Server.
- SDK .NET 10 fijado mediante `global.json`, reglas compartidas en `.editorconfig` y CI para formato y compilación Release.
- Endpoint operativo `GET /health` y cliente HTTP tipado de Blazor configurado mediante `Api:BaseUrl`.
- Reserva `mobile/` para Expo + React Native, a implementar en la última etapa.

### Cambiado
- Arquitectura simplificada a dos proyectos .NET, registrada en ADR-019; los límites internos de API se organizan por carpetas.
- Tecnología móvil cerrada como Expo + React Native mediante ADR-020.
- Documentación técnica y README alineados con la estructura real del repositorio.

### Eliminado
- Código demostrativo Weather/Counter generado por las plantillas .NET.
- Script de scaffolding de un solo uso, reemplazado por la base versionada y reproducible del repositorio.

## H0 — Documentación inicial · 2026-10-30
### Añadido
- Estructura documental `docs/` con siete áreas y 27 documentos indexados en README.
- Producto: visión y propuesta de valor, alcance con MVP propuesto (M01–M10), interesados, escenarios e historias de usuario con criterios de aceptación.
- Requisitos: RF-01–RF-24 y RNF-01–RNF-11 con prioridades, reglas de coherencia y trazabilidad a HU/TC.
- Técnica: arquitectura, modelo relacional lógico preliminar, contratos HTTP propuestos, fuentes de datos y análisis de seguridad.
- Calidad: plan de pruebas (funcionales, seguridad y aceptación) y requisitos no funcionales con Definition of Done.
- Gestión: roadmap por hitos H0–H5, flujo de trabajo del equipo, registro de riesgos y decisiones ADR-001–ADR-015.
- Identidad: manual operativo de marca, documento maestro consolidado y insignia del proyecto (`assets/Reporteros-banner.png`).
- Licencia del repositorio y README con índice de la documentación.

### Cambiado
- Se consolida la documentación previa del equipo en la estructura por áreas; identidad y producto permanecen en [MASTER-BRANDING-Y-PRODUCTO](docs/07-identidad/MASTER-BRANDING-Y-PRODUCTO.md).

### Notas
- Las decisiones vigentes y pendientes se mantienen en [DECISIONS](docs/06-gestion/DECISIONS.md).
