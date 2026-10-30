# DECISIONS — Registro de decisiones (ADR)

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## Decisiones acordadas
| ID | Tema | Estado | Resolución | Justificación |
|---|---|---|---|---|
| ADR-001 | Nombre | **Aprobado** | REPORTEROS | Reporteros + teros, identidad nacional |
| ADR-002 | Producto | **Aprobado** | Centro de información deportiva de Uruguay | Enfoque editorial e informativo |
| ADR-003 | Disciplinas | **Aprobado** | Fútbol, básquetbol, esports | Foco expresado por el equipo |
| ADR-004 | Esports | **Aprobado como enfoque** | Contemplar AUDV como referencia de ecosistema | No afirma asociación ni acceso a datos |
| ADR-005 | Identidad visual | **Propuesta** | Sports Editorial/Dark Tech, celeste/azul noche | Requiere aprobación final visual |
| ADR-006 | Eslogan | **Propuesta** | «El deporte uruguayo tiene quien lo cuente.» | Mensaje institucional; no aprobación explícita |
| ADR-007 | MVP | **Propuesta** | Portal + administración/editorial + resultados aprobados | Evita excesos de alcance |
| ADR-008 | Datos en vivo | **Fuera de MVP propuesto** | Sin garantía de tiempo real | Dependencia de fuentes |

## Decisiones abiertas
| ID | Pregunta | Alternativas | Criterio para resolver |
|---|---|---|---|
| ADR-009 | Stack | React+C#/SQL; Razor+C#/SQL; React+Node/PG | Rúbrica, experiencia, tiempo |
| ADR-010 | Competiciones específicas | Reales con licencia / sintéticas | Disponibilidad y verificación |
| ADR-011 | Modelo de clasificación | Reglas por competición/formato | Confirmación de reglas |
| ADR-012 | Autorización editorial | Editor publica / revisor separado | Carga de equipo y seguridad |
| ADR-013 | Hosting | Local / demo / público | Recursos y exigencia docente |
| ADR-014 | Representación de brackets | Entidad fase/enfrentamiento dedicada | Formatos elegidos |
| ADR-015 | Responsables | Asignación por integrantes | Acuerdo del equipo |

## Plantilla ADR
**Contexto:** problema y restricciones. **Opciones:** alternativas con ventajas y costos. **Decisión:** una sola, fecha, personas. **Consecuencias:** migraciones, código, pruebas, documentación. **Revisión:** condiciones para reconsiderar.
