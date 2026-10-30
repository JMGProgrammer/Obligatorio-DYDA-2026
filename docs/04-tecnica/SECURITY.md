# SECURITY — Modelo de permisos y protección

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Activos
Cuentas de editores, resultados, noticias, fuentes, auditoría, credenciales, archivos multimedia y configuraciones. Visitantes no necesitan cuenta para leer información pública.

## 2. Matriz de acceso
| Acción | Visitante | Editor | Revisor | Admin |
|---|---|---|---|---|
| Consultar datos publicados | Sí | Sí | Sí | Sí |
| Crear borrador | No | Sí | Sí | Sí |
| Aprobar/corregir resultado | No | No | Sí | Sí |
| Publicar noticias | No | No | Sí | Sí |
| Administrar roles | No | No | No | Sí |
| Consultar auditoría | No | Limitado/no | Sí (según permiso) | Sí |

## 3. Amenazas y contramedidas
- Fuerza bruta: limitación de intentos y logs.
- Escalada de privilegios: verificar permisos en servidor, no solo botones.
- Inyección SQL: consultas parametrizadas/ORM y validación.
- XSS: escape de contenido y sanitización de HTML editorial.
- CSRF: token y SameSite si autenticación basada en cookies.
- Filtración de secretos: variables de entorno, `.env` ignorado por Git, rotación.
- Archivos maliciosos: restringir formato/tamaño, validar MIME, almacenar fuera de ejecución.
- Manipulación de resultados: control de versión, permisos, transacciones, auditoría.
- Enumeración de borradores: filtrado público obligatorio, no confiar en cliente.

## 4. Sesiones
Caducidad, cierre de sesión, protección de cookies o tokens según arquitectura, reautenticación para operaciones de alto impacto si se requiere. No almacenar contraseñas en claro ni hash débil.

## 5. Datos y privacidad
Recolectar solo emails/nombres de acceso necesarios; limitar logs personales; definir retención de auditoría y respaldos; no exponer datos personales de menores en fichas deportivas sin base y autorización adecuadas.

## 6. Lista de verificación de entrega
Ningún secreto en repositorio; 401/403 probados; endpoints administrativos cerrados; pruebas de XSS y SQL injection; backup restaurable; cuentas demo con contraseñas cambiables; errores sin stack trace público; dependencias revisadas; imágenes con licencia.
