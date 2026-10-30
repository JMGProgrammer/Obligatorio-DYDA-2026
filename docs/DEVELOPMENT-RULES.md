# DEVELOPMENT-RULES — Reglas de desarrollo y versionado

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo (ADR-009), competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Versionado (regla principal del repositorio)

Formato único para todo el repositorio: **`vMAJOR.MINOR.PATCH`** (ejemplo `v0.2.1`). La versión existe para saber **qué se puede demostrar y qué es reproducible**; por eso solo se mueve con eventos verificables, nunca con trabajo local sin fusionar.

### 1.1 Los tres únicos incrementos

| Incremento | Cuándo se aplica | Efecto sobre los otros números |
|---|---|---|
| **`+0.0.1` (PATCH)** — cada fix | Corrección verificable de un defecto fusionada a `main` desde una rama `fix/TC-XX-descripcion`. Un fix es un bug observable o un caso fallido de [TEST-PLAN](05-calidad/TEST-PLAN.md); también aplica como hotfix sobre una versión estable. | No altera MAJOR ni MINOR |
| **`+0.1` (MINOR)** — cada iteración | Cierre de una iteración **I0–I7** con su gate aprobado según [ITERATION-PLAN](ITERATION-PLAN.md). Numeración correlativa: cada iteración cerrada suma 1 al MINOR. | PATCH vuelve a `.0` |
| **`+1.0` (MAJOR)** — cada estable | Versión declarada **estable**: gate de hito validado por docencia o entrega aprobada. La primera estable es **`v1.0.0`**; cada estable posterior incrementa el MAJOR en 1. | MINOR y PATCH vuelven a `.0` |

### 1.2 Progresión esperada (ejemplo completo)

| Momento | Versión resultante |
|---|---|
| Inicio del desarrollo con código fusionable | `v0.0.0` |
| Primer fix verificable fusionado | `v0.0.1` |
| Gate de I1 aprobado (primera iteración con software) | `v0.1.0` |
| Dos fixes durante la preparación de I2 | `v0.1.1` → `v0.1.2` |
| Gate de I2 aprobado | `v0.2.0` |
| Declaración explícita de estable (p. ej., demo vertical validada) | `v1.0.0` |
| Fixes urgentes sobre ya estable (hotfix) | `v1.0.1` |
| Iteración siguiente cerrada tras declararse estable (I5) | `v1.1.0` |
| Nueva declaración de estable (p. ej., entrega final) | `v2.0.0` |

### 1.3 Reglas de aplicación

- **Punto de partida:** `v0.0.0`. Todo lo `0.x` es *en desarrollo*; no se etiqueta como estable ningún estado de demostración o trabajo en curso.
- **No bump por fusiones normales:** las ramas `feature/` y `docs/` no mueven la versión. Su contenido viaja dentro del MINOR de la iteración que los integra; mantener historias WIP sin versión propia evita inflar el número.
- **Un solo contador:** el código, la base de datos y la documentación publicada comparten una sola versión. No existen versiones separadas por capa.
- **I0 no genera MINOR de software:** es la fase de documentación; su cierre se registra por commits `docs:` y queda en el CHANGELOG H0.
- **Versión observable:** si el stack elegido en ADR-009 lo permite de forma trivial, la app expone `X.Y.Z` en su pie o endpoint de estado; no se exige automatización: la fuente de verdad es la etiqueta Git.
- **Nunca recortar el versionado en un recorte de alcance:** ante falta de tiempo, se retrasan números pero no se salta el registro de un gate ya demostrado.

### 1.4 Registro obligatorio del versionado

- Cada MINOR y MAJOR: **etiqueta Git** `vX.Y.Z` (anotada, con fecha del gate) sobre `main` + actualización de `VERSION` en la raíz (hoy `v0.0.0`) en el mismo commit + entrada en [CHANGELOG](../CHANGELOG.md) titulada con la versión.
- Fixes: se listan agrupados en la entrada de su iteración; un hotfix posterior a una estable abre línea propia citando su versión PATCH.
- Reversión por defecto crítico: se re-etiqueta el PATCH siguiente con el arreglo; no se etiqueta a mano la versión anterior.

## 2. Otras reglas comunes

### 2.1 Ramas
- `main` siempre ejecutable; nada se commitea directamente.
- Nombres según [TEAM-WORKFLOW](06-gestion/TEAM-WORKFLOW.md): `feature/RF-XX-descripcion`, `fix/TC-XX-descripcion`, `docs/tema`; vida corta, rebase o merge con el estado de `main` al día.
- Ramas sin actividad por más de dos check-ins semanales se retoman o se cierran; nunca ocultar trabajo activo en ramas dormidas.

### 2.2 Commits
- Estilo establecido en la historia del repo: `tipo: resumen breve en minúsculas`. Tipos: `feat`, `fix`, `docs`, `test`, `refactor`, `chore`, `init`.
- Cuando aplique, se cita el identificador: `fix: TC-08 bloquear marcador inválido`, `feat: RF-12 ABM de equipos`.
- Nada de secretos, credenciales o `.env` real en un commit (RNF-10); solo `.env.example` comentado.

### 2.3 Revisión y PR
- Todo cambio entra a `main` vía PR con: descripción, trazable a RF/TC/HU, captura si toca UI, pruebas ejecutadas y migraciones declaradas.
- Revisor obligatorio distinto del autor; preferencia por el revisor asignado al módulo (experiencia web, lógica/API, datos/calidad) rotando según ADR-015.
- No se fusiona sin: Definition of Done de [QUALITY](05-calidad/QUALITY.md), migraciones/seed aplicadas en local y sin warnings críticos.

### 2.4 Trazabilidad de identificadores
- Códigos estables: **RF/RNF** (REQUIREMENTS), **TC** (TEST-PLAN), **HU** (USER-STORIES), **ADR-XXX** (DECISIONS), **M01–M10** (SCOPE), **I0–I7/H0–H5** (plan y roadmap).
- Toda función nueva cita su RF; toda corrección su TC; toda decisión de alcance la actualización previa de REQUIREMENTS/SCOPE.

### 2.5 Código y estructura
- Estructura del repositorio según TEAM-WORKFLOW §4: `src/`, `tests/`, `database/` (migraciones + seeds), `docs/`, `assets/` con licencia; sin binarios sin licencia.
- Semántica accesible desde el primer commit de UI: HTML semántico, focus ordenable, contraste AA (RNF-03/04/05 como línea base, no como tarea final).
- Sin reglas de negocio duplicadas en cliente y servidor: coherencia de [REQUIREMENTS](02-requisitos/REQUIREMENTS.md) §4; validaciones duplicadas sí, reglas no.

### 2.6 Datos de demostración
- Todo dato ficticio queda identificado como tal; prohibido atribuir datos a AUF, FUBB, AUDV u otra fuente sin evidencia (convenciones del README y [DATA-SOURCES](04-tecnica/DATA-SOURCES.md)).
- Los borradores y resultados no aprobados nunca son públicos (RF-16/RNF-06); el seed de `database/` debe reproducir esta regla con un caso de prueba.
- Ninguna dependencia o extensión nueva entra a `main` sin registrarla en DECISIONS (dependencias cuentan como decisión, no como ruido).

### 2.7 Documentación viva
- Cambio de alcance: primero REQUIREMENTS/SCOPE, después este documento, ITERATION-PLAN y pruebas; nunca a la inversa.
- Un gate de hito superado genera entrada en CHANGELOG con su versión (§1.4).
- El índice del README se actualiza al crear o mover un documento de `docs/`.
- Archivos de documentación en MAYÚSCULAS con guiones, siguiendo el patrón existente.

### 2.8 Cierre y fuentes de la verdad
- Ante conflicto de pautas, prevalece la última decisión revisada de [DECISIONS](06-gestion/DECISIONS.md), luego DECISIONS de propuestas, luego este documento.
- Reglas innegociables aunque se recorte el calendario (SCOPE §6): control de acceso, validación de resultados y trazabilidad/auditoría.
- Severidades de [TEST-PLAN](05-calidad/TEST-PLAN.md): ningún S1/S2 abierto al cerrar una iteración; para cerrarlos exige prueba de regresión y versión PATCH correspondiente.
