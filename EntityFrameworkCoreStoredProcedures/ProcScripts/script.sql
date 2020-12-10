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

CREATE PROCEDURE [dbo].[uspGetCustomers1]
AS
BEGIN

	SET NOCOUNT ON;
SELECT         Cust.CustomerIdentifier, Cust.CompanyName, Cust.ContactId, CT.ContactTitle, C.FirstName, C.LastName, Cust.Street, Cust.City, Cust.Region, Cust.PostalCode, Cust.Phone, Cust.ContactTypeIdentifier, 
                         Cust.ModifiedDate
FROM            Customers AS Cust INNER JOIN
                         Contacts AS C ON Cust.ContactId = C.ContactId INNER JOIN
                         ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier AND C.ContactTypeIdentifier = CT.ContactTypeIdentifier
  
END
GO


