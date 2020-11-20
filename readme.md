# About

Getting started with EF Core 5

**More coming**

# How to get EF Core 5.0

See [Microsoft documentation](https://devblogs.microsoft.com/dotnet/announcing-the-release-of-ef-core-5-0/#how-to-get-ef-core-5-0)

> EF Core 5.0 requires a .NET Standard 2.1 platform. This means EF Core 5.0 will run on .NET Core 3.1 or .NET 5, as well as other platforms that support .NET Standard 2.1. EF Core 5.0 does not run on .NET Framework.

# Entity Framework documentation

See [Microsoft documentation](https://docs.microsoft.com/en-us/ef/)

# Database providers

[Current providers](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)


# Requires

- The following [database script](https://gist.github.com/karenpayneoregon/9bdf1a7d5310ac1d562b2326d79d6038).
  - Before running the script inspect the path where the database will be created to match your SQL-Server installation.
- The following NuGet packages are needed for the json configuration file
  - Microsoft.Extensions.Configuration
  - Microsoft.Extensions.Configuration.FileExtensions
  - Microsoft.Extensions.Configuration.Json
  - Microsoft.Extensions.Configuration.Binder

