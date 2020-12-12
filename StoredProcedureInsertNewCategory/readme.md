# About 

Basic template/code sample for inserting a new record using Entity Framework Core 5 using the stored procedure below.

### Important

* The parameter for returning the new primary key 
  * Must have ParameterDirection set to Output when setting up that parameter which is the third parameter in the parameter array.
  * In @Identity out *@Identity out* works in tangent with the bullet point above.
  * ExecuteSqlRaw does not return the new primary key, the key is obtained by getting the value for the parameter @Identity.
* To run this code sample, run [the following script](https://gist.github.com/karenpayneoregon/9bdf1a7d5310ac1d562b2326d79d6038) then run the create procedure code below.


```sql
USE [NorthWind2020]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspInsertCategory]  
    @CategoryName NVARCHAR(15), 
    @Description ntext, 
    @Identity INT OUT 
AS 
BEGIN 
    -- SET NOCOUNT ON added to prevent extra result sets from 
    -- interfering with SELECT statements. 
    SET NOCOUNT ON; 
INSERT INTO dbo.Categories (CategoryName, Description) VALUES (@CategoryName, @Description);
SET @Identity = SCOPE_IDENTITY() 
 
END 
 
GO

```
