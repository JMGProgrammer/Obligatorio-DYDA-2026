# SECURITY | Seguridad de API, MySQL, Blazor y móvil

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Superficie de ataque
Navegador/Blazor, API HTTP, panel de administración, archivos multimedia, conexión MySQL y cliente móvil futuro. El servidor API es la **frontera de confianza**.

## Controles
| Riesgo | Control y prueba |
|---|---|
| SQL injection | ORM/consultas parametrizadas; nunca concatenar SQL desde filtros |
| Escalamiento de privilegios | `[Authorize]`/políticas y prueba a endpoint admin directo |
| IDOR | Validar permisos de operación/lectura según recurso |
| Contraseñas | Identity o hashing resistente con configuración aprobada; jamás texto plano |
| Tokens | Validación servidor, expiración, almacenamiento seguro; no loguearlos |
| CSRF | Antiforgery en endpoints cookie-auth mutables |
| XSS | Codificación de salida Blazor; sanitizar HTML editorial si se admite |
| CORS | Lista explícita de orígenes web, sin wildcard con credenciales |
| Filtración de secretos | User Secrets/variables de entorno, nunca commit ni respuesta API |
| Carga de archivos | Validar MIME real, tamaño, extensión, guardar fuera de raíz ejecutable |
| Datos erróneos | Validación tanto en API como en BD; roles de aprobación |
| DoS y scraping | paginación, límites y rate limiting para endpoints sensibles |
| Auditoría adulterada | permisos estrictos, cambios sensibles dentro de transacción |

## MySQL
Cuenta de servicio de privilegios mínimos; base separada de pruebas; backup y restore ensayados; acceso remoto solo cuando sea necesario y protegido; nunca publicar puerto 3306 a Internet por comodidad.

## Blazor Interactive Server
La sesión web y el estado de circuito son distintos del estado persistente del dominio. Nunca confiar en estado local para autorizar; seguir políticas API. Verificar comportamiento de reconexión y mensajes cuando API cae.

## Privacidad
Publicar solo datos deportivos pertinentes; consentimientos/fuentes/licencias para fotografías y datos personales. Evitar guardar documentos o perfiles de menores innecesariamente.

## Checklist antes de demo
API y web usan HTTPS según entorno; MySQL no está expuesto; secrets no están en repo; cuentas demo sin contraseñas triviales públicas; permisos probados; errores internos no revelan stack traces; backup disponible.
