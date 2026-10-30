# BUSINESS-RULES — Reglas de dominio

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## 1. Principios
**RN-01.** Solo datos aprobados son públicos como resultados confirmados. **RN-02.** Corregir un marcador publicado requiere rol autorizado, motivo y auditoría. **RN-03.** Una misma fuente puede quedar asociada a varios registros, conservando URL/fecha de consulta cuando exista. **RN-04.** La ausencia de dato no se transforma en valor cero.

## 2. Estados de encuentro
`scheduled` → `in_progress` (únicamente con actualización válida) → `pending_review` → `final`; alternativas `postponed`, `suspended`, `cancelled`. Transiciones posibles no implican que el MVP deba mostrar tiempo real. `final` es resultado aprobado, no solo hora pasada. Reprogramación conserva historial.

## 3. Fútbol
- Marcadores enteros mayores o iguales a cero; resultado de tiempo reglamentario separado de penales si estos se registran.
- Propuesta para ejemplo: victoria 3 puntos, empate 1 y derrota 0; no usar automáticamente para todas las competiciones.
- Desempates específicos se guardan por competición/temporada y deben ser aprobados; no inferir el orden real sin reglamento.
- Distinguir etapas, grupos y finales que no suman a una tabla regular.

## 4. Básquetbol
- Marcadores de puntos enteros no negativos; encuentros finalizados ordinariamente tienen ganador, salvo excepciones reglamentarias documentadas.
- Registrar tiempos suplementarios solo si existe el detalle.
- Sistema de puntos de clasificación, sanciones y desempates configurable y documentado; **no asumir** que todas las ligas puntúan igual.

## 5. Esports
- Cada torneo está asociado con un videojuego y modalidad; series pueden ser BO1/BO3/BO5 u otro formato válido.
- En BO3 el primero en dos victorias gana; el total de mapas ganados no excede tres. Empates solo si la modalidad los permite.
- Registrar partidos por mapa/ronda únicamente si hay fuente fiable. Equipos esports pueden diferir de equipos deportivos y admitir tags/planteles específicos.

## 6. Contenido editorial
- Noticia: `draft` → `in_review` → `published` → `archived`, con opción `rejected` que exige comentario.
- Al publicar: fecha, autor/editor y versión. Los cambios sustantivos quedan registrados; una fe de erratas no se elimina silenciosamente.
- Las imágenes solo se publican con derechos o permiso apropiado y metadatos de atribución.

## 7. Roles y visibilidad
Visitante solo lectura pública; editor gestiona borradores; revisor publica/corrige; administrador gestiona roles y parámetros. Aplicar mínimo privilegio. Un usuario puede tener más de un rol si se decide, sin que uno otorgue derechos indiscriminados.

## 8. Integridad y concurrencia
En encuentro finalizado no admitir segundo resultado simultáneo incompatible; usar transacciones y control de versión. No permitir eliminar físicamente registros con referencias de auditoría. Los emparejamientos deben vincular equipos válidos para ese contexto; los equipos deben ser diferentes salvo modalidades excepcionales documentadas.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Ubicación de las reglas (en código)
Las reglas anteriores se implementan en `Reporteros.Api/Services` y se prueban sin Blazor. Las precondiciones de rol se refuerzan en los endpoints API; las restricciones de unicidad/FK se reflejan en MySQL. No distribuir cálculos de tablas en Web y Móvil.
