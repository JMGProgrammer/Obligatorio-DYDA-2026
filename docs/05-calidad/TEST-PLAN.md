# TEST-PLAN — Plan de verificación

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Estrategia
Pirámide: unitarias para reglas y clasificación; integración para persistencia/autorización/API; E2E para navegación y flujo editorial; pruebas manuales de responsive y accesibilidad. Evidencia: ID, versión, datos, pasos, esperado, obtenido, captura/log y responsable.

## 2. Casos prioritarios
| ID | Escenario | Esperado |
|---|---|---|
| TC-01 | Visitante abre home | Datos públicos sin sesión |
| TC-02 | Filtro por deporte/fecha | Resultados pertinentes |
| TC-03 | Partido sin fuente | Aviso de disponibilidad/verificación según política |
| TC-04 | Resultado en borrador | No visible como final público |
| TC-05 | Editor intenta gestionar usuarios | 403 |
| TC-06 | Usuario anónimo publica resultado | 401/403 |
| TC-07 | Revisor aprueba resultado válido | Se publica y registra auditoría |
| TC-08 | Corrección sin motivo | Rechazada sin afectar marcador |
| TC-09 | Dos revisores envían versiones distintas | Segundo obtiene 409 y no sobreescribe |
| TC-10 | Tabla de fútbol con 3-1-0 y varios partidos | Clasificación calculada conforme reglamento de demo |
| TC-11 | BO3 esports 3-1 | Rechazado por formato |
| TC-12 | Básquetbol empate final no permitido | Validación correspondiente |
| TC-13 | Búsqueda sin coincidencias | Estado vacío accesible |
| TC-14 | Artículo no publicado | Invisible para visitante |
| TC-15 | XSS en cuerpo de noticia | Script no ejecutado |
| TC-16 | Hora UTC presentada al usuario | Hora correcta Uruguay |
| TC-17 | Móvil 360px | Sin controles fuera de pantalla ni pérdida de acciones |
| TC-18 | Navegación con teclado | Foco visible, controles operables |

## 3. Datos de prueba
Semillas sintéticas identificadas, incluyendo competiciones y partidos por tres deportes; un partido suspendido; un resultado provisional; una noticia borrador; marcador corregido; serie BO3 y conjunto de standings con empate por puntos.

## 4. Defectos
Severidad S1: acceso indebido, datos públicos falsos por bug, pérdida/corrupción. S2: flujo principal roto. S3: visual o funcional secundario. Para cerrar S1/S2 debe existir prueba de regresión.

## 5. Criterio de salida propuesto
Todos los P0 implementados o excepciones aprobadas por docentes; 100% de pruebas críticas ejecutadas y aprobadas; ningún S1/S2 abierto; demostración de publicación/corrección sin datos reales mal atribuidos; documentación y seed reproducibles.
