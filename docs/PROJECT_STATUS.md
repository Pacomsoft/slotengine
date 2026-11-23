
# SlotEngine — Project Status

> Última actualización: 2026-11-22
> Estado: Sprint 0 en progreso
> Fuente de verdad: repositorio GitHub `Pacomsoft/slotengine`
> Este documento describe el estado confirmado tras integrar PR #5.

## 1. Resumen ejecutivo

SlotEngine es una plataforma SaaS multi-tenant y white-label para negocios de servicios.

Stack acordado:
- Frontend: Next.js, React, TypeScript, Tailwind CSS y shadcn/ui.
- Backend objetivo: ASP.NET Core Web API y C#.
- Persistencia objetivo: PostgreSQL y Entity Framework Core.
- Infraestructura local: Docker Compose.
- CI/CD: GitHub Actions.

Se completaron el frontend con su pipeline de CI y la API inicial en ASP.NET Core .NET 10, con OpenAPI. Aún no existe una base de datos PostgreSQL configurada para el proyecto.

## 2. Estado confirmado de Git

Repositorio: https://github.com/Pacomsoft/slotengine

Último commit confirmado de main al cierre de sesión:
`8caae70` — feat(api): initialize ASP.NET Core Web API (#5)

Estado local reportado al cierre:
- Rama: `main`.
- Sincronizada con `origin/main` mediante `git pull --ff-only`.
- No se presentó una nueva salida de `git status` después de la sincronización.

Verificar nuevamente al iniciar otra sesión: estos datos representan una fotografía del 2026-11-22.

## 3. Trabajo completado

| ID | Entregable | Evidencia |
| --- | --- | --- |
| SLOT-001 | Herramientas locales verificadas | Git, Node.js, npm, .NET SDK y Docker |
| SLOT-002 | Repositorio y documentación inicial | Commit `04bb306` |
| SLOT-003 | Frontend Next.js inicializado | PR #1, merge `05ef53f` |
| SLOT-010 | shadcn/ui, Button y pantalla de prueba | PR #2, merge `5c5b94d` |
| SLOT-011 | CI del frontend con GitHub Actions | PR #3, merge `831d78b` |
| SLOT-012 | Documentación de continuidad | PR #4, merge `8034236` |
| SLOT-004 | ASP.NET Core Web API .NET 10 y OpenAPI | PR #5, merge `8caae70` |

Validaciones conocidas:
- Frontend: `npm run lint` exitoso.
- Frontend: `npm run build` exitoso.
- Componente Button visualizado localmente.
- GitHub Actions: workflow Frontend CI ejecutado exitosamente en PR #3.
- Backend: restore y build locales exitosos, auditoría NuGet sin vulnerabilidades detectadas.
- Backend: `GET /api/v1` y OpenAPI `/openapi/v1.json` verificados localmente.

Ejecución CI:
https://github.com/Pacomsoft/slotengine/actions/runs/45078662471

## 4. Pendientes del Sprint 0

- SLOT-005: configurar PostgreSQL con Docker Compose.
- SLOT-006: completar y revisar configuración por ambiente.
- SLOT-007: health check del backend y consumo desde web.
- SLOT-008: ampliar CI para backend y pruebas iniciales.
- SLOT-009: documentar ejecución completa desde cero.

El frontend cuenta con CI, pero esto no significa que SLOT-008 esté totalmente terminado.

## 5. Próximo incremento

**SLOT-005 — PostgreSQL local con Docker Compose.**

Objetivo:
- Definir una configuración local de PostgreSQL en Docker Compose.
- Evitar credenciales reales en Git.
- Verificar arranque, conexión y persistencia local.

Pendientes técnicos heredados de SLOT-004:
- Reparar la incompatibilidad de manifiestos workloads de .NET 10. El build local se validó con `MSBuildEnableWorkloadResolver=false` establecido temporalmente.
- Resolver la configuración de redirección HTTPS para ambientes posteriores.
- El CI de backend se agregará en SLOT-008.

## 6. Decisiones y convenciones vigentes

- Monorepo y monolito modular como arquitectura inicial.
- `main` como rama principal.
- Ramas cortas por tarea.
- Conventional Commits.
- Pull Requests con revisión y validación.
- Squash and merge como estrategia habitual.
- No declarar una tarea terminada sin evidencia.
- No inventar archivos, endpoints o implementaciones.

## 7. Protocolo de reanudación

Al comenzar una sesión nueva, el Engineering Agent debe:

1. Consultar `instrucciones.md`.
2. Leer este archivo y `docs/ROADMAP.md`.
3. Consultar `docs/ENGINEERING_LOG.md` para conocer decisiones recientes.
4. Verificar en GitHub los últimos commits y PRs integrados.
5. Contrastar la documentación con el estado real del repositorio.
6. Si existe una diferencia, explicarla antes de proponer comandos.
7. Retomar la siguiente tarea pendiente, sin repetir trabajo terminado.

Prioridad ante contradicciones:
- Para saber qué código está integrado: verificar GitHub y Git.
- Para decisiones y metodología: consultar la documentación rectora.
- Para el plan vigente: consultar este archivo y ROADMAP, contrastándolos con GitHub.

No asumir que el último fragmento de conversación disponible representa el estado actual.

## 8. Regla de cierre de sesión

Después de un incremento importante:
- Actualizar este documento.
- Registrar los cambios y decisiones relevantes en ENGINEERING_LOG.
- Actualizar ROADMAP si cambió el estado de alguna tarea.
- Referenciar PRs y commits como evidencia.
- Definir el siguiente incremento.

La documentación no reemplaza la verificación del repositorio.
