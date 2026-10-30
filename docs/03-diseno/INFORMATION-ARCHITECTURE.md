# INFORMATION-ARCHITECTURE — Mapa del sitio y flujos

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## 1. Árbol de navegación público
```text
/
├── futbol/
├── basquetbol/
├── esports/
│   └── juegos/:slug/ (opcional)
├── competiciones/
│   └── :slug/temporadas/:season/
├── encuentros/
│   └── :id/
├── equipos/:slug/
├── noticias/
│   └── :slug/
├── buscar/ (P1)
└── acerca-de/fuentes-y-metodologia/
```

## 2. Árbol privado
```text
/admin/login
/admin
├── encuentros
├── resultados/revision
├── competiciones
├── temporadas
├── equipos
├── juegos
├── noticias
├── fuentes
├── auditoria (según permiso)
└── usuarios (solo admin)
```

## 3. Fichas
- **Inicio:** hero, últimos resultados, próximos encuentros, noticias y accesos de disciplina.
- **Disciplina:** contexto, selector de competición/temporada, calendario, tablas o cuadro, noticias.
- **Competición:** identificación, organizador si verificable, formato, temporadas, participantes, fixture.
- **Encuentro:** competición, equipos, hora, estado, resultado, fases/mapas aplicables, fuente y actualización.
- **Equipo:** escudo autorizado o placeholder, descripción, encuentros y competencias relacionadas.
- **Noticia:** título, bajada, cuerpo, autor, timestamps, fuentes y recursos autorizados.

## 4. Flujos críticos
**Consulta:** Inicio → Fútbol → competición → encuentro → fuente/actualización. **Edición:** Login → crear competición/temporada → crear equipos → encuentro → resultado provisional → revisar/aprobar → consultar públicamente. **Corrección:** detalle admin → solicitar cambio → motivo → validación → persistencia atómica → actualización de tabla → auditoría.

## 5. Manejo de URLs y fallos
IDs internos inmutables; slugs amigables únicos por contexto; preservar filtros en query string; 404 para inexistente, 403 para prohibido; contenido no publicado no indexable; redireccionar slugs modificados si existe contenido público previo.

## 6. Permisos de navegación
Ocultar navegación administrativa a visitantes como UX, pero validar cada petición desde servidor. No exponer metadata privada en el HTML/JSON público.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Mapa entre URL Blazor y recurso API
`/partidos` → `GET /api/v1/matches`; `/partidos/{id}` → `GET /api/v1/matches/{id}`; `/futbol`, `/basquetbol`, `/esports` → `GET /api/v1/competitions?sport=...`; `/noticias` → `GET /api/v1/articles`; `/admin/partidos` → rutas `/api/v1/admin/matches`. El navegador nunca genera queries SQL.
