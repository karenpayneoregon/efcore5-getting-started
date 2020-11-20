# About

- Setting up connection string in separate class than the DbContext class
- Using .LogTo for writing to a text file.


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