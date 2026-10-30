# TRACEABILITY | Matriz intermaterias

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

| Necesidad | Backend API | MySQL | Blazor | Móvil futuro | Prueba |
|---|---|---|---|---|---|
| Consultar partidos | GET /matches | matches, seasons, teams | Matches.razor | GET /matches | TC-API-01/04 |
| Detalle encuentro | GET /matches/{id} | matches, sources | MatchDetail.razor | GET /matches/{id} | Serialización |
| Corregir resultado | PUT /admin/matches/{id}/result | matches, result_revisions, audit_logs | AdminMatchForm.razor | Opcional, autorizado | TC-API-03/05/06 |
| Clasificación | GET /seasons/{id}/standings | resultados oficiales | StandingsTable | Mismo GET | Domain Tests |
| Noticias | GET /articles y POST /admin/articles | articles, article_sports | News/NewsEditor | GET /articles | HTTP + roles |

## Evidencia para defensa
Capturas de endpoint, Swagger/OpenAPI, esquema MySQL, pantalla Blazor, registro de auditoría y ejecución del **mismo endpoint** en cliente HTTP independiente. Presentar junto con informe de pruebas.
