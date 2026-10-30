# DATA-SOURCES — Proveniencia y calidad de datos

> **REPORTEROS · Proyecto obligatorio · Equipo:** Juan Meny, Mateo Rilla y Facundo Villalba.  
> **Estado documental:** propuesta para validación académica. **Confirmado:** nombre REPORTEROS; plataforma deportiva uruguaya; fútbol, básquetbol y esports; enfoque informativo. **No confirmado:** stack definitivo, competiciones exactas, calendario, fuentes e instituciones asociadas.

## 1. Política de datos
Se distinguen **datos demostrativos**, **datos públicamente consultables** y **datos autorizados por entidad**. El acceso público a un dato no supone derecho a reproducir en masa imágenes, logos o bases de datos. No adjudicar oficialidad sin licencia/convenio.

## 2. Catálogo de fuentes (pendiente de completar)
| Tipo | Ejemplo de uso | Revisión necesaria |
|---|---|---|
| Federaciones/ligas | Calendarios y resultados | Permisos/atribución/actualización |
| Publicaciones de clubes | Información de equipos | Fecha, contraste, derechos de imágenes |
| Organizadores esports | Series y formatos | Confirmar alcance AUDV y fuentes por juego |
| Redacción manual | Noticias propias | Autor, referencias y revisión |
| Datos sintéticos | Demo académica | Etiquetar visiblemente como demo |

## 3. Metadatos mínimos de registro
`source_id`, URL si existe, autor/editor que cargó, instante de consulta, grado de verificación, instante de última modificación, observaciones de discrepancia; para imágenes licencia/autor/crédito.

## 4. Flujo editorial
Recibir información → registrar fuente → contrastar cuando corresponda → cargar borrador → revisar inconsistencias → aprobar/publicar → registrar actualización → corregir con motivo si cambia. El revisor es responsable de aprobación editorial, no certifica que una federación haya avalado el dato.

## 5. Frecuencia y límites
MVP manual bajo demanda, sin garantías de tiempo real; mostrar última actualización. Un evento sin fuente verificada puede mostrarse como pendiente o mantenerse interno según política. Prohibido convertir automáticamente el paso del tiempo en resultado final.

## 6. Calidad
Detección de duplicados por competencia/fecha/equipos; comprobaciones de modalidad; coherencia de estado y marcador; fechas plausibles; fuentes caducadas; auditoría de corrección. Una dashboard administrativa de calidad es P1.

## 7. Integraciones futuras
Evaluar proveedor, autenticación, términos, cobertura de Uruguay, coste y fiabilidad. Diseñar adaptadores desacoplados con importación idempotente, registro de ejecuciones, resolución de conflictos y revisión humana. No comprometer scraping ni feeds inexistentes.
