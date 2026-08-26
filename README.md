# Inambu Manufacturing

Inambu Manufacturing is an ASP.NET Core Blazor application for capturing and reviewing quality-control measurements from production lines.

## Features

- User registration, login, and account management through ASP.NET Core Identity.
- Capture temperature, humidity, weight, width, length, and depth measurements.
- Mark measurements as passed or failed.
- View measurement statistics and captured measurements.
- Edit or delete measurements created by the signed-in user.
- Seed three production lines through Entity Framework Core migrations.

## Requirements

- .NET 9 SDK
- A database server supported by the configured Entity Framework Core provider
- For the current project configuration: Microsoft SQL Server

Check the installed .NET SDK with:

```bash
dotnet --version
```

## Clone and run

```bash
git clone https://github.com/Chimoneg27/Inambu-Manufacturing-Pty.git
cd Inambu-Manufacturing-Pty
dotnet restore
dotnet ef database update
dotnet run
```

The development launch profiles use these URLs by default:

- HTTP: <http://localhost:5261>
- HTTPS: <https://localhost:7213>

Your ports may differ if the launch settings or another application already uses those ports. The terminal output from `dotnet run` shows the URLs that are actually available.

## Database configuration

The application reads the `DefaultConnection` value from the `ConnectionStrings` section and configures Entity Framework Core with the SQL Server provider in `Program.cs`.

Each developer must use their own database host, port, database name, and credentials. `localhost,1433` is only an example of a SQL Server running locally on the default TCP port. A remote server, Docker container, named instance, or another local port will need a different connection string.

### SQL Server with SQL authentication

For a SQL Server instance listening on port 1433:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=InambuQualityCapture;User Id=<username>;Password=<password>;TrustServerCertificate=True"
  }
}
```

Replace `localhost,1433` with your server address and port. For example, a remote server may use `Server=db.example.com,1433` and a Docker-published SQL Server may use a different host port.

### SQL Server with Windows authentication

On a Windows development machine using integrated security:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=InambuQualityCapture;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

Use the authentication method supported by your SQL Server installation.

### Keep credentials out of source control

Do not commit real passwords or other secrets to `appsettings.json`. User secrets are recommended for local development:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=InambuQualityCapture;User Id=<username>;Password=<password>;TrustServerCertificate=True"
```

Environment variables can also override the configuration without editing a file:

```bash
export ConnectionStrings__DefaultConnection='Server=localhost,1433;Database=InambuQualityCapture;User Id=<username>;Password=<password>;TrustServerCertificate=True'
```

On Windows PowerShell, use:

```powershell
$env:ConnectionStrings__DefaultConnection = "Server=localhost,1433;Database=InambuQualityCapture;User Id=<username>;Password=<password>;TrustServerCertificate=True"
```

The connection string currently present in the repository is intended for the original local development environment. Replace it with your own value and rotate any credential that may have been shared or committed.

## Migrations

The repository includes Entity Framework Core migrations. After configuring a reachable database, apply them with:

```bash
dotnet ef database update
```

To create a new migration after changing the models:

```bash
dotnet ef migrations add DescribeYourChange
dotnet ef database update
```

If the `dotnet ef` command is unavailable, install the tool once:

```bash
dotnet tool install --global dotnet-ef
```

For a new database, the application can also apply migrations through the development migration endpoint when running in the `Development` environment. Applying migrations explicitly with `dotnet ef database update` is recommended so database changes are visible and repeatable.

## Using another database engine

The application is currently configured for SQL Server, not every database engine automatically. To use PostgreSQL, MySQL, SQLite, or another provider, you must:

1. Add the appropriate EF Core provider package.
2. Replace `options.UseSqlServer(connectionString)` in `Program.cs` with that provider's `Use...` method.
3. Configure a connection string in the format required by that provider.
4. Create and apply provider-compatible migrations.

Different SQL Server databases and SQL Server hosts can be used without code changes; only the connection string needs to change.

## Development commands

```bash
# Restore dependencies
dotnet restore

# Build the application
dotnet build

# Run the application
dotnet run

# Run with the HTTPS launch profile
dotnet run --launch-profile https
```

## Project structure

- `Components/` - Blazor components, pages, layouts, and Identity UI.
- `Data/` - EF Core database context and application user model.
- `Models/` - Measurement, production-line, and statistics models.
- `Migrations/` - EF Core database migrations.
- `Program.cs` - Service registration, SQL Server configuration, and request pipeline.
- `wwwroot/` - Static assets and application styling.

## License

See [LICENSE](LICENSE).
