# About

- Setting up connection string in separate class than the DbContext class
- Using .LogTo for writing to a text file.


# Requires

The following NuGet packages are needed for reading the project configuration file in the frontend project NoFrillsSelectCustomersWithAsSplitQuery.

- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.FileExtensions
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.Binder

appsettings.json

```json
{
  "database": {
    "DatabaseServer": ".\\SQLEXPRESS",
    "Catalog": "NorthWind2020"
  }
}
```

# Note
Connection string is read from [ConfigurationHelper.Helper](https://github.com/karenpayneoregon/efcore5-getting-started/blob/master/ConfigurationHelper/Helper.cs) 

