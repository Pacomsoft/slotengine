# SlotEngine

A multi-tenant SaaS platform for service businesses, currently under active development with an open-source distribution goal.

## Overview

SlotEngine aims to help independent professionals and service businesses manage appointments, customers, payments, expenses, and profitability.

The project is currently in its technical foundation stage.

## Technology Stack

- Frontend: Next.js, React and TypeScript.
- Backend: ASP.NET Core and C#.
- Database: PostgreSQL 17.
- Containers: Docker and Docker Compose.
- CI/CD: GitHub Actions.

## Repository Structure

- `apps/web/` — Next.js web application.
- `src/SlotEngine.Api/` — ASP.NET Core Web API.
- `tests/` — Integration tests.
- `compose.yaml` — Local PostgreSQL service configuration.
- `docs/` — Architecture and development documentation.
- `.github/workflows/` — Automated build and validation pipelines.
- `SlotEngine.slnx` — .NET solution file.
- `global.json` — .NET SDK version selection policy.

## Prerequisites

- Git.
- Docker Engine or Docker Desktop with Docker Compose.
- Node.js 24 and npm.
- .NET SDK 10.0.404, following the SDK selection policy defined in `global.json`.

PostgreSQL is provided through Docker Compose and does not require a separate local installation.

The following instructions use PowerShell.

## Getting Started

### 1. Clone the repository

```powershell
git clone https://github.com/Pacomsoft/slotengine
cd slotengine
```

### 2. Verify the development tools

```powershell
git --version
node --version
npm --version
dotnet --version
docker --version
docker compose version
```

### 3. Prepare local configuration

From the repository root, copy the configuration templates:

```powershell
Copy-Item .env.example .env
Copy-Item apps/web/.env.example apps/web/.env.local
Copy-Item src/SlotEngine.Api/appsettings.Development.example.json src/SlotEngine.Api/appsettings.Development.json
```

Only copy these templates when initializing a new environment. Do not overwrite existing local configuration unnecessarily.

Set a strong local PostgreSQL password in the root `.env` file.

Example configuration:

```dotenv
POSTGRES_USER=slotengine
POSTGRES_PASSWORD=<your-local-password>
POSTGRES_DB=slotengine_dev
POSTGRES_PORT=5432
```

Replace the password placeholder with your own local password.

The frontend configuration in `apps/web/.env.local` should contain:

```dotenv
SLOTENGINE_API_URL=http://localhost:5140
```

The backend development configuration can initially use the values provided by its example file.

Never commit local configuration files containing credentials.

See [Environment Configuration](docs/ENVIRONMENT.md) for additional details.

## Running Locally

Docker Compose currently manages PostgreSQL only. The frontend and backend run as separate local processes.

### Terminal 1 — PostgreSQL

From the repository root, ensure Docker is running and execute:

```powershell
docker compose config --quiet
docker compose up -d
docker compose ps
```

Verify that the PostgreSQL container reaches the healthy state.

### Terminal 2 — Backend

Open a separate terminal at the repository root:

```powershell
dotnet restore SlotEngine.slnx
dotnet run --project src/SlotEngine.Api --launch-profile http
```

The backend should listen on:

`http://localhost:5140`

### Terminal 3 — Frontend

Open another terminal at the repository root:

```powershell
cd apps/web
npm ci
npm run dev
```

Open `http://localhost:3000` in your browser.

The frontend should display the backend API as available when the API is running and the URL is configured correctly.

## Service Endpoints

| Service | Default address |
|---|---|
| Web application | `http://localhost:3000` |
| Backend API | `http://localhost:5140` |
| Health endpoint | `http://localhost:5140/health` |
| API information | `http://localhost:5140/api/v1` |
| OpenAPI document | `http://localhost:5140/openapi/v1.json` |
| PostgreSQL | `127.0.0.1:5432` |

The OpenAPI document is available in the Development environment.

The current API health check does not validate PostgreSQL connectivity.

## Build and Validation

### Frontend

From the repository root, open a separate terminal:

```powershell
cd apps/web
npm ci
npm run lint
npm run build
```

Stop any running frontend development process before building.

### Backend

From the repository root:

```powershell
dotnet restore SlotEngine.slnx
dotnet build SlotEngine.slnx --no-restore --configuration Release
dotnet test SlotEngine.slnx --no-build --configuration Release
```

GitHub Actions validates applicable changes through the frontend and backend CI workflows.

## Stopping the Environment

Stop the frontend and backend processes using `Ctrl+C` in their respective terminals.

From the repository root, stop PostgreSQL:

```powershell
docker compose stop
```

Alternatively, remove the PostgreSQL container and project network while preserving the named database volume:

```powershell
docker compose down
```

Do not remove database volumes unless data deletion is explicitly intended.

## Troubleshooting

- **Docker is unavailable:** Verify that Docker Engine or Docker Desktop is running.
- **PostgreSQL fails to start:** Check the required environment variables and run `docker compose config --quiet`.
- **PostgreSQL remains unhealthy:** Inspect the container using `docker compose ps` and `docker compose logs postgres`.
- **Backend API unavailable:** Verify the API startup logs and test the `/health` endpoint directly.
- **Frontend cannot reach the backend:** Verify that `SLOTENGINE_API_URL` matches the actual backend listening address.
- **Ports already in use:** Identify the conflicting process before stopping it or changing the relevant configuration.
- **.NET SDK or workload errors:** Verify the installed SDK against `global.json` and review the known limitations in the environment documentation.

## Current Limitations

- The backend is not yet connected to PostgreSQL.
- Authentication and tenant isolation are not yet implemented.
- The API health check only validates basic API availability.
- Staging and production environments are not yet implemented.

## Documentation

- [Product Definition](docs/PRODUCT.md)
- [Architecture](docs/ARCHITECTURE.md)
- [Environment Configuration](docs/ENVIRONMENT.md)
- [Roadmap](docs/ROADMAP.md)
- [Contributing Guide](docs/CONTRIBUTING.md)
- [Project Status](docs/PROJECT_STATUS.md)
- [Engineering Log](docs/ENGINEERING_LOG.md)

## Contributing

Follow the repository conventions and contribution workflow described in [CONTRIBUTING.md](docs/CONTRIBUTING.md).

## License

License selection is pending. A LICENSE file will be added before accepting external contributions.