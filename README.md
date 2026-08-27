# Inambu Manufacturing

A Blazor ASP.NET Core app for capturing quality-control measurements, tracking production-line data, and managing capital expenditure requests.

## Features

- ASP.NET Core Identity login and account management
- Measurement capture for temperature, humidity, weight, width, length, and depth
- Pass/fail tracking and summary statistics
- Capital request submission and approval workflow
- SQL Server-backed data model with EF Core migrations

## Requirements

- .NET 9 SDK
- SQL Server (configured via `ConnectionStrings:DefaultConnection`)

## Run locally

```bash
git clone https://github.com/Chimoneg27/Inambu-Manufacturing-Pty.git
cd Inambu-Manufacturing-Pty
dotnet restore
dotnet ef database update
dotnet run
```

## Database config

Set your connection string in `appsettings.Development.json` or use user secrets:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=InambuQualityCapture;User Id=<username>;Password=<password>;TrustServerCertificate=True"
```

## Project structure

```text
Inambu-Manufacturing-Pty/
├── Components/
│   ├── Account/
│   ├── CapitalExRequests/
│   ├── Layout/
│   ├── Measurements/
│   └── Pages/
├── Data/
├── Migrations/
├── Models/
├── Properties/
├── wwwroot/
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── Inambu-Manufacturing-Pty.csproj
├── LICENSE
├── README.md
└── .gitignore
```

## License

See [LICENSE](LICENSE).
