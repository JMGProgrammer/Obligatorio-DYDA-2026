# ITERATION-PLAN — Plan de iteraciones

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Principios del plan
- Descompone los hitos **H0–H5** de [ROADMAP](docs/06-gestion/ROADMAP.md) en iteraciones con salida demostrable. Define orden y gates, no fechas: la duración se ajusta al calendario del obligatorio y los responsables quedan pendientes de ADR-015.
- Cada iteración termina con algo ejecutable y verificable. Si su gate no pasa, la iteración siguiente prioriza cerrarlo antes de abrir alcance nuevo.
- Cadencia semanal según [TEAM-WORKFLOW](docs/06-gestion/TEAM-WORKFLOW.md): tres resultados concretos por semana, check-in breve, demo interna y revisión de riesgos.
- Todo contenido marcado **MVP** / **Should** aquí sigue siendo propuesta hasta aprobación docente (ver [SCOPE](docs/01-producto/SCOPE.md)).

## 2. Vista general
| IT | Hito | Objetivo demostrable | Gate de salida |
|---|---|---|---|
| I0 | H0 | Propuesta validada | Docencia acepta el recorte |
| I1 | H1 | Fundación técnica | App arranca en dos PCs con seed |
| I2 | H2 | Vertical de resultados (fútbol, una competición) | TC críticos de publicación pasan |
| I3 | H2 | Corrección, auditoría y seguridad del flujo | Corrección con motivo auditable; RNF-01/02/17 verificados |
| I4 | H3 | Tres disciplinas operando | Demos coherentes de fútbol, básquetbol y esports |
| I5 | H4 | Portada editorial integrada | Flujo de noticia completo; responsive |
| I6 | H5 | Calidad integral | Sin severidades S1/S2; seguridad y accesibilidad comprobadas |
| I7 | H5 | Entrega | Demo reproducible desde cero y documentación final |

## 3. Detalle por iteración

### I0 — Cierre de descubrimiento · H0
- **Contenido:** validar OVERVIEW/SCOPE con la docencia; resolver ADR-009 (stack), ADR-010 (competiciones de muestra), ADR-015 (responsables); definir qué contenido es real con licencia y qué es ficticio identificado.
- **Entregables:** presentación docente; [DECISIONS](docs/06-gestion/DECISIONS.md) actualizado; requisitos ratificados.
- **Gate:** recorte aceptado. Sin este gate no se inicia I1.

### I1 — Fundación técnica · H1
- **Contenido:** estructura de código según el stack elegido; `database/` con migraciones y seed demo; autenticación con roles base y hashing moderno (RNF-09); CI mínima; shell navegable de portada, calendario, ficha y admin.
- **Cubre:** RF-10, RF-11 (base), RNF-09, RNF-10 (línea base).
- **Gate:** aplicación arranca en dos PCs y el seed reproduce el contenido demo.

### I2 — Vertical de resultados · H2
- **Contenido:** el flujo crítico con una competición de fútbol: crear competición y temporada → registrar equipos → programar encuentro → cargar borrador → aprobar resultado → consulta pública → clasificación bajo regla de temporada.
- **Cubre:** M02–M05 y M08 parcial; RF-01 a RF-07 y RF-12 a RF-17 (recortado a fútbol); TC-06/07/08/10.
- **Gate:** casos de prueba críticos de publicación pasan y los borradores no son públicos (RNF-06).

### I3 — Corrección, auditoría y seguridad · H2
- **Contenido:** corrección de resultado con motivo, usuario e instante (RF-15); validaciones duplicadas en servidor (RNF-02); fechas como instante y presentación America/Montevideo (RNF-07); respaldo inicial documentado (RNF-08); definición del modelo editorial de roles (ADR-012).
- **Cubre:** M09 completo; RNF-01 (endpoints protegidos).
- **Gate:** la auditoría conserva antes/después y la corrección queda trazada.

### I4 — Cobertura de tres disciplinas · H3
- **Contenido:** básquetbol y esports BOx; reglas de clasificación por competición/formato (ADR-011); representación de fase/serie (ADR-014 si aplica); filtros por disciplina y ficha de serie identificada por videojuego y formato.
- **Cubre:** M06; RF-02/RF-03/RF-08 por disciplina; HU-05 y TC-11.
- **Gate:** demos coherentes de los tres deportes, con equipos ficticios identificados.

### I5 — Editorial e integración · H4
- **Contenido:** noticias con ciclo borrador → revisión → publicación (RF-09, RF-18); registro de fuentes; home completa con bloques por deporte y resultados recientes; búsqueda global solo si P1 (RF-19); responsive desde 360px (RNF-03) y accesibilidad esencial (RNF-04/05).
- **Cubre:** M01 completo, M07 y M10.
- **Gate:** flujo de noticia completo y navegación responsive validada.

### I6 — Calidad y preparación de entrega · H5
- **Contenido:** pruebas integrales según [TEST-PLAN](docs/05-calidad/TEST-PLAN.md); seguridad (acceso directo a endpoints, secreto en errores); datos demo auditables; resolución de hosting si ADR-013 lo decide; corrección de S1/S2.
- **Gate:** sin severidades bloqueantes; recorrido de auditoría completo.

### I7 — Entrega · H5
- **Contenido:** corrección final de bugs; documentación final actualizada (README, DECISIONS, CHANGELOG); ensayo de la demo sugerida en [ROADMAP](docs/06-gestion/ROADMAP.md) (visitante → editor → revisor → tabla → corrección auditada → serie esports → noticia); limpieza de repositorio sin secretos.
- **Gate:** demo ejecutada de principio a fin y entregables por materia consolidados (TEAM-WORKFLOW §6).

## 4. Alcance condicional (Should, con margen)
Se incorpora solo si todos los gates de la iteración previa están en verde y nunca sacrificando seguridad, validación o trazabilidad: búsqueda global (RF-19), previsualización de noticias (RF-22), estadísticas derivadas del resultado, filtros ampliados (RF-21) e importación CSV validada.

## 5. Recorte ante calendario acorto
Aplicar el criterio de SCOPE §6: mantener un solo formato clasificatorio completamente implementado; estadísticas solo derivadas del resultado; tres disciplinas mediante ejemplos coherentes; posponer histórico extenso y automatización. En el plan: I3 se reduce a lo esencial de auditoría, I5 pospone búsqueda y previsualización, y el bloque condicional (§4) se descarta. **Nunca recortar control de acceso, validación ni trazabilidad de resultados.**

## 6. Gobernanza y trazabilidad
- Revisión en el check-in semanal; desvíos se registran en [RISKS](docs/06-gestion/RISKS.md) y las decisiones que alteren alcance se afirman en DECISIONS antes de modificar requisitos o este plan.
- Los IDs de iteración (I0–I7) son estables; su duración y asignación de responsables se completan al confirmarse el calendario académico y ADR-015.
- Cada gate superado genera una entrada en [CHANGELOG](CHANGELOG.md).
