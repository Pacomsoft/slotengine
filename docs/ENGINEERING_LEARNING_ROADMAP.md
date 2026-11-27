# SlotEngine — Engineering Learning Roadmap

Propuesta 2026-11-27. Complementa el roadmap de producto; no acredita competencias sin evidencia.

## Niveles de autonomía

1. Explicar: propósito, funcionamiento y límites.
2. Aplicar con orientación: resolver con pistas y documentación.
3. Aplicar autónomamente: diseñar, implementar y validar sin receta.
4. Defender y adaptar: comparar alternativas, diagnosticar fallos y revisar soluciones ajenas.

## Competencias y evidencia

| Área | Práctica vinculada al producto | Evidencia esperada |
|---|---|---|
| Discovery / Enterprise Design Thinking | Actores, as-is/to-be, hipótesis, Hills, playback, loop Observe-Reflect-Make | Problema validado o hipótesis explícita, mapa de experiencia y resultado esperado |
| Scrum y agilidad | Product Goal, Sprint Goal, refinement, planning, review, retrospective, adaptación | Backlog priorizado, incremento inspeccionable y acción de mejora |
| Análisis y pensamiento crítico | HU-001 y reservas: reglas, excepciones, invariantes, riesgos, NFR | Preguntas propias, modelos, tabla de decisiones, escenarios Given/When/Then |
| Arquitectura | Stack, monolito modular, hexagonal, límites, dependencias, ADR, alternativas | ADR defendido, diagrama y prueba de independencia del núcleo |
| Programación | C#, TypeScript, OOP, SOLID, DI, async, errores, refactorización | Código propio, diff y explicación de decisiones |
| Datos | SQL, EF Core, migraciones, transacciones, índices, concurrencia | Migración probada, consultas y pruebas de integridad |
| APIs e integración | REST, OpenAPI, contratos, OIDC, timeouts, idempotencia, webhooks | Contrato, pruebas de errores y aislamiento |
| Git colaborativo | GitHub Flow, Gitflow, trunk-based, conflictos, hotfix, revert, cherry-pick | Historial de laboratorio, PR y explicación de estrategia |
| Calidad | Unit, integration, E2E, contract, seguridad, regresión, performance según riesgo | Matriz riesgo/prueba, ejecución positiva y negativa |
| CI/CD y release | GitHub Actions; comparación conceptual Azure DevOps, artifacts, gates, ambientes, tags, approvals, smoke tests | Pipeline, release trazable y recuperación ensayada |
| Cloud y operación | Docker, hosting, IAM, secretos, redes, IaC si aporta valor, logs, métricas, backups, incidentes | ADR de hosting, despliegue staging, runbook y ejercicio de recuperación |
| Habilidades blandas | Preguntas a stakeholders, negociación, feedback, estimación, comunicación de riesgo e incidentes | Playback, explicación de trade-offs, revisión constructiva y comunicación de estado |

## Secuencia sugerida

- Fundación: cerrar SLOT-009, onboarding y retrospectiva; evaluar conocimientos ya practicados.
- Diseño y entrega inicial: analizar HU-001, aclarar dependencia de identidad, ADR hexagonal y tenancy, diseñar una primera vertical slice y sus pruebas. Introducir staging temprano tras decidir hosting.
- Identidad y empresas: seguridad, transacciones, contratos y pruebas de aislamiento.
- Catálogo y reservas: análisis de dominio, experiencia de usuario, concurrencia, performance e integración.
- Pagos: sandbox, webhooks, idempotencia, conciliación y gestión de riesgo.
- Operación: release controlado, monitoreo, backup/restore, incidentes, evolución y costos.

## Protocolo de laboratorio por módulo

1. Recibir problema sin solución predefinida; formular preguntas y objetivos.
2. Identificar actores, flujo, datos, invariantes, riesgos, alcance y alternativas.
3. Proponer diseño y criterios verificables; defenderlo en revisión técnica.
4. Implementar en rama propia con ayuda gradual; probar y diagnosticar.
5. Revisar PR y CI; entregar al ambiente adecuado con evidencia.
6. Realizar playback y retrospectiva; registrar nivel de autonomía y brechas.

No inventar usuarios consultados, aprobaciones de terceros ni resultados de pruebas. El agente simula responsabilidades de equipo, no sustituye colaboración humana real.

## Evaluación y adaptación

Aplicar `ASSESSMENT_PROTOCOL.md` y registrar el progreso individual en `PRACTITIONER_PROFILE.md`. Los niveles 1–4 anteriores se conservan; L0 significa sin evidencia suficiente, no incompetencia. Evaluar subcompetencias concretas, no inferir dominio de un área completa por una sola tarea. Incorporar diagnóstico de Sprint 0, observación continua, evaluaciones de cierre de módulo y transferencia diferida. El agente elige los ejercicios de refuerzo según evidencia, sin alterar unilateralmente prioridades de producto.
