# About

Simple example for executing a stored procedure where the stored procedure has joins. There are two methods, one to return all properties and a wrapper to return one property into a list.

[Microsoft TechNet article](https://social.technet.microsoft.com/wiki/contents/articles/54154.ef-core-5-stored-procedures-net-5-c.aspx)

Reverse engineering including stored procedures done using [EF Core Power tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools). After reverse engineering classes generated were moved to different folders from where EF Power Tools placed them.

- [Class](https://github.com/karenpayneoregon/csharp-features/blob/master/EntityFrameworkCoreStoredProcedures/Context/StoredProcedures.cs) for stored procedures.
- [Container class](http://example.com) for stored procedure data.
### Stored procedure

```sql
USE [NorthWind2020]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[uspCustomersByCountryIdentifier](@CountryIdentifier int)
AS
BEGIN
SELECT        Cust.CustomerIdentifier, Cust.CompanyName, Cust.ContactId, CT.ContactTitle, C.FirstName, C.LastName, Cust.Street, Cust.City, Cust.Region, Cust.PostalCode, Cust.Phone, Cust.ContactTypeIdentifier, Cust.ModifiedDate, 
                         Cust.CountryIdentifier, CO.Name
FROM            Customers AS Cust INNER JOIN
                         Contacts AS C ON Cust.ContactId = C.ContactId INNER JOIN
                         ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier AND C.ContactTypeIdentifier = CT.ContactTypeIdentifier INNER JOIN
                         Countries AS CO ON Cust.CountryIdentifier = CO.CountryIdentifier
WHERE        Cust.CountryIdentifier = @CountryIdentifier
END
GO


```
