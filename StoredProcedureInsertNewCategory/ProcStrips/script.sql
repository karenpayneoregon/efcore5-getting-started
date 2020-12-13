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
