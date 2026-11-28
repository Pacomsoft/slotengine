# Contribuir a SlotEngine

SlotEngine es un proyecto de aprendizaje aplicado y una base de producto open source. Buscamos cambios pequeños, legibles, verificables y seguros.

> Estado: guía inicial. Actualizar comandos y rutas cuando el repositorio esté inicializado.

## 1. Antes de contribuir
1. Lee `PRODUCT.md`, `ARCHITECTURE.md` y `ROADMAP.md`.
2. Revisa issues existentes y los criterios de aceptación.
3. Para cambios arquitectónicos relevantes, discute y documenta un ADR.
4. No subas información, código ni configuraciones privadas de empleadores o clientes.

## 2. Flujo de trabajo Git
Trabajaremos con ramas cortas desde `main`:

```bash
git checkout main
git pull --ff-only
git checkout -b feat/SLOT-001-bootstrap
```

Realiza commits pequeños y relacionados. Abre un Pull Request con descripción del cambio, pruebas y evidencia.

## 3. Nombres de ramas
- `feat/SLOT-123-descripcion`
- `fix/SLOT-123-descripcion`
- `docs/SLOT-123-descripcion`
- `chore/SLOT-123-descripcion`

Los números son identificadores del backlog. Se utilizarán issues GitHub cuando estén creados.

## 4. Conventional Commits
Formato:

```text
<tipo>(alcance opcional): descripción en imperativo
```

Ejemplos:
```text
feat(businesses): add business registration endpoint
fix(appointments): prevent overlapping reservations
test(auth): cover tenant membership authorization
docs: explain local environment setup
chore(ci): add backend test workflow
```

Tipos habituales: `feat`, `fix`, `docs`, `test`, `refactor`, `chore`, `ci`, `build`, `perf`.

## 5. Pull Request
Incluir:
- **Qué cambia:** resumen funcional y técnico.
- **Por qué:** HU/issue asociado.
- **Cómo se probó:** comandos y resultados.
- **Impactos:** migraciones, configuración, API, seguridad.
- **Evidencia:** capturas o ejemplos cuando corresponda.
- **Checklist:** tests, lint, revisión de secretos, autorización de tenant.

No hacer merge de un PR con CI fallando sin justificar y documentar la excepción.

## 6. Estilo de código
- Preferir nombres claros, métodos pequeños y responsabilidades bien delimitadas.
- Respetar herramientas de formato y lint configuradas.
- Documentar decisiones complejas, no repetir el código en comentarios.
- Evitar dependencias innecesarias y abstracciones prematuras.
- Tratar warnings, errores y casos extremos como trabajo real.

## 7. Pruebas
- Añadir pruebas para reglas de negocio y correcciones de bugs.
- Probar autorizaciones y aislamiento por empresa en endpoints relevantes.
- Usar datos sintéticos; nunca información personal real en fixtures o logs.
- No fingir pruebas ejecutadas: declarar cuándo no se pudieron ejecutar.

## 8. Seguridad y secretos
- Nunca commitear archivos `.env` con credenciales reales, tokens o claves privadas.
- Publicar solo `.env.example` con variables vacías o valores de demostración no sensibles.
- Reportar vulnerabilidades de forma privada por un canal de seguridad que se definirá antes de abrir contribuciones externas.
- No registrar contraseñas, tokens ni datos financieros sensibles.
- No aceptar `BusinessId` sin verificar permisos del usuario.

## 9. Base de datos y migraciones
- Versionar migraciones con el código que las requiere.
- Evitar cambios destructivos sin plan de migración y reversión.
- Probar migraciones con una base de datos de prueba antes de producción.

## 10. Desarrollo local
Los comandos exactos de instalación y ejecución se publicarán en `README.md` al completar Sprint 0. No asumir que la estructura ya existe.

## 11. Licencia
**Pendiente de selección.** Antes de aceptar contribuciones externas se elegirá una licencia y se añadirán `LICENSE` y, si hace falta, normas adicionales de contribución.

## 12. Código de conducta
Tratar a colaboradores con respeto, dar feedback técnico específico y mantener discusiones orientadas a hechos. Una política formal `CODE_OF_CONDUCT.md` se añadirá antes de abrir la colaboración pública a terceros.

## 13. Colaboración y entrega profesional (propuesta)

- Refinar problemas y criterios antes de implementar; explicitar dudas y dependencias.
- PR: distinguir bloqueantes, sugerencias y preguntas; autor responde con evidencia. Revisiones simuladas no equivalen a aprobación independiente.
- Mantener ramas cortas; practicar Gitflow, hotfix y conflictos en ramas de laboratorio sin afectar main.
- Antes de liberar: identificar versión y artefacto, ambiente, checks, impacto de datos, responsable, comunicación, smoke tests y estrategia de recuperación. Los controles se introducen según riesgo.
- Revisar resultados en playback/review y adaptar el proceso en retrospectiva.
- Al cierre elaborar reporte HTML según instrucciones rectoras y registrar evidencia de aprendizaje.

## 14. Evaluación del aprendizaje

- Distinguir evidencia técnica del producto y evidencia de competencia individual.
- Aplicar evaluación adaptativa según el protocolo rector, con prácticas de análisis, debugging, código y comunicación.
- Conservar el perfil y respuestas individuales en fuentes privadas; no versionarlos en el repositorio público sin consentimiento específico. Los reportes de aprendizaje públicos se limitan a contenido técnico no personal.

## Retrospectiva Sprint 0 — aprendizaje asistido por IA
Explicar, permitir ejecución autónoma, revisar, corregir o asistir y avanzar. No bloquear por estilo o redacción salvo impacto funcional, seguridad o exactitud. Escalar asistencia cuando la repetición no aporte aprendizaje; generar documentación extensa con IA y verificar contra evidencia. Evaluación breve y espaciada durante tareas reales; diagnóstico inicial distribuido. Mantener controles esenciales y distinguir asistencia de autonomía.
