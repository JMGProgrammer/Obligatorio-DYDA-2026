# RISKS — Riesgos y mitigación

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## Matriz de riesgos (estimación de planificación)
Escala probabilidad/impacto: bajo, medio, alto; revisarla en reuniones.

| ID | Riesgo | Prob. | Impacto | Mitigación |
|---|---|---|---|---|
| R01 | Alcance multideportivo excesivo | Alta | Alto | MVP acotado + vertical completa |
| R02 | Falta de fuente fiable de resultados | Alta | Alto | Dataset demo etiquetado; fuente manual validada |
| R03 | Complejidad de formatos distintos | Alta | Alto | Reglas especializadas por deporte; empezar simple |
| R04 | Intento de vivo sin proveedor | Media | Alto | Excluir vivo del MVP |
| R05 | Conflicto de nombre/marca | Media | Medio | Verificación DNPI, dominios y uso no comercial hasta validar |
| R06 | Uso indebido de imágenes/logotipos | Media | Alto | Licencias, placeholders, créditos |
| R07 | Desacople frontend/backend/BD | Alta | Alto | Contratos tempranos y demo integrada |
| R08 | Permisos débiles | Media | Alto | Seguridad en backend y pruebas 401/403 |
| R09 | Corrupción por doble edición | Media | Alto | Versionado y transacciones |
| R10 | Pérdida de tiempo en diseño | Media | Medio | Design system mínimo y componentes reutilizables |
| R11 | Requisitos académicos distintos a los supuestos | Media | Alto | Validación docente en H0 |
| R12 | Despliegue tardío | Media | Medio | Ensayar instalación desde H1 |

## Señales tempranas
Más pantallas que flujos completos; datos copiando fuentes sin procedencia; discusión de frameworks sin prototipo vertical; tablas hardcodeadas; errores 403 solo en UI; tres módulos sin esquema compartido.

## Plan de contingencia
Congelar P1/P2; demostrar contenido sintético claro; simplificar número de competiciones sin borrar disciplinas; priorizar publicación/consulta y trazabilidad. Escalar a docentes si una rúbrica contradice alcance.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Riesgos específicos del stack
| Riesgo | Impacto | Mitigación |
|---|---|---|
| Blazor intenta conectarse a MySQL directo | Rompe reutilización móvil | Revisión de referencias y prueba API externa |
| Incompatibilidad EF Core/proveedor MySQL/.NET | Bloquea desarrollo | Validar matriz de compatibilidad en H0 |
| Confusión Razor Pages vs Blazor Web App | Arquitectura errónea | Confirmar plantilla de proyecto con docente |
| Autenticación de Web no funciona en móvil | Retrabajo | Diseñar frontera API y auth independiente de navegador |
| CORS incorrecto | Fallos de entorno | Configurar orígenes reales; diferenciar Server vs WASM |
| API inaccesible desde dispositivo móvil | Imposibilita demo futura | HTTPS y host accesible; no usar `localhost` de PC |
| Resultados ficticios confundidos con oficiales | Reputación | Etiquetas de demo y fuentes |
