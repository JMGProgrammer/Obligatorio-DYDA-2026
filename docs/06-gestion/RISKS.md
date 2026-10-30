# RISKS — Riesgos y mitigación

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## Matriz de riesgos (estimación de planificación)
Escala probabilidad/impacto: bajo, medio, alto; revisarla en reuniones.

| ID | Riesgo | Prob. | Impacto | Mitigación |
|---|---|---|---|---|
| R01 | Alcance multideportivo excesivo | Alta | Alto | MVP acotado + vertical completa |
| R02 | Falta de fuente fiable de resultados | Alta | Alto | Dataset demo etiquetado; fuente manual validada |
| R03 | Complejidad de formatos distintos | Alta | Alto | Reglas especializadas por deporte; empezar simple |
| R04 | Intento de vivo sin proveedor | Media | Alto | Excluir vivo del MVP |
| R05 | Conflicto de nombre/marca | Media | Medio | Verificación DNPI, dominios y uso no comercial hasta validar |
| R06 | Uso indebido de imágenes/logotipos | Media | Alto | Licencias, placeholders, créditos |
| R07 | Desacople frontend/backend/BD | Alta | Alto | Contratos tempranos y demo integrada |
| R08 | Permisos débiles | Media | Alto | Seguridad en backend y pruebas 401/403 |
| R09 | Corrupción por doble edición | Media | Alto | Versionado y transacciones |
| R10 | Pérdida de tiempo en diseño | Media | Medio | Design system mínimo y componentes reutilizables |
| R11 | Requisitos académicos distintos a los supuestos | Media | Alto | Validación docente en H0 |
| R12 | Despliegue tardío | Media | Medio | Ensayar instalación desde H1 |

## Señales tempranas
Más pantallas que flujos completos; datos copiando fuentes sin procedencia; discusión de frameworks sin prototipo vertical; tablas hardcodeadas; errores 403 solo en UI; tres módulos sin esquema compartido.

## Plan de contingencia
Congelar P1/P2; demostrar contenido sintético claro; simplificar número de competiciones sin borrar disciplinas; priorizar publicación/consulta y trazabilidad. Escalar a docentes si una rúbrica contradice alcance.
