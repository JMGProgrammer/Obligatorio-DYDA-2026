# TEAM-WORKFLOW — Organización del equipo

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

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
