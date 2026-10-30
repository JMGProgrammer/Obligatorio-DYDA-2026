# STAKEHOLDERS — Interesados y validación

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Matriz de interesados
| Parte | Interés | Participación sugerida | Validación |
|---|---|---|---|
| Equipo de 3 estudiantes | Entregar producto integrado | Desarrollo, análisis y pruebas | Revisiones semanales |
| Docentes | Cobertura del obligatorio | Revisión de entregables | Aprobación de alcance |
| Visitantes | Información clara | Test de usabilidad | Búsqueda y lectura de resultado |
| Editores simulados | Carga eficiente | Sesiones de prueba | Flujo de publicación |
| Fuentes/organizaciones | Representación correcta | Consulta si se usan sus datos | Atribución/licencia |

## Guion de validación con usuarios
1. ¿Dónde mirás fechas y resultados de tus deportes? 2. ¿Qué información cuesta encontrar? 3. ¿Buscás por equipo, campeonato o fecha? 4. ¿Cómo comprobás que un resultado es confiable? 5. ¿Preferís lista, calendario o portada? 6. ¿Seguís esports y qué datos esperás de una serie? 7. ¿Qué te resultaría confuso en una tarjeta? 8. ¿Qué cambiarías después de usar un prototipo?

## Evidencias a recoger
Fecha, perfil general sin datos personales excesivos, tareas completadas, observaciones, decisiones de diseño tomadas y pendientes. No inventar entrevistas ni citar instituciones que no hayan participado.

## Supuestos principales
El visitante quiere acceso sin registro; un editor puede verificar información manualmente; existen fuentes consultables para muestras; la asignatura admite web con base de datos. Todos deben comprobarse.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Trazabilidad de implementación
La información pública se obtiene de la API común; la administración usa el mismo backend autenticado. Esta decisión es transversal a todos los interesados y define la entrega integradora.
