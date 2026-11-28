
# SlotEngine — Engineering Log

Registro cronológico de avances, decisiones técnicas, problemas y aprendizajes.

La fuente de verdad del código integrado es GitHub. Este documento conserva el contexto de ingeniería.

---

## 2026-11-22 — Sprint 0: Fundación del proyecto

### Entregables completados

**SLOT-001 — Entorno local**
- Se verificaron Git, Node.js, npm, .NET SDK y Docker.
- Se estableció el directorio local `C:\DEVS\slotengine`.

**SLOT-002 — Repositorio**
- Se creó `Pacomsoft/slotengine`.
- Se integró documentación inicial de producto, arquitectura, roadmap y contribución.
- Commit inicial: `04bb306`.

**SLOT-003 — Next.js**
- Se creó el frontend dentro de `apps/web`.
- Stack: Next.js 16.4.6, React, TypeScript, Tailwind CSS y ESLint.
- Se verificaron servidor local, lint y build.
- PR #1: https://github.com/Pacomsoft/slotengine/pull/1
- Merge: `05ef53f`.

**SLOT-010 — shadcn/ui**
- Se configuró shadcn/ui con estilo `base-maia`, Base UI y Hugeicons.
- Se agregó `Button` y una página sencilla de bienvenida.
- Se verificó visualmente el componente.
- Lint y build exitosos.
- PR #2: https://github.com/Pacomsoft/slotengine/pull/2
- Merge: `5c5b94d`.

**SLOT-011 — Frontend CI**
- Se creó `.github/workflows/frontend-ci.yml`.
- El workflow se ejecuta en PRs hacia main que cambian el frontend o el propio workflow.
- Ejecuta checkout, configuración de Node.js 24, npm ci, lint y build.
- La ejecución en GitHub Actions terminó exitosamente.
- PR #3: https://github.com/Pacomsoft/slotengine/pull/3
- Merge: `831d78b`.

### Decisiones técnicas

- Mantener monorepo con frontend en `apps/web`.
- Conservar `apps/web/AGENTS.md`, generado por Next.js.
- Usar ramas por tarea y Conventional Commits.
- Usar Squash and merge habitualmente.
- Validar cambios localmente antes de crear PRs.
- Automatizar validaciones gradualmente con GitHub Actions.

### Problemas y aprendizajes

- Se revisó cómo Git interpreta rutas relativas desde el directorio actual.
- Se aprendió la diferencia entre merge commit, squash y rebase.
- Se distinguieron lint, build y pruebas automatizadas.
- Se corrigieron errores de sintaxis en YAML durante la creación del workflow.
- Se comprobó que `git diff --check` no reemplaza la validación funcional.
- Se identificó una falla de continuidad entre conversaciones de ChatGPT: un chat retomó un estado antiguo sin verificar GitHub.

### Acción correctiva

Crear documentación persistente de continuidad:
- `docs/PROJECT_STATUS.md`.
- `docs/ENGINEERING_LOG.md`.
- Actualización de `docs/ROADMAP.md`.

### Siguiente incremento planificado

SLOT-004 — Inicializar ASP.NET Core Web API con OpenAPI.

---

## 2026-11-22 — SLOT-004: Primera API ASP.NET Core

### Cambios integrados
- Se creó `SlotEngine.slnx` y `src/SlotEngine.Api` con .NET 10 (SDK local 10.0.300).
- Se sustituyó el ejemplo meteorológico por `GET /api/v1`, que devuelve información básica de la API.
- OpenAPI habilitado en Development mediante `AddOpenApi` y `MapOpenApi`.
- Se actualizó `Microsoft.AspNetCore.OpenApi` a `10.0.15` tras advertencia NU1903 de una dependencia vulnerable.
- PR #5 integrado: https://github.com/Pacomsoft/slotengine/pull/5
- Commit en `main`: `8caae70` (squash merge).
- PR #4 de continuidad también integrado: `8034236`.

### Evidencia y validaciones
- `dotnet restore SlotEngine.slnx` y `dotnet build SlotEngine.slnx` exitosos sin warnings tras actualización.
- Auditoría NuGet sin vulnerabilidades conocidas según fuentes configuradas.
- `GET http://localhost:5080/api/v1` respondió correctamente.
- `/openapi/v1.json` documentó `GetApiInfo`.
- El usuario sincronizó `main` localmente hasta `8caae70`.

### Incidencias y decisiones
- Los manifiestos de workloads del SDK .NET 10 presentan incompatibilidad Emscripten 10.0.108 vs. Mono Toolchain que requiere 10.0.109. Los comandos `dotnet workload list` y `dotnet workload update` fallaron; se usó temporalmente `$env:MSBuildEnableWorkloadResolver = "false"` para compilar. Reparación definitiva pendiente.
- Al ejecutar solo HTTP en puerto 5080 apareció una advertencia de redirección HTTPS. Configuración adecuada pendiente antes de entornos posteriores.
- Se corrigió un commit local que inicialmente incluía solo la solución; mediante `git add` y `git commit --amend` se incluyó el backend.
- No se implementaron DB, autenticación ni aislamiento tenant en este incremento.

### Siguiente incremento
SLOT-005 — PostgreSQL con Docker Compose.

---

## 2026-11-23 — Cierre de SLOT-005, SLOT-006 y SLOT-007

### SLOT-005 — PostgreSQL local con Docker Compose
- Se integró `compose.yaml` con PostgreSQL 17, volumen `postgres_data`, health check y puerto publicado solamente en `127.0.0.1`.
- Se versionó `.env.example` sin contraseña y se corrigieron líneas erróneas en `.gitignore`.
- Validaciones locales: `docker compose config --quiet`; contenedor `healthy`; `SELECT 1`; creación e inserción en tabla de prueba; persistencia de datos tras reiniciar el contenedor.
- PR #7: https://github.com/Pacomsoft/slotengine/pull/7
- Merge en `main`: `5d0390e`.

### SLOT-006 — Configuración por ambiente
- Se añadió `apps/web/.env.example` con `SLOTENGINE_API_URL`, plantilla `src/SlotEngine.Api/appsettings.Development.example.json` y guía `docs/ENVIRONMENT.md`.
- Se corrigió `apps/web/.gitignore` para permitir plantillas mientras `.env.local` y `appsettings.Development.json` permanecen ignorados.
- Validaciones locales: `dotnet build` (con workaround de workloads), `GET /api/v1`, `npm run lint`, `npm run build`, exclusión de secretos y `git diff --cached --check`.
- PR #8: https://github.com/Pacomsoft/slotengine/pull/8
- Merge en `main`: `f9508f5`.

### SLOT-007 — Health check de API e integración web
- ASP.NET Core registra `AddHealthChecks()` y expone `GET /health` mediante `MapHealthChecks()`.
- Next.js consulta `SLOTENGINE_API_URL/health` desde un Server Component, con timeout de 3 segundos, `cache: "no-store"`, manejo de error y `Suspense` para contenido dinámico.
- Validaciones locales: build .NET con workaround; `GET /health` devolvió HTTP 200 y `Healthy`; la web mostró `Disponible` y `No Disponible` al encender/apagar la API.
- La primera implementación mostró un error de prerenderizado por `cacheComponents`; la versión integrada contiene `Suspense`. Frontend CI del PR #9 terminó con éxito: https://github.com/Pacomsoft/slotengine/actions/runs/45310094901
- PR #9: https://github.com/Pacomsoft/slotengine/pull/9
- Merge en `main`: `d3e9f0b`.
- El health check básico no comprueba el estado de PostgreSQL.

### Riesgos y decisiones de continuidad
- Workloads de .NET 10 desalineados: Emscripten 10.0.108 y Mono 10.0.109; `MSBuildEnableWorkloadResolver=false` es solo un workaround local, no una reparación.
- La API ejecutada por HTTP local emite advertencia al no tener un puerto HTTPS configurado.
- El servidor Next.js debe usar una URL de API coherente con el puerto local efectivo (se probaron 5000 y 5080 en distintos pasos).
- La CI del backend y las pruebas automatizadas iniciales quedan para SLOT-008.
- Las guías de arranque completo quedan para SLOT-009.

### Estado al cierre
- PR #7, #8 y #9 integrados en `main`.
- Último commit confirmado: `d3e9f0b`.
- Usuario reportó `main` sincronizada y working tree limpio.
- Próximo incremento: **SLOT-008 — Backend CI y pruebas iniciales**.

---

## 2026-11-26 — Cierre de SLOT-008: Backend CI y pruebas iniciales

- PR #11 integrado en `8fade66`: proyecto xUnit `tests/SlotEngine.Api.IntegrationTests` (net10.0), referencia a API y Mvc.Testing 10.0.15; pruebas GET /health y GET /api/v1 mediante WebApplicationFactory, cliente HTTPS en memoria y sin redirecciones automáticas. Se eliminó la prueba didáctica.
- Backend CI en Ubuntu: pull_request hacia main con filtros de rutas, permisos contents: read, restore, build Release sin restore y test Release sin build. PR #11 pasó 2 pruebas pero seleccionó SDK 11.0.100.
- PR #12 integrado en `b423b52`: global.json con SDK 10.0.404, latestFeature y allowPrerelease=false; setup-dotnet lee el archivo; filtro global.json y validación Bash de versión 10.0.*.
- Evidencia: validación local con SDK 10.0.404; CI PR #12 https://github.com/Pacomsoft/slotengine/actions/runs/45921659467/job/140253556213 confirmó SDK 10.0.404, ambos proyectos compilados en Release, 0 warnings, 0 errores y 2 pruebas exitosas. Auditoría local de dependencias directas y transitivas sin vulnerabilidades conocidas según fuentes consultadas.
- Decisiones: mantener SDK 10 con flexibilidad controlada de feature bands; separar restore/build/test; evitar duplicar configuración del SDK; pruebas de integración sin PostgreSQL ni servidor externo.
- Aprendizajes: AAA, assertions, async/await, IDisposable, JSON semántico, NuGet, staging de eliminaciones, Bash y códigos de salida. Un pipeline verde no garantiza todos los criterios si no se verifican explícitamente.
- Pendientes: la rama negativa del script no se ejecutó deliberadamente en CI; HTTPS de producción y health check de PostgreSQL siguen pendientes. La incidencia histórica de workloads no bloqueó el build actual, pero no se verificaron todos los workloads. Protección de ramas por planificar.
- Estado local reportado: main sincronizada y limpia; GitHub confirmó PR #12 integrado y HEAD `b423b52`. Próximo incremento: SLOT-009, documentación de ejecución local desde cero.

---

## 2026-11-27 — Refinamiento metodológico y mantenimiento Git (SLOT-008, seguimiento)

- PR #13 (`bca50d1`) y #14 (`fb44bed`) confirmados como integrados en GitHub. Se consultaron el protocolo de evaluación y el roadmap de aprendizaje en `docs/learning/`.
- Dirección propuesta: arquitectura hexagonal dentro del monolito modular, ADR pendiente; conservar stack y flujo Git. Integrar análisis, Enterprise Design Thinking, Scrum, release management y evaluación adaptativa.
- Ejercicios: commit/push/PR, amend, ignore vs untracking, referencias locales/remotas, squash y ascendencia, diff y branch cleanup.
- Evidencia de terminal: `git branch -r -d` eliminó solo la referencia local; fetch la recuperó. `git push origin --delete` eliminó realmente dos ramas. El resto se eliminó por interfaz GitHub, seguido de prune y eliminación local múltiple. HEAD final `fb44bed`, working tree limpio, solo main según salida de terminal.
- Riesgo: se omitió verificación preventiva individual de todas las ramas. No confundir diff vacío con prueba de historial; `--check` no comprueba equivalencia. Reforzar guardrails y verificar PR/head antes de borrar. No se ejecutaron builds ni tests de aplicación en esta sesión.
- Reporte público: [2026-11-27-SLOT-008-git-maintenance.html](learning/2026-11-27-SLOT-008-git-maintenance.html). Evaluación individual conservada aparte en perfil privado.
- Siguiente: SLOT-009 (onboarding reproducible), cierre Sprint 0 y diagnóstico inicial. Pendientes: ADR hexagonal/tenancy, protección de ramas, HTTPS, integración DB y staging.

---

## Convención para futuras entradas

Registrar:
- Fecha y tarea.
- Cambios integrados y evidencia (PR / commit).
- Validaciones ejecutadas.
- Decisiones y justificación.
- Problemas o riesgos.
- Siguiente paso.

No marcar trabajo como completado antes de su integración y verificación.

## 2026-11-27 — SLOT-009 y cierre técnico Sprint 0
SLOT-009 integrado en PR #16 (`f33aa63`); clonación local independiente, PostgreSQL aislado healthy, SDK 10.0.404, Node 24.14.0, npm ci, lint/build y backend Release 2/2 pruebas. API /health, /api/v1 y OpenAPI verificados; Next.js eligió 3007 por conflicto de puerto. La captura no identifica URL. npm audit y --omit=dev: 4 hallazgos moderados en cadena shadcn → ts-morph → @ts-morph/common → minimatch (GHSA-g3hv-75wg-m249); remediación pendiente antes de exposición pública. HTTPS y protección de ramas pendientes. No se verificó CI específico de PR #16 ni instalación en otra máquina.
Compose rechazó contraseña vacía y luego creó volumen independiente; teardown conservó ambos volúmenes. Se corrigió plantilla 5080 → 5140 sin alterar evidencia histórica. Retrospectiva: evitar repetición y bloqueos de estilo, asistencia IA proporcional, autonomía de ejecución y validación basada en evidencia. Reporte: [SLOT-009](learning/2026-11-27-SLOT-009.html).
