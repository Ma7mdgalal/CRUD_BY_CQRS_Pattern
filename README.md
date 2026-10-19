# Todo API - CQRS with .NET

A small ASP.NET Core Web API for managing todo items. It uses CQRS to keep read and write operations separate, MediatR to dispatch requests, FluentValidation for request validation, and Entity Framework Core with SQL Server for persistence.

## What it demonstrates

- A layered solution separating the API, application logic, domain model, and persistence.
- CQRS commands for creating, updating, and deleting todos, and queries for listing and retrieving them.
- MediatR pipeline validation with FluentValidation.
- EF Core persistence and a SQL Server migration.
- Centralized HTTP error responses using `ProblemDetails`.

## Solution structure

| Project | Responsibility |
| --- | --- |
| `Api` | ASP.NET Core controllers, request models, dependency injection, and exception handling |
| `Application` | CQRS requests and handlers, validators, and the database-context abstraction |
| `Domain` | The `Todo` domain entity |
| `Infrastructure` | EF Core `DbContext`, entity configuration, and database migrations |

Requests flow from `TodosController` through MediatR to an application handler. The handler uses `IAppDbContext`; the API registers the EF Core implementation from `Infrastructure`.

## Requirements

- .NET 10 SDK
- SQL Server (local or remote)
- The `dotnet-ef` tool, version 10, to apply the included migration

## Configure and run

1. Clone the repository and open a terminal in its root directory.
2. Set the SQL Server connection string in the current PowerShell session. Replace the server value with your SQL Server instance:

   ```powershell
   $env:ConnectionStrings__Default = "Server=localhost;Database=Todos;Trusted_Connection=True;TrustServerCertificate=True"
   ```

   Keep the connection string in your local environment or secret store rather than committing machine-specific settings.

3. Install the EF Core CLI tool if it is not already installed:

   ```powershell
   dotnet tool install --global dotnet-ef --version 10.0.11
   ```

4. Create or update the database using the included migration:

   ```powershell
   dotnet ef database update --project Infrastructure --startup-project Api
   ```

5. Run the API:

   ```powershell
   dotnet run --project Api
   ```

   The included HTTPS launch profile uses `https://localhost:7020`. You can exercise the endpoints with the repository's [`request.http`](./request.http) file in VS Code.

To build the solution:

```powershell
dotnet build TodoCQRS.slnx
```

## API

All routes are under `/api/todos`.

| Method | Route | Purpose | Success response |
| --- | --- | --- | --- |
| `GET` | `/api/todos` | List todos | `200 OK` with an array (empty when there are no todos) |
| `GET` | `/api/todos/{todoId}` | Retrieve a todo | `200 OK` |
| `POST` | `/api/todos` | Create a todo | `201 Created` |
| `PUT` | `/api/todos` | Update a todo; provide its ID in the request body | `204 No Content` |
| `DELETE` | `/api/todos/{todoId}` | Delete a todo | `204 No Content` |

Create request:

```json
{
  "title": "Buy groceries"
}
```

Update request:

```json
{
  "id": "d7ea2d05-9c79-444f-8413-08df06132d16",
  "title": "Buy groceries",
  "completed": true
}
```

Validation failures return `400 Bad Request`; requests for a todo that does not exist return `404 Not Found`. Error responses use `ProblemDetails`.
