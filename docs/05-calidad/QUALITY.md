# QUALITY — Estándares y Definition of Done

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

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
