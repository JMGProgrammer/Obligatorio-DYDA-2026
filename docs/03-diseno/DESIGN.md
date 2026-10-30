# DESIGN — Interfaz y dirección de arte

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · cliente móvil futuro vía HTTP/JSON.  
> Estado: especificación de trabajo; confirmar versión .NET y exigencias de la docencia.

## 1. Identidad
REPORTEROS se presenta con **Sports Editorial / Dark Tech**: editorial deportivo contemporáneo, legibilidad de marcador y guiños uruguayos mediante tero y celeste. No imitar escudos oficiales. Se inspiran las pantallas en las siete imágenes de referencia entregadas por el equipo, sin tratarlas como diseños finales ni copiar elementos de terceros.

## 2. Tokens iniciales (propuestos)
| Token | Valor | Aplicación |
|---|---|---|
| `--bg` | `#0B1018` | Fondo general |
| `--surface` | `#172334` | Paneles |
| `--accent` | `#58B8F8` | Identidad, CTA |
| `--text` | `#F5F8FC` | Texto principal |
| `--live` | `#25CC93` | Solo estado en vivo real |
| `--danger` | `#F26873` | Errores |
| `--basket` | `#F0A25A` | Tag de básquetbol |
| `--esports` | `#A395FF` | Tag esports |

Tipografías propuestas: Sora para display y títulos; Inter para interfaz y números tabulares. Fallback system-ui. Marca y eslogan aún pueden recibir ajustes gráficos sin alterar naming.

## 3. Estructura de escritorio
Cabecera con isotipo, navegación y búsqueda; hero editorial moderado; franja de encuentros; bloques por deporte; noticias y estadísticas; footer con metodología de datos. Priorizar jerarquía por actualidad y fiabilidad, no solo cantidad de tarjetas. Sidebar opcional para filtros en páginas de resultados.

## 4. Móvil
Header reducido y menú accesible; filtros plegables; marcadores compactos y listas verticales; no depender de hover; tablas con desplazamiento horizontal señalado o columnas esenciales; interacción táctil con objetivos cómodos.

## 5. Componentes y estados
`SiteHeader`, `SportSwitcher`, `MatchCard`, `Scoreboard`, `CompetitionBadge`, `StandingsTable`, `NewsCard`, `FilterBar`, `SourceLabel`, `TeamAvatar`, `StatusPill`, `EmptyState`, `ErrorState`, `Skeleton`, `ModalConfirm`, `AdminGrid`, `AuditDiff`.
- Cargando: skeleton no parpadeante.
- Sin datos: explicar filtro/fecha y cómo restaurar.
- Error: mensaje legible y reintentar.
- Pendiente: mostrar «Sin confirmar».
- Fecha y hora: indicar horario de Uruguay.

## 6. Accesibilidad
Contraste mínimo objetivo AA para texto; foco visible; landmarks HTML; texto alternativo contextual; botones con nombre accesible; no comunicar estados únicamente por color; tablas con cabeceras reales; respetar `prefers-reduced-motion`; el movimiento nunca debe ser indispensable.

## 7. Redacción de interfaz
Tono breve, informativo, uruguayo moderado. Ejemplos: «No hay encuentros registrados para esa fecha», «Resultado pendiente de verificación», «Actualizado el DD/MM/AAAA, HH:mm (UY)». No exagerar certeza ni emplear «oficial» sin sustento.

## 8. Figma/prototipo pendiente
Entregables recomendados: portada desktop/mobile, listado de encuentros, detalle, tabla, noticia, esports/serie y flujo de publicación admin; estados vacío, error y carga; biblioteca de componentes con variantes.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil futuro reutiliza esos endpoints con la tecnología que determine su materia. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Diseño funcional Blazor
Páginas con `@page` en componentes `.razor` y `@rendermode` según necesidades; navbar, tarjetas, filtros y tablas como componentes compartidos. Un `ApiClient` por agregado consume JSON. Cada pantalla contempla carga, vacío, error/red y éxito. Backoffice con `EditForm` + validación de UI, pero autorización y reglas en API. **No** utilizar `@inject ReporterosDbContext` en componentes.
