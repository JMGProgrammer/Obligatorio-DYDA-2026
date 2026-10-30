# MASTER — REPORTEROS | Producto, marca y stack académico definitivo

**Versión 2 · 30/10/2026 · Equipo: Juan Meny, Mateo Rilla y Facundo Villalba.**

## Descripción ejecutiva
REPORTEROS es un centro de información deportiva uruguaya enfocado en fútbol, básquetbol y esports. El nombre combina «reporteros» con «teros», símbolo del Uruguay. Ofrece agenda, resultados, posiciones, perfiles y noticias con procedencia editorial y control administrativo. No implica vínculos oficiales con AUDV ni federaciones.

## Arquitectura elegida
- API REST en ASP.NET Core/C# como fuente única de lógica de negocio, autorización, validación, datos y auditoría.
- MySQL como base de datos central, exclusivamente accesible desde infraestructura del backend.
- Blazor Web App como aplicación web; consume API por HTTP/JSON y no consulta la base de datos directamente.
- App móvil futura de tecnología por definir; utilizará la misma API y la misma fuente de datos.
- EF Core y `InteractiveServer` son recomendaciones sujetas a compatibilidad y aprobación, no decisiones cerradas.

## Marca y eslogan
Principal propuesto: «El deporte uruguayo tiene quien lo cuente». Alternativas: «El país juega. Nosotros te lo contamos»; «Cada resultado cuenta»; «Del estadio al servidor»; «Todo el deporte en una misma tribuna»; «Donde el deporte se vuelve noticia». Estética deportiva editorial oscura, celeste #58B8F8, fondo #0B1018, Sora e Inter; el logo final vectorial aún requiere diseño y validación.

## MVP
Inicio, consultas por disciplina, competición/temporada, partidos/resultados, noticias, gestión de usuarios/roles, panel editorial, publicación de resultados con auditoría, clasificaciones cuando el reglamento es definido. Excluidos datos en vivo sin fuente, convenios no confirmados, creación de torneos como foco y app móvil terminada.

## Demostración académica
Mostrar el mismo encuentro desde Blazor y desde un cliente HTTP externo, ambos vía API. Modificarlo de forma autorizada y comprobar que MySQL, el endpoint y las pantallas muestran datos coherentes; repetir con errores 401/403/409.

## Documento fuente por especialidad
- `../../README.md`: índice y decisiones generales.
- `../04-tecnica/TECH-STACK.md`: tecnologías confirmadas y pendientes.
- `../04-tecnica/ARCHITECTURE.md`: capas y secuencias.
- `../04-tecnica/API.md`: endpoints.
- `../04-tecnica/DATABASE.md`: modelo de datos.
- `../04-tecnica/BLAZOR.md`: web.
- `../04-tecnica/MOBILE-INTEGRATION.md`: reutilización en Desarrollo Móvil.
- `../02-requisitos/REQUIREMENTS.md`: requisitos y criterios verificables.

---

## Descripción funcional ampliada

La información deportiva uruguaya se publica en diversos medios, redes sociales, sitios de federaciones y comunidades. Para seguir fútbol, básquetbol y esports puede ser necesario consultar varias fuentes, con formatos heterogéneos, escasa trazabilidad o diferencias en actualización. Este es el **problema planteado por el equipo**; debe validarse con entrevistas y revisión de fuentes, no presentarse como estudio demostrado.

## 2. Solución
Portal editorial multideportivo donde el público encuentre noticias, fichas de competiciones, participantes, programación, resultados y tablas. Un panel de administración permite carga, revisión, publicación y rectificación controlada. Cada dato deportivo tiene contexto: disciplina, competición, temporada, fuente, estado y fecha de actualización.

## 3. Objetivos SMART propuestos para el obligatorio
- Entregar un recorrido completo de consulta pública por las tres disciplinas.
- Publicar datos de demostración coherentes de al menos una competición de ejemplo por disciplina; los torneos concretos se acordarán con docentes.
- Garantizar que un usuario sin permisos no pueda publicar ni corregir resultados.
- Conservar registro de autor, fecha, fuente y justificación en las correcciones relevantes.
- Probar al menos una tabla de clasificación de fútbol/básquetbol y un cuadro o serie de esports con reglas explícitas.

## 4. Usuarios
| Actor | Necesidad | Resultado esperado |
|---|---|---|
| Visitante/hincha | Enterarse de qué se juega y quién ganó | Buscar y consultar sin crear cuenta |
| Seguidor de esports | Encontrar partidas por juego o torneo | Ver series, mapas y resultados con formatos apropiados |
| Periodista/aficionado | Consultar contexto | Ubicar fuentes y fecha de actualización |
| Editor | Publicar noticias y datos | Borradores, revisión, vista previa y publicación |
| Administrador | Mantener calidad y seguridad | Usuarios, permisos, auditoría y catálogos |

## 5. Diferenciación
Identidad uruguaya mediante el nombre REPORTEROS y el tero; deportes tradicionales y esports en la misma interfaz; lenguaje editorial consistente; estados honestos de verificación. **No se promete exclusividad de cobertura, actualización automática, derechos de imágenes ni acuerdos oficiales.**

## 6. Principios
1. Exactitud antes que velocidad. 2. Fuente antes que afirmación de oficialidad. 3. Núcleo de datos compartido, reglas deportivas especializadas. 4. Mobile-first. 5. Administración simple y auditable. 6. Accesible y rápida en equipos modestos.

## 7. Indicadores para demostración
Porcentaje de casos de prueba críticos aprobados; cantidad de entidades y encuentros de muestra coherentes; tiempo para completar un flujo editorial; errores de clasificación detectados; cobertura de pantallas móviles; ausencia de publicaciones no autorizadas.

## 8. Preguntas por validar
Qué torneos se incluirán; fuentes y derechos de uso; datos disponibles para esports; si incluir jugadores individuales en MVP; hosting, stack y requisitos de la asignatura; nivel de profundidad de estadísticas.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Alcance integrador preciso
El proyecto consta de **dos aplicaciones desplegables**: `Reporteros.Api` y `Reporteros.Web` más la base MySQL; el móvil es cliente posterior, no funcionalidad exigida para el primer entregable. El valor académico principal es demostrar que web y móvil pueden reutilizar **la misma lógica central**. Se prioriza primera entrega de consultas públicas, resultados aprobados, noticias y administración básica; las reglas de deportes se codifican en servicios C# del backend.


---

## Identidad visual extendida
 Marca y significado
Nombre definitivo elegido: **REPORTEROS**, lectura dual *reporteros* + *teros*, ave nacional. Escritura institucional: Reporteros; wordmark: REPORTEROS. Descriptor: **Centro de información deportiva uruguaya**. Identidad nacional sin atribuciones federativas ni uso de escudos oficiales.

## 2. Eslogan y frases — todas propuestas salvo aprobación posterior
**Institucional principal:** «El deporte uruguayo tiene quien lo cuente.»

### Alternativas institucionales
- «Todo el deporte. En un mismo lugar.»
- «Uruguay juega. REPORTEROS informa.»
- «La información también juega.»
- «El deporte que nos une.»
- «Cada disciplina tiene su historia.»

### Campañas / home
- «El país juega. Nosotros te lo contamos.»
- «De cada cancha, de cada partida.»
- «Donde pasa el deporte uruguayo.»
- «Viví el partido. Entendé el resultado.»
- «Más que marcadores: historias.»

### Resultados / estadísticas
- «Cada resultado cuenta.»
- «Detrás de cada número hay un partido.»
- «La fecha, el dato, la historia.»
- «Seguimos cada jugada.»

### Esports
- «Del estadio al servidor.»
- «En la cancha y en pantalla.»
- «También se compite con teclado y mouse.»
- «El gaming uruguayo entra en juego.»

### Tero / personalidad
- «El tero que te cuenta todo.»
- «Siempre atentos a lo que se juega.»
- «Ojo al partido.»

## 3. Logotipo conceptual
Tero estilizado de formas geométricas, mirada alerta; recurso secundario de señal/noticia/dato. Un wordmark contundente en Sora Bold/ExtraBold como punto de partida; modificar trazos para singularidad si se diseña el vector final. Versiones: horizontal, compacto, isotipo, monocromático, invertido y favicon. Conservar legibilidad en 24px y no depender de degradados.

## 4. Paleta propuesta
`#0B1018` fondo negro cancha; `#172334` panel; `#58B8F8` celeste tribuna; `#F5F8FC` texto; `#25CC93` estado en vivo real; `#F26873` errores; `#F0A25A` básquetbol; `#A395FF` esports. Comprobar contraste por uso y no comunicar únicamente por color.

## 5. Tipografía
**Sora 600–800:** titulares y marca. **Inter 400–700:** texto y controles, cifras `tabular-nums`. Fallback system-ui. No distribuir archivos de fuentes en el repositorio sin respetar licencias.

## 6. Sistema gráfico
Retícula consistente, bloques editoriales, fotografías autorizadas, tarjetas de resultados legibles, alto contraste, iconos lineales. Motivos opcionales: pluma/ala, puntos de datos y trazos abstractos de cancha. Evitar exceso de celeste, estética exclusivamente futbolera o caricaturas infantiles del tero.

## 7. Voz editorial
Ágil, cercana y precisa; sin clickbait, sin datos no verificables, sin afirmar asociaciones inexistentes, sin presentarse como medio oficial. Preferir «Resultado pendiente de confirmación» a inventar marcador. Informar fecha/fuente en cambios relevantes.

## 8. Aplicaciones
Hero web y navegación, avatar social, favicon, banners para repositorio, fichas de partidos, infografías y plantillas de noticias. Cada formato mantiene márgenes de seguridad, legibilidad, crédito de imagen y misma marca.

## 9. Uso incorrecto
No estirar logo; no alterar proporciones; no añadir símbolos oficiales; no usar el estado «EN VIVO» sin actualización real; no atribuir el tero a una organización; no usar combinaciones de color ilegibles; no copiar directamente marcas deportivas existentes.

## 10. Validaciones pendientes
Disponibilidad DNPI y dominios/handles; aprobación del boceto vectorial; contraste de versiones reales; derechos de imagen; eslogan definitivo. **Consultar el documento maestro** para fundamentación ampliada de naming y tono.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Integración de branding a Blazor
Definir variables CSS reutilizables en `wwwroot/css`, componentes `.razor` y guías de iconografía; la API entrega **contenido** (resultado, estado, procedencia) y no clases CSS. El color por estado y los layouts viven solo en Web; la app móvil futura adopta identidad visual sin acoplarse al código Blazor.
