# SlotEngine — Project Status

> Última actualización: 2026-11-27 (hora local America/Monterrey)
> Estado: Sprint 0 técnicamente completado
> Fuente de verdad del código: repositorio GitHub `Pacomsoft/slotengine`
> Fotografía confirmada tras integrar PR #14; verificar GitHub al retomar.

## 1. Resumen ejecutivo

SlotEngine es una plataforma SaaS multi-tenant y white-label para negocios de servicios.

Stack acordado:
- Frontend: Next.js 16, React, TypeScript, Tailwind CSS y shadcn/ui.
- Backend: ASP.NET Core Web API .NET 10 y OpenAPI.
- Persistencia objetivo: PostgreSQL y Entity Framework Core (EF Core todavía no integrado).
- Infraestructura local: Docker Compose con PostgreSQL 17.
- CI/CD: GitHub Actions (CI del frontend y backend operativos).

Se completaron el frontend, la API inicial, PostgreSQL local, las convenciones de configuración por ambiente y una primera integración entre frontend y backend mediante `GET /health`. La API todavía no se conecta a PostgreSQL; no existen autenticación ni aislamiento multi-tenant implementados.

## 2. Estado confirmado de Git

Repositorio: https://github.com/Pacomsoft/slotengine

Último commit confirmado de `main` al cierre:
`f33aa63` — Chore/slot 009 config onboarding (#16)

Estado local reportado por el usuario:
- Rama: `main`.
- Sincronizada con `origin/main` mediante `git pull --ff-only`.
- Working tree limpio tras integrar PR #14.

Este estado local corresponde al cierre reportado; volver a verificar antes de la próxima tarea.

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
| SLOT-005 | PostgreSQL 17 con Docker Compose y volumen persistente | PR #7, merge `5d0390e` |
| SLOT-006 | Plantillas y convenciones de configuración por ambiente | PR #8, merge `f9508f5` |
| SLOT-007 | Health check de API y visualización desde Next.js | PR #9, merge `d3e9f0b` |

| SLOT-008 | Backend CI, xUnit y política de SDK | PR #11 (`8fade66`), PR #12 (`b423b52`) |

Validaciones conocidas:
- Backend CI PR #12: SDK efectivo 10.0.404, restore/build/test en Release exitosos, 0 warnings y 0 errores, 2 pruebas aprobadas. Run: https://github.com/Pacomsoft/slotengine/actions/runs/45921659467
- Auditoría local NuGet directa y transitiva sin vulnerabilidades conocidas según fuentes consultadas.
- `global.json`: 10.0.404, latestFeature, allowPrerelease=false; workflow instala desde el archivo y verifica la versión mediante Bash.
- Pendiente: verificar la rama negativa del script si se requiere, y planificar protección de ramas.
- Frontend: `npm run lint` y `npm run build` exitosos durante SLOT-006; Frontend CI del PR #9 exitoso (run 45310094901).
- Backend: `dotnet build SlotEngine.slnx` exitoso con el workaround de workloads documentado.
- API: `GET /api/v1` y `GET /health` verificados localmente; `GET /health` devolvió HTTP 200 / `Healthy`.
- PostgreSQL: `docker compose config --quiet`, contenedor `healthy`, consulta SQL y persistencia tras reiniciar el contenedor verificadas localmente.
- Integración web/API: se mostraron los estados `Disponible` y `No Disponible` según disponibilidad de la API; se agregó `Suspense` por requerimientos de `cacheComponents`.
- La implementación de health checks actual es básica y no verifica PostgreSQL.

## Refinamiento metodológico (2026-11-27)

PR #13 (`bca50d1`) y #14 (`fb44bed`) integrados, confirmados mediante GitHub. Roadmap de aprendizaje y protocolo de evaluación disponibles en `docs/learning/`. Dirección hexagonal propuesta, pendiente ADR e implementación. No se modificó runtime en los ejercicios de esta sesión. Branch cleanup reportado: 12 ramas locales y 15 remotas eliminadas, main intacta. Verificación individual previa incompleta; no afirmar ausencia de commits únicos en todas las ramas. Perfil de competencias privado.

## 4. Pendientes del Sprint 0

- SLOT-009: completado mediante PR #16.

SLOT-008 completado técnicamente; ambos pipelines operativos. Sprint 0: 12 de 12 tareas integradas.

## 5. Próximo incremento

**Siguiente: refinamiento de Business Foundation y ADRs.**

Objetivo:
- Documentar requisitos y arranque desde cero de web, API y PostgreSQL.
- Incluir política de SDK, configuración local, validaciones y troubleshooting.
- Verificar la guía con una ejecución reproducible y sin secretos versionados.

Pendientes técnicos conocidos:
- La incidencia histórica de workloads no bloqueó build/test con SDK 10.0.404; reparación integral de workloads no verificada.
- Revisar la advertencia de redirección HTTPS al usar la API solo sobre HTTP local.
- Planificar integración real de PostgreSQL mediante EF Core en un incremento posterior.
- La URL de API usada por la web depende de `SLOTENGINE_API_URL`; al probar localmente deben coincidir sus puertos con los de la API.

## 6. Decisiones y convenciones vigentes

- Monorepo y monolito modular como arquitectura inicial.
- `main` como rama principal; ramas cortas por tarea.
- Conventional Commits, Pull Requests revisados y Squash and merge como estrategia habitual.
- Configuración y secretos locales fuera de Git; versionar únicamente plantillas sin credenciales.
- En Next.js, el estado de la API se consulta desde un Server Component, con timeout, manejo de error y `Suspense` para la petición dinámica.
- Un endpoint `/health` básico no prueba el estado de toda la infraestructura.
- No declarar tareas terminadas sin evidencia ni inventar implementaciones.

## 7. Protocolo de reanudación

Al comenzar una nueva sesión:
1. Consultar `instrucciones.md`.
2. Leer este archivo, `docs/ROADMAP.md` y `docs/ENGINEERING_LOG.md`.
3. Verificar los últimos commits y PRs integrados en GitHub.
4. Contrastar documentación y repositorio; informar discrepancias.
5. Confirmar el estado local de Git antes de crear una rama de trabajo.
6. Retomar SLOT-009 sin repetir tareas ya completadas.

Prioridad ante contradicciones:
- Código integrado: GitHub y Git.
- Decisiones y metodología: instrucciones rectoras y documentación.
- Plan vigente: este archivo y ROADMAP contrastados con GitHub.

## 8. Regla de cierre de sesión

Al terminar un incremento:
- Confirmar integraciones en `main`.
- Actualizar este documento, ENGINEERING_LOG y ROADMAP con evidencias.
- Identificar pendientes, riesgos y siguiente incremento.
- Indicar si los archivos adjuntos a ChatGPT requieren sincronización.

La documentación no reemplaza la verificación del repositorio.

## Cierre técnico Sprint 0 — 2026-11-27
SLOT-009 integrado en PR #16 (`f33aa63`); clonación local independiente, PostgreSQL aislado healthy, SDK 10.0.404, Node 24.14.0, npm ci, lint/build y backend Release 2/2 pruebas. API /health, /api/v1 y OpenAPI verificados; Next.js eligió 3007 por conflicto de puerto. La captura no identifica URL. npm audit y --omit=dev: 4 hallazgos moderados en cadena shadcn → ts-morph → @ts-morph/common → minimatch (GHSA-g3hv-75wg-m249); remediación pendiente antes de exposición pública. HTTPS y protección de ramas pendientes. No se verificó CI específico de PR #16 ni instalación en otra máquina.
Próximo: revisar dependencias, refinar HU-001, identidad, tenancy, ADR hexagonal y hosting antes de implementar. Diagnóstico inicial distribuido en prácticas breves.
