# SlotEngine — Product Definition

> Estado: propuesta inicial v0.1 · Fecha: 2026-11-22 · Responsable de producto: fundador de SlotEngine

## 1. Visión
SlotEngine es una plataforma SaaS multiempresa (*multi-tenant*) y personalizable (*white-label-ready*) para personas y negocios que venden servicios. Integra gestión de reservas, clientes, colaboradores, cobros, costos y métricas de rentabilidad en una sola herramienta.

**Promesa de valor:** que el negocio controle su operación y entienda cuánto gana realmente por cada servicio, sin depender de herramientas inconexas.

## 2. Modelo de producto
- **Plataforma:** el operador de SlotEngine administra registro de empresas, operación de la plataforma, planes (futuro), soporte y estado del servicio.
- **Empresa / tenant:** cada negocio crea su propio espacio y configura marca, servicios, horarios, personal, clientes y finanzas.
- **Portal del cliente:** cada empresa publica una página de reservas identificada inicialmente mediante un slug de SlotEngine. Los dominios personalizados son una evolución posterior.
- **Distribución:** núcleo de código abierto, con instalación propia como objetivo; hosting SaaS administrado como una opción comercial futura. La licencia final queda pendiente de decisión.

## 3. Usuarios y permisos
| Actor | Necesidad principal | Alcance |
| --- | --- | --- |
| Platform Admin | Operar la plataforma | Gestión global con controles de privacidad y auditoría |
| Business Owner | Administrar su negocio | Configuración, personal, reservas, finanzas |
| Business Staff | Atender citas | Solo funciones autorizadas de su empresa |
| Customer | Reservar servicios | Sus propias reservas y datos |

Una cuenta puede pertenecer a varias empresas con distintos roles. La pertenencia a la empresa se modela explícitamente; no se determina por el rol global del usuario.

## 4. Capacidades del producto
1. Registro y creación de empresas.
2. Identidad, inicio de sesión con Google y autorización por empresa.
3. Personalización inicial: logotipo, colores, datos comerciales y slug público.
4. Servicios: nombre, categoría, duración, precio y costos estimados.
5. Agenda: disponibilidad, citas, bloqueos, cancelaciones y reasignaciones.
6. Clientes: perfiles e historial de atenciones.
7. Cobros y finanzas: ingresos, anticipos, pagos parciales, costos, gastos y contribución.
8. Tablero de indicadores: ocupación, facturación, contribución y tendencias.
9. Integraciones: Google Calendar y pasarelas de pago, por etapas.
10. Administración de plataforma: estado de empresas, métricas agregadas, planes y límites, posteriormente.

## 5. Flujo mínimo de valor (MVP funcional)
1. Usuario inicia sesión y crea empresa.
2. Configura horarios y registra un servicio.
3. Registra un cliente y agenda una cita.
4. Completa la cita.
5. Registra el cobro y los costos directos.
6. Consulta ingresos y contribución por servicio.

**Nota:** el primer incremento de ingeniería (v0.1) implementa solo una parte de este flujo. El MVP funcional completo se alcanza por entregas sucesivas.

## 6. Reglas de negocio iniciales
- Los datos de una empresa están aislados de los de cualquier otra.
- Crear empresa también asigna el rol Owner al usuario creador dentro de una transacción.
- El slug público de una empresa debe ser único y validado.
- Una cita tiene empresa, servicio, cliente, inicio, fin, zona horaria de referencia y estado.
- Para recursos que no admitan simultaneidad, no deben confirmarse citas solapadas.
- Los cobros tienen estados verificables y no se consideran exitosos solo por una redirección del navegador.
- La **contribución** es ingreso reconocido menos costos directos; la **utilidad neta** requiere considerar también gastos indirectos, impuestos y otros ajustes según reglas definidas.
- Configuraciones por empresa no sustituyen permisos de autorización en el backend.

## 7. Alcance y no-alcance inicial
**Sí:** app web responsiva, API REST, datos persistentes, flujo de reservas, registro manual de pagos, costos y reportes básicos, autenticación real, controles de seguridad y pruebas.

**Después:** aplicaciones móviles nativas, dominios personalizados, facturación fiscal, suscripciones comerciales, pagos distribuidos a terceros, recordatorios por SMS/WhatsApp, integraciones POS, AI avanzada, multiidioma, motores complejos de comisiones.

## 8. Métricas de éxito
- Activación: porcentaje de empresas que completan configuración y publican al menos un servicio.
- Primera experiencia: tiempo entre registro y primera cita.
- Operación: citas completadas / programadas y cancelaciones.
- Uso financiero: porcentaje de citas completadas con cobro y costo registrados.
- Salud técnica: tasa de errores, pruebas, tiempo de respuesta y despliegues exitosos.

No fijar objetivos numéricos hasta contar con una línea base.

## 9. Preguntas pendientes
- Licencia open source final (evaluar MIT, Apache-2.0 y AGPL según objetivos).
- Políticas comerciales, fiscales y de privacidad por mercado.
- Modelo de reservas simultáneas y recursos asociados.
- Proveedor y estrategia de cobro a negocios vs. cobro a clientes finales.
- Catálogo de planes y límites comerciales.

## 10. Criterio de prioridad
Priorizar primero un flujo completo, usable, seguro, probado y desplegable. Evitar construir módulos avanzados antes de validar la experiencia principal.
