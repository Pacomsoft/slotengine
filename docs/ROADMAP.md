# SlotEngine — Roadmap y backlog inicial

> Estado: Sprint 0 técnicamente completado · Actualización: 2026-11-27

## Objetivo de aprendizaje
Construir, probar, versionar y desplegar una aplicación SaaS real, adquiriendo autonomía en frontend, backend, SQL, APIs, Git, pruebas, seguridad y CI/CD.

## Principios de entrega
- Versiones incrementales, no fechas arbitrarias.
- Cada hito deja una funcionalidad ejecutable y demostrable.
- Cada feature incluye criterios de aceptación, pruebas y documentación proporcional.
- No liberar cobros reales sin controles y conciliación.

## Fases
| Versión objetivo | Hito | Evidencia de terminado |
| --- | --- | --- |
| `v0.1.0-dev` | Fundación técnica | App y API levantan localmente; DB; repositorio; primer CI |
| `v0.1.x` | Registro de empresas | Usuario autenticado crea un negocio; obtiene rol Owner; aislamiento verificado |
| `v0.2` | Identidad y membresías | Google OIDC, roles por empresa, invitaciones y selección de negocio |
| `v0.3` | Personalización y servicios | Branding, catálogo, horarios y página pública básica |
| `v0.4` | Reservas | Citas, cliente, disponibilidad, estados y prevención de duplicaciones |
| `v0.5` | Cobros y rentabilidad | Cobros manuales, costos, contribución y sandbox de pagos |
| `v0.6` | Plataforma y operación SaaS | Panel global, métricas, auditoría, políticas y preparación comercial |

Las etiquetas de versión pueden cambiar después de definir un esquema formal de release.

## Sprint 0 — Preparar entorno y repositorio
**Meta:** tener un recorrido desde código local hasta integración continua.

- [X] SLOT-001 Verificar Git, Node.js, .NET SDK, Docker y editor.
- [X] SLOT-002 Crear repositorio GitHub y archivos base.
- [X] SLOT-003 Inicializar frontend Next.js + TypeScript.
- [x] SLOT-004 Inicializar ASP.NET Core Web API y OpenAPI.
- [x] SLOT-005 Configurar PostgreSQL local con Docker Compose.
- [x] SLOT-006 Configurar variables por ambiente y `.gitignore`.
- [x] SLOT-007 Agregar health check del backend y consumirlo desde web.
- [x] SLOT-008 Configurar CI: build, lint y tests iniciales.
- [x] SLOT-009 Documentar cómo ejecutar el proyecto desde cero.
- [x] SLOT-010 Configurar shadcn/ui y validar primer componente.
- [x] SLOT-011 Configurar CI del frontend con GitHub Actions.
- [x] SLOT-012 Establecer documentación de continuidad del proyecto.

**Notas de avance:**
- SLOT-004 integrado en PR #5 (`8caae70`).
- SLOT-005 integrado en PR #7 (`5d0390e`): PostgreSQL 17 local en Docker Compose.
- SLOT-006 integrado en PR #8 (`f9508f5`): plantillas de configuración y documentación de ambientes.
- SLOT-007 integrado en PR #9 (`d3e9f0b`): `GET /health` y consumo desde Next.js; Frontend CI en verde.
- SLOT-008 completado: PR #11 (`8fade66`) y PR #12 (`b423b52`); Backend CI con SDK 10.0.404 y dos pruebas de integración exitosas en Release.
- SLOT-009 integrado en PR #16 (`f33aa63`).
- Pendientes técnicos: verificar integralmente los workloads (no bloquean el build actual), configurar HTTPS adecuadamente y planificar protección de ramas.
- Próximo incremento: refinamiento de Business Foundation y ADRs.
- PR #13 y #14 integrados; consultar `learning/ENGINEERING_LEARNING_ROADMAP.md` y `learning/ASSESSMENT_PROTOCOL.md`.
- Tras SLOT-009: revisión/retrospectiva de Sprint 0 y diagnóstico de competencias; refinar ADR hexagonal y tenancy, dependencias de identidad y hosting antes de las primeras vertical slices.

**Definición de terminado:** un nuevo desarrollador puede seguir README para ejecutar web, API y DB; al hacer PR, el pipeline valida build y pruebas.

## Primeras historias funcionales

### HU-001 — Registrar negocio
**Como** usuario autenticado, **quiero** registrar una empresa **para** gestionar mis servicios de manera independiente.

**Criterios de aceptación:**
1. Solo un usuario autenticado puede crear empresas.
2. Se validan nombre, slug y zona horaria.
3. Slug único; error legible ante duplicidad.
4. Se crea `BusinessId` y membresía `Owner` en la misma transacción.
5. Se impide consultar o modificar datos de otra empresa.
6. Se audita la operación sin registrar datos sensibles innecesarios.

### HU-002 — Seleccionar empresa
**Como** usuario asociado a varias empresas, **quiero** seleccionar cuál administrar **para** trabajar en el contexto correcto.

### HU-003 — Personalizar empresa
**Como** Owner, **quiero** configurar datos comerciales, logo y colores **para** presentar mi propia marca.

### HU-004 — Administrar servicios
**Como** Owner, **quiero** definir servicios, duración y precio **para** ofrecerlos en agenda.

### HU-005 — Registrar cita
**Como** usuario autorizado, **quiero** agendar una cita sin conflictos de disponibilidad **para** asegurar la atención.

### HU-006 — Registrar cobro y costo
**Como** Owner, **quiero** registrar ingresos y costos directos **para** conocer contribución por servicio.

### HU-007 — Página pública de reservas
**Como** cliente final, **quiero** reservar en la página de una empresa **para** elegir servicio y horario.

### HU-008 — Pago de prueba
**Como** cliente final, **quiero** realizar un pago sandbox **para** confirmar el flujo de cobro de una reserva.

## Definition of Done (DoD)
Una HU está terminada cuando:
- Cumple criterios de aceptación y reglas de negocio.
- Tiene autorización y aislamiento tenant verificados donde aplique.
- Incluye pruebas proporcionales al riesgo.
- Código revisado en PR y CI en verde.
- Documentación/configuración actualizada si cambió el comportamiento.
- Se demuestra en ambiente definido y se registran limitaciones.

## Registro de pendientes
- Decidir licencia open source.
- Confirmar proveedores de hosting y costos.
- Seleccionar esquema de sesiones para web + API.
- Definir disponibilidad y restricciones de recursos para agenda.
- Revisar requisitos de pagos reales y privacidad en México antes de activar producción.

## Cierre Sprint 0
SLOT-009 integrado en PR #16 (`f33aa63`); clonación local independiente, PostgreSQL aislado healthy, SDK 10.0.404, Node 24.14.0, npm ci, lint/build y backend Release 2/2 pruebas. API /health, /api/v1 y OpenAPI verificados; Next.js eligió 3007 por conflicto de puerto. La captura no identifica URL. npm audit y --omit=dev: 4 hallazgos moderados en cadena shadcn → ts-morph → @ts-morph/common → minimatch (GHSA-g3hv-75wg-m249); remediación pendiente antes de exposición pública. HTTPS y protección de ramas pendientes. No se verificó CI específico de PR #16 ni instalación en otra máquina.
Pendiente: diagnóstico distribuido y refinamiento de HU-001; priorizar revisión de dependencias antes de staging.
