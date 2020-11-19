The following SQL generated from CustomerOperations.GetCustomersAsync() where comments are from [TagWith](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.tagwith?view=efcore-5.0) extension method.

> **App name:** path has been shorten
> 
```sql
-- App name: C:\NorthWindApplication\bin\Debug\netcoreapp3.1\NorthWindApplication.exe

-- From: CustomerOperations.GetCustomersAsync

-- Parameters: None

SELECT [c0].[CustomerIdentifier], [c0].[CompanyName], [c1].[ContactId], [c0].[Street], [c0].[City], [c0].[PostalCode], [c0].[CountryIdentifier], [c0].[Phone], [c0].[ContactTypeIdentifier], [c2].[Name] AS [Country], [c1].[FirstName], [c1].[LastName], [c3].[ContactTitle], (
    SELECT TOP(1) [c].[PhoneNumber]
    FROM [ContactDevices] AS [c]
    WHERE ([c1].[ContactId] IS NOT NULL AND ([c1].[ContactId] = [c].[ContactId])) AND ([c].[PhoneTypeIdentifier] = 3)) AS [OfficePhoneNumber]
FROM [Customers] AS [c0]
LEFT JOIN [Contacts] AS [c1] ON [c0].[ContactId] = [c1].[ContactId]
LEFT JOIN [Countries] AS [c2] ON [c0].[CountryIdentifier] = [c2].[CountryIdentifier]
LEFT JOIN [ContactType] AS [c3] ON [c0].[ContactTypeIdentifier] = [c3].[ContactTypeIdentifier]
```