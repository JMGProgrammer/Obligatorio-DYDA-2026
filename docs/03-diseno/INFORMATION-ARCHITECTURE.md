# INFORMATION-ARCHITECTURE — Mapa del sitio y flujos

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

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
