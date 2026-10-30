# ARCHITECTURE — Diseño lógico

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Arquitectura funcional
```text
Navegador (público/admin)
        │ HTTPS
Frontend web ──> Aplicación/API ──> BD relacional
                     │ │ │
                   Auth│ └── Auditoría
                       └──── Reglas de dominio
                  [integración externa FUTURA]
```
Separar presentación, casos de uso, dominio y persistencia incluso en un monolito modular. El MVP no necesita microservicios ni streaming.

## 2. Módulos
1. Identidad y permisos; 2. Catálogo deportivo (disciplina/juego, competición, temporada, participantes); 3. Agenda y resultados; 4. Clasificaciones/estadísticas; 5. Editorial; 6. Fuentes y auditoría; 7. Búsqueda (P1).

## 3. Casos de uso de aplicación
`CreateCompetition`, `CreateSeason`, `RegisterTeam`, `ScheduleMatch`, `SubmitScore`, `ApproveResult`, `CorrectPublishedResult`, `RebuildStandings`, `PublishArticle`, `GetPublicHome`. Cada caso valida permiso, entrada y consistencia; retorna errores estructurados.

## 4. Principios de persistencia
Normalización por entidad; claves técnicas; claves de negocio únicas donde correspondan; foreign keys; auditoría de cambios; índices sobre fecha/competición/estado; escrituras transaccionales. No almacenar tabla de posiciones como verdad separada sin mecanismo claro de invalidación y reconstrucción.

## 5. Clasificaciones
Calcular con una estrategia por formato (puntos de fútbol, clasificación de básquetbol configurable, fase eliminatoria esports). Mantener algoritmo probado con fixtures sintéticos y empate/desempates documentados. Cache opcional solo después de correctitud.

## 6. Concurrencia
Cada resultado tiene `version` para control optimista. Si otro editor publicó antes, responder conflicto 409; mostrar cambios y solicitar revisión. Auditoría en la misma transacción de la corrección.

## 7. Seguridad
TLS en despliegue; cookies seguras HttpOnly SameSite si se usa sesión; protección CSRF en flujos cookie; contraseñas con hash moderno; validación DTO; roles por endpoint; rate-limit de autenticación; secretos en variables de entorno.

## 8. Rendimiento
Paginación en noticias/listados; carga diferida de imágenes; índices e inspección de consultas; API cacheable solo para contenido público confirmado. No sobreingeniería antes de medir.

## 9. Estrategia de despliegue
Entorno local → entorno de prueba → presentación. Migraciones reproducibles, seed de demo, configuración independiente de código, backup y recuperación ensayada. La elección de proveedor queda pendiente.
