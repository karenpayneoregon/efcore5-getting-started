


# Requires

The following NuGet packages are needed for reading the project configuration file in the frontend project NoFrillsSelectCustomersWithAsSplitQuery.

appsettings.json

```json
{
  "database": {
    "DatabaseServer": ".\\SQLEXPRESS",
    "Catalog": "NorthWind2020"
  }
}
```

- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.Binder