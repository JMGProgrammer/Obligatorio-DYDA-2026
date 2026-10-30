#!/usr/bin/env bash
# scaffold.sh — REPORTEROS: genera la solución .NET completa desde cero.
# Variante simplificada acordada: Reporteros.Api (un csproj) + Reporteros.Web (Blazor).
# Corregir desde la raíz del repositorio. Idempotencia: aborta si ya existe la solución.
set -euo pipefail

SLN=Reporteros
API=src/Reporteros.Api
WEB=src/Reporteros.Web

banner() { printf '\n\033[1m== %s ==\033[0m\n' "$*"; }
info()   { printf '  \033[1;36m▸\033[0m %s\n' "$*"; }
ok()     { printf '  \033[1;32m✔\033[0m %s\n' "$*"; }
warn()   { printf '  \033[1;33m!\033[0m %s\n' "$*"; }
die()    { printf '  \033[1;31m✖ %s\033[0m\n' "$*" >&2; exit 1; }

# ── Precondiciones ────────────────────────────────────────────────
banner "REPORTEROS · scaffold"
command -v dotnet >/dev/null 2>&1 || die "dotnet no está instalado: necesitás el SDK de .NET."
[[ -d .git ]] || die "Ejecutá el script desde la raíz del repositorio."
[[ -f "$SLN.sln" || -f "$SLN.slnx" ]] && \
  die "Ya existe una solución ($SLN.sln/.slnx). El scaffold es para arranque limpio; para regenerar borrá $SLN.sln* y src/ (¡eso borra código!)."
[[ ! -e src ]] || die "Ya existe src/: no voy a pisar trabajo existente."

info "SDK: $(dotnet --version)"

# ── 1/4 Solución en formato clásico ───────────────────────────────
banner "1/4 · Solución"
# En .NET 10 'dotnet new sln' crea .slnx (XML) por defecto; -f sln fuerza el clásico
# que sí abren OmniSharp y C# Dev Kit.
dotnet new sln -n "$SLN" -f sln
[[ -f "$SLN.sln" ]] || die "No se generó $SLN.sln: revisá el formato de solución del SDK."
ok "$SLN.sln (clásico, no .slnx)"

# ── 2/4 Reporteros.Api ────────────────────────────────────────────
banner "2/4 · $SLN.Api (Web API con Controllers)"
if dotnet new webapi -n "$SLN.Api" -o "$API" --use-controllers; then
  ok "Web API con Controllers/"
else
  warn "Este template no aceptó --use-controllers; generando plantilla base"
  rm -rf "$API"
  dotnet new webapi -n "$SLN.Api" -o "$API"
  warn "Verificá manualmente que exista Controllers/ (si no, usá Endpoints minimal)."
fi

# ── 3/4 Reporteros.Web ────────────────────────────────────────────
banner "3/4 · $SLN.Web (Blazor Web App, Server)"
if dotnet new blazor -n "$SLN.Web" -o "$WEB" --interactivity Server; then
  ok "Blazor con interactividad Server (ADR-017)"
else
  warn "Este template no aceptó --interactivity; generando plantilla base"
  rm -rf "$WEB"
  dotnet new blazor -n "$SLN.Web" -o "$WEB"
  warn "Revisá el modo de interactividad en App.razor / Program.cs."
fi
# Carpeta reservada para el HttpClient tipado (regla: Web consume la API por HTTP)
mkdir -p "$WEB/Services/ApiClients" && touch "$WEB/Services/ApiClients/.gitkeep"

# ── 4/4 Registrar en la solución + build ──────────────────────────
banner "4/4 · Solución y build"
dotnet sln "$SLN.sln" add "$API/$SLN.Api.csproj"
dotnet sln "$SLN.sln" add "$WEB/$SLN.Web.csproj"

dotnet build "$SLN.sln" --nologo -v q
ok "Build de la solución en verde"

banner "REPORTEROS listo"
dotnet sln "$SLN.sln" list
cat <<'FIN'

 Levantar la solución:
   API   →  dotnet run --project src/Reporteros.Api     (ver el puerto en la consola)
   Web   →  dotnet run --project src/Reporteros.Web
   Certs →  dotnet dev-certs https --trust   (una sola vez en Linux)

 Nota: la plantilla webapi trae Controllers/WeatherForecastController.cs de ejemplo.
 Borrar cuando se implemente GET /api/v1/competitions (primer corte vertical).
FIN
