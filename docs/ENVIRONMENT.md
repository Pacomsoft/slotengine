# SlotEngine — Environment Configuration

## 1. Overview

SlotEngine separates application code from environment-specific configuration.

The initial environments are:

- **Development:** local workstation, Docker Compose and local configuration.
- **Staging:** future integration and validation environment using synthetic data.
- **Production:** future deployment with managed secrets, HTTPS and operational monitoring.

Only the local development environment is currently implemented.

## 2. Frontend — Next.js

Location: `apps/web`

| File | Purpose | Versioned |
| --- | --- | --- |
| `.env.example` | Example configuration | Yes |
| `.env.local` | Local development configuration | No |

To initialize local configuration:

```powershell
Copy-Item apps/web/.env.example apps/web/.env.local
```

Available variable:

- `SLOTENGINE_API_URL`: backend API address: `http://localhost:5140`.

The frontend uses this variable to perform server-side health checks against the backend API, which listens on port 5140 by default when using the HTTP launch profile.

Do not add `NEXT_PUBLIC_` to sensitive configuration. Variables with that prefix can be exposed to browser code.

## 3. Backend — ASP.NET Core

Location: `src/SlotEngine.Api`

| File | Purpose | Versioned |
| --- | --- | --- |
| `appsettings.json` | Shared application configuration | Yes |
| `appsettings.Development.example.json` | Development configuration template | Yes |
| `appsettings.Development.json` | Local Development overrides | No |

Initialize local configuration:

```powershell
Copy-Item src/SlotEngine.Api/appsettings.Development.example.json src/SlotEngine.Api/appsettings.Development.json
```

For local development, set `ASPNETCORE_ENVIRONMENT=Development`.

ASP.NET Core loads environment-specific configuration automatically when the corresponding file exists.

The API does not yet use a PostgreSQL connection string.

## 4. Database — PostgreSQL

Location: repository root.

| File | Purpose | Versioned |
| --- | --- | --- |
| `compose.yaml` | Local PostgreSQL service definition | Yes |
| `.env.example` | PostgreSQL variable names and example values | Yes |
| `.env` | Local PostgreSQL configuration and credentials | No |

Required variables:

- `POSTGRES_USER`
- `POSTGRES_PASSWORD`
- `POSTGRES_DB`
- `POSTGRES_PORT`

Initialize configuration:

```powershell
Copy-Item .env.example .env
```

Set a strong local password before starting Docker Compose.

Start PostgreSQL:

```powershell
docker compose up -d
```

Validate configuration without printing expanded secrets:

```powershell
docker compose config --quiet
```

Never commit `.env` or disclose credentials in logs, screenshots or Pull Requests.

## 5. Security rules

- Do not store production secrets in source control.
- Example files must not contain real credentials.
- Keep database ports bound to localhost during local development.
- Use managed secret storage for future deployed environments.
- Do not assume that frontend environment variables are private when exposed to browser code.
- Do not use development credentials in production.

## 6. Known limitations

- The local .NET 10 SDK has a workload manifest compatibility issue. Builds have been validated using `MSBuildEnableWorkloadResolver=false` as a temporary workaround.
- HTTPS redirection requires appropriate configuration for the target environment.
- Backend CI and automated configuration tests are pending.
- Staging and production infrastructure are not yet implemented.

## 7. Future work

- SLOT-007: completed — basic API health check and frontend integration.
- SLOT-008: completed — backend CI and initial integration tests.
- SLOT-009: completed — see [README](../README.md).
- Future functional increments: database persistence and migrations with Entity Framework Core.

## Local validation notes
Next.js may choose another port if 3000 is occupied; use the URL printed by the dev server. The HTTP launch profile uses port 5140 and may log an HTTPS redirection warning. Backend health does not check PostgreSQL. For isolated labs, use a distinct Compose project name (`-p`) and host port, preserving named volumes.
