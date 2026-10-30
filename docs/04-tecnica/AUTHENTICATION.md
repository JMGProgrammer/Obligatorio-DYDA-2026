# AUTHENTICATION | Identidad y autorización API + Blazor

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Estado
C# y ASP.NET Core están cerrados; **el mecanismo de sesión concreto se decide durante implementación** según conocimientos y evaluación docente. El diseño debe admitir hoy una web Blazor y luego un cliente móvil remoto.

## Roles propuestos
- `Visitor`: acceso público sin login.
- `Editor`: crea/edita competiciones, partidos preliminares, borradores de noticias.
- `Reviewer`: confirma resultados y publicaciones.
- `Admin`: administra permisos y auditoría.

## Política
- La autorización se verifica en API, **no** por ocultar botones en Blazor.
- La API emite `401` cuando falta autenticación y `403` cuando existe identidad pero falta permiso.
- `Match.PublishResult` requiere Reviewer/Admin; corrección requiere motivo, versión válida y auditoría.
- Evitar permitir a usuarios arbitrarios registrarse como editores; alta de cuentas administrativas controlada.

## Alternativas a evaluar
**Opción A — Identity + sesión/cookies web y tokens para móvil:** integración sofisticada; requiere documentar emisión, validación, expiración y protección CSRF de cookies.  
**Opción B — autenticación API por bearer tokens con almacén seguro y sesión web mediada por servidor:** facilita consumidores; implementar manejo y renovación seguros.  
**Opción C — solo usuarios de demo administrados por servidor en etapa inicial:** minimiza alcance pero no sirve como solución final de autenticación si la materia la exige.

No inventar JWT propios, no enviar contraseñas salvo por HTTPS, no persistir tokens sensibles de larga vida en localStorage, no exponer claves en `appsettings.json` versionado. Si se usan cookies, proteger endpoints mutables frente a CSRF. Si se usa bearer, verificar firma/issuer/audience y expiración; no confiar en tokens sin validar.

## Flujo ilustrativo
1. Usuario solicita sesión mediante flujo seleccionado.
2. API valida credenciales con proveedor Identity y devuelve el mecanismo acordado.
3. Web conserva un contexto de sesión adecuado a Interactive Server y envía credenciales válidas en operaciones protegidas.
4. API aplica política y rol en cada request; Application también comprueba reglas del recurso.
5. Logout revoca/invalida cuando el esquema lo permite y limpia sesión cliente.

## Pruebas
401 sin login; 403 con rol insuficiente; acceso concedido rol correcto; expiración; logout; CSRF cuando corresponde; intento de modificar rol en payload; pruebas con API directa sin pasar por Blazor.
