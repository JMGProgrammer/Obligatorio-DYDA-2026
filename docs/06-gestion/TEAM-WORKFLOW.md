# TEAM-WORKFLOW — Organización del equipo

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## Equipo
Juan Meny · Mateo Rilla · Facundo Villalba. La asignación efectiva de tareas **aún no está acordada**: evitar asignaciones ficticias o suponer liderazgo sin decisión de los integrantes.

## 1. Organización recomendada
Tres frentes rotativos: experiencia web, lógica/API y datos/calidad. Cada módulo debe tener un responsable principal y un revisor distinto; todos deben comprender un recorrido funcional transversal y participar en diseño, pruebas e integración.

## 2. Git y ramas
`main` estable; ramas `feature/RF-XX-descripcion`, `fix/TC-XX-descripcion`, `docs/tema`; PR con descripción, issue, captura cuando UI, pruebas y cambios de BD. No fusionar código sin ejecutar migraciones o verificar contratos.

## 3. Ciclo semanal adaptable
Planificación con 3 resultados concretos; check-in breve; demo interna de progreso; revisión de riesgos y deuda; actualización de tablero. No acumular toda la integración para el cierre.

## 4. Estructura sugerida repositorio
```text
reporteros/
├── README.md
├── docs/
├── src/                # adaptar al stack
├── tests/
├── database/           # migraciones + seeds
├── assets/             # recursos con licencia
├── .env.example        # nunca secretos
└── .gitignore
```

## 5. Registro de decisiones
Decisiones permanentes en `DECISIONS.md`: contexto, opciones, decisión, responsables y fecha. Cualquier cambio que altere alcance, datos o permisos actualiza primero requisitos y pruebas.

## 6. Entregables por materia
Mapear explícitamente qué esperan programación, base de datos e ingeniería/análisis según pautas docentes; no asumir criterios. Conservar evidencias: MER, normalización, consultas, diagramas, casos y código integrado.

## 7. Política de conflictos
Problema técnico bloqueante se documenta con reproducción mínima y propuestas. Decisiones disputadas se resuelven contra alcance, tiempo, mantenibilidad y rúbrica docente; registrar consecuencias.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Coordinación para tres estudiantes
Rotar trabajo entre Api, MySQL y Blazor en cada hito, evitando que una persona quede excluida de la API (núcleo académico). Cada PR debe comprobar contrato JSON y no romper el cliente web; acordar cambios de esquema con el integrante que trabaja en UI y pruebas. No se asignan responsabilidades personales fijas sin decisión del grupo.
