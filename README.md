<p align="center">
  <img src="assets/Reporteros-banner.png" alt="REPORTEROS — Centro de información deportiva uruguaya" width="100%">
</p>


> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## Resumen
**REPORTEROS** une la idea de *reporteros* con el *tero*, ave nacional del Uruguay. Su objetivo es brindar un lugar común para consultar competiciones, calendario, resultados, clasificaciones, equipos, participantes y noticias del fútbol, básquetbol y esports uruguayos. En esports se contempla la cobertura de competiciones relacionadas con el ecosistema AUDV, sin atribuir vínculos oficiales.

**Eslogan propuesto:** «El deporte uruguayo tiene quien lo cuente.» **Identidad propuesta:** Sports Editorial / Dark Tech; azul noche, celeste y blanco.

## Alcance inicial
- Portal público, búsqueda y filtros; noticias; calendario y detalles de encuentros.
- Competencias, equipos y participantes con información curada.
- Marcadores finales y clasificaciones verificadas cuando el formato lo admita.
- Panel privado de carga, revisión, publicación y corrección de datos.
- No prometer marcadores automáticos en vivo ni información oficial sin convenio o fuente acreditada.

## Índice de la documentación
| Área | Documento | Propósito |
|---|---|---|
| Producto | [OVERVIEW](docs/01-producto/OVERVIEW.md) | Visión, problema, usuarios y propuesta de valor |
| Producto | [SCOPE](docs/01-producto/SCOPE.md) | MVP, exclusiones y fases |
| Producto | [STAKEHOLDERS](docs/01-producto/STAKEHOLDERS.md) | Interesados, escenarios y validaciones |
| Requisitos | [REQUIREMENTS](docs/02-requisitos/REQUIREMENTS.md) | Requisitos identificables y medibles |
| Requisitos | [USER-STORIES](docs/02-requisitos/USER-STORIES.md) | Historias y criterios de aceptación |
| Requisitos | [BUSINESS-RULES](docs/02-requisitos/BUSINESS-RULES.md) | Reglas deportivas, editoriales y permisos |
| Diseño | [DESIGN](docs/03-diseno/DESIGN.md) | UI, identidad aplicada y accesibilidad |
| Diseño | [INFORMATION-ARCHITECTURE](docs/03-diseno/INFORMATION-ARCHITECTURE.md) | Navegación, pantallas y flujos |
| Técnica | [TECH-STACK](docs/04-tecnica/TECH-STACK.md) | Alternativas y decisiones pendientes |
| Técnica | [ARCHITECTURE](docs/04-tecnica/ARCHITECTURE.md) | Componentes, capas, seguridad y datos |
| Técnica | [DATABASE](docs/04-tecnica/DATABASE.md) | Modelo lógico relacional preliminar |
| Técnica | [API](docs/04-tecnica/API.md) | Contratos HTTP propuestos |
| Técnica | [DATA-SOURCES](docs/04-tecnica/DATA-SOURCES.md) | Procedencia, calidad y trazabilidad |
| Técnica | [SECURITY](docs/04-tecnica/SECURITY.md) | Autenticación, autorización y amenazas |
| Calidad | [TEST-PLAN](docs/05-calidad/TEST-PLAN.md) | Pruebas funcionales, seguridad y aceptación |
| Calidad | [QUALITY](docs/05-calidad/QUALITY.md) | Requisitos no funcionales y Definition of Done |
| Gestión | [ROADMAP](docs/06-gestion/ROADMAP.md) | Hitos, dependencias y entregables |
| Gestión | [TEAM-WORKFLOW](docs/06-gestion/TEAM-WORKFLOW.md) | Git, responsables, reuniones y decisiones |
| Gestión | [RISKS](docs/06-gestion/RISKS.md) | Riesgos y mitigaciones |
| Gestión | [DECISIONS](docs/06-gestion/DECISIONS.md) | Registro de decisiones y pendientes |
| Gestión | [ITERATION-PLAN](docs/ITERATION-PLAN.md) | Plan de iteraciones I0–I7 con gates |
| Gestión | [CHANGELOG](CHANGELOG.md) | Registro de cambios significativos por hito |
| Gestión | [DEVELOPMENT-RULES](docs/DEVELOPMENT-RULES.md) | Versionado por hito/iteración/fix y reglas de desarrollo |
| Identidad | [BRANDING](docs/07-identidad/BRANDING.md) | Manual operativo de marca |
| Identidad | [Master](docs/07-identidad/MASTER-BRANDING-Y-PRODUCTO.md) | Documento original consolidado |

## Inicio recomendado
1. Acordar con la docencia el MVP y las competiciones de muestra.
2. Formalizar reglas para resultados, fuentes y clasificación por disciplina.
3. Aprobar stack y esquema de datos.
4. Construir un flujo vertical: crear competición → registrar equipo → programar encuentro → cargar y aprobar resultado → visualizarlo públicamente.
5. Incorporar noticias, búsqueda, estadísticas y cobertura de otras disciplinas.

## Convenciones
Las funciones marcadas **MVP** son objetivos propuestos, no compromisos aprobados; **Fase 2** y **Futuro** no son requisitos de entrega. Todos los partidos/equipos de las demostraciones deben estar identificados como ficticios si no existe fuente verificable. Prohibido presentar a REPORTEROS como socio de AUF, FUBB o AUDV sin evidencia.
