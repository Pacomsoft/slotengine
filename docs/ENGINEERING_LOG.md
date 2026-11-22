
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

## Convención para futuras entradas

Registrar:
- Fecha y tarea.
- Cambios integrados y evidencia (PR / commit).
- Validaciones ejecutadas.
- Decisiones y justificación.
- Problemas o riesgos.
- Siguiente paso.

No marcar trabajo como completado antes de su integración y verificación.
