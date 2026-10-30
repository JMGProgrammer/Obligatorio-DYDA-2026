# DEPLOYMENT | Entornos, configuración y ejecución

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Entornos
- **Local:** MySQL local o contenedor, API en puerto de desarrollo, Blazor en otro puerto. URLs separadas y documentadas.
- **Testing:** base de pruebas aislada y migraciones automáticas solo cuando corresponda; datos ficticios.
- **Demo:** API y Blazor accesibles por HTTPS, MySQL privada; URLs conocidas por docentes.

## Configuración recomendada
API: `ConnectionStrings:Reporteros` (secreto), `AllowedHosts`, configuración auth y logs. Blazor: `Api:BaseUrl` pública/accesible desde servidor web. **No** incrustar credenciales MySQL ni tokens en componentes `.razor` o archivos estáticos.

## Arranque reproducible
1. Restaurar paquetes desde `dotnet restore`.
2. Iniciar MySQL y crear credencial de servicio sin privilegios de root.
3. Aplicar migraciones EF (si se adopta ORM) o scripts versionados aprobados.
4. Arrancar `Reporteros.Api`, verificar `/health` opcional y `GET /api/v1/sports`.
5. Arrancar `Reporteros.Web` con `Api:BaseUrl` correcto.
6. Probar consulta desde Blazor, curl/Postman y registro admin.

## Orígenes y CORS
La necesidad y el origen CORS dependen de si la llamada HTTP se ejecuta desde servidor Blazor o navegador. Configurar solo orígenes realmente necesarios; evitar habilitar `AllowAnyOrigin` con credenciales.

## Observabilidad
Logs por componente y correlation id; sin contraseñas ni tokens. Registrar cambios sensibles y errores de base de datos. Health checks, rate limiting y logging estructurado son mejoras recomendadas si las exige el curso.

## Backups
Guardar backups fuera del mismo volumen principal, probar restauración, preservar migraciones y procedimiento para recrear datos demo. No subir dumps con cuentas reales.

## Entrega
Repositorio con solución, docs, scripts/migraciones, README de instalación, archivo de configuración de ejemplo **sin secretos**, colección HTTP/OpenAPI y demo reproducible.
