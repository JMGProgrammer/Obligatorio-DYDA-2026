# QUALITY — Estándares y Definition of Done

> **REPORTEROS — Centro de información deportiva uruguaya**  
> Equipo: Juan Meny · Mateo Rilla · Facundo Villalba  
> **Stack confirmado por el equipo:** ASP.NET Core Web API (C#) · MySQL · Blazor Web App (.NET) · Expo + React Native (Expo Go) vía HTTP/JSON.
> Estado: especificación de trabajo; validar exigencias específicas con la docencia.

## 1. Definition of Ready
Historia con actor, intención, regla, criterios de aceptación, diseño de pantalla si aplica, dependencia de base de datos y pruebas identificables.

## 2. Definition of Done
Código fusionado con revisión; validación de permisos; pruebas del comportamiento; migraciones aplicadas; mensajes y estados vacíos; mobile y teclado; documentación de contratos actualizada; sin secretos ni warnings críticos; caso demo comprobado.

## 3. Rendimiento propuesto
Definir presupuesto de imágenes y fuentes; paginar grandes listados; optimizar consultas por índice; evitar librerías pesadas sin beneficio. Medir con herramientas de navegador en equipo de referencia y móvil emulado; establecer umbrales después de primera medición, no inventarlos como requisitos cumplidos.

## 4. Accesibilidad
HTML semántico, tablas con `th`, etiquetas, contraste AA, navegación por teclado, focus management en diálogos, texto alternativo, reducido movimiento. Verificar al menos portada, filtro, ficha, noticia y formulario administrativo.

## 5. Mantenibilidad
Convenciones de nombres, linters y formateador acordados, commits claros, PRs revisables, modelos de DTO separados del dominio, ninguna regla de clasificación duplicada en frontend y backend.

## 6. Observabilidad
Logs de errores con correlación, actor cuando proceda sin revelar credenciales, eventos de publicación/corrección, métricas básicas. Mensajes públicos no incluyen trazas internas.

## 7. Cierre académico
Demo guiada, scripts de instalación, ERD, casos de prueba, decisiones técnicas, funciones fuera de alcance y evidencias de revisión con docentes.


## Integración académica y reglas de arquitectura obligatorias (v2)
- La **API ASP.NET Core (C#)** es dueña del negocio, los permisos, las reglas de publicación y los reportes; gestiona MySQL desde una capa de infraestructura.
- La interfaz **Blazor Web App** no abre conexiones MySQL ni calcula resultados oficiales por cuenta propia; consume DTO JSON por HTTP, incluso en administración.
- El cliente móvil Expo + React Native reutiliza esos endpoints. El cliente no necesita conocer tablas ni clases Entity Framework.
- El MVP puede demostrarse con datos ficticios rotulados y carga editorial manual; noticias/resultados oficiales o en vivo solo con fuente verificable.
- Los errores HTTP de la API, versiones y contratos se especifican en `../04-tecnica/API.md` y `../04-tecnica/API-CONTRACTS.md`.


## Definición de terminado técnica
Cada función P0 requiere endpoint documentado, DTO, validación server-side, persistencia MySQL, prueba de HTTP, cliente Blazor sin referencia a Infrastructure, comportamiento responsive y fuente de datos documentada. CI (si se incorpora) ejecuta `dotnet build` y `dotnet test` sobre la solución.
