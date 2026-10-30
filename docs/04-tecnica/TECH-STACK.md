# TECH-STACK — Opciones y decisión técnica

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Estado
**Ningún stack fue confirmado**. Este archivo propone alternativas compatibles con un proyecto web académico; verificar con docentes lenguajes, frameworks, hosting, base de datos y exigencias de integración entre asignaturas.

## 2. Alternativa A — React + TypeScript + API ASP.NET Core + SQL Server
Ventajas: SPA flexible, TypeScript, backend C# con autorización robusta y modelado relacional; alineado con herramientas estudiadas. Costos: dos proyectos y complejidad de despliegue, CORS y autenticación. Recomendada **si** la asignatura exige C#/SQL Server o el equipo dispone de tiempo.

## 3. Alternativa B — ASP.NET Core MVC/Razor Pages + SQL Server
Ventajas: un backend integrado, formularios, validación server-side, menor infraestructura. Costos: componentes ricos y actualización de UI más manual. Recomendada **si** se prioriza entrega académica estable y menor complejidad.

## 4. Alternativa C — React/TypeScript + Node.js + PostgreSQL
Ventajas: lenguaje compartido y ecosistema web amplio. Costos: separar API/UI y aprendizaje de persistencia/operación. Viable solo si está permitida y resulta conocida al equipo.

## 5. Matriz de decisión (completar)
| Criterio | Peso sugerido | A | B | C |
|---|---:|---|---|---|
| Compatibilidad con asignatura | 30% | Pendiente | Pendiente | Pendiente |
| Dominio del equipo | 25% | Pendiente | Pendiente | Pendiente |
| Tiempo de entrega | 20% | Pendiente | Pendiente | Pendiente |
| Facilidad de despliegue | 15% | Pendiente | Pendiente | Pendiente |
| Mantenibilidad | 10% | Pendiente | Pendiente | Pendiente |

## 6. Requisitos de infraestructura independientes del stack
Persistencia relacional y restricciones; autenticación y roles server-side; migraciones versionadas; configuraciones por entorno; logs sin secretos; backups; generación de datos de demo; test automatizados; almacenamiento de archivos solo con licencias/metadatos.

## 7. Política de bibliotecas
Versionar dependencias y registrar sus licencias. Antes de implementar confirmar requisitos de soporte, actualizaciones de seguridad y versiones vigentes; no fijar versiones supuestamente actuales sin consulta.

## 8. Decisión ADR pendiente
Completar fecha, alternativas comparadas, razones, impacto en CI/CD y aprobación de docente/equipo en DECISIONS.md. Evitar iniciar tres stacks en paralelo.
