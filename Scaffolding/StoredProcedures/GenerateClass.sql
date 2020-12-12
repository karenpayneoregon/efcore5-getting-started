SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGenerateClass]
(    
    @TableName AS sysname,
	@Result AS NVARCHAR(MAX) OUTPUT,
	@ClassInformation AS NVARCHAR(MAX) 
) AS
BEGIN
SET @ClassInformation = @ClassInformation  + @TableName

SELECT  @ClassInformation = @ClassInformation + '
    Public Property ' + ColumnName + ' As ' + ColumnType + NullableSign
FROM    ( SELECT    REPLACE(col.name, ' ', '_') ColumnName ,
                    column_id ColumnId ,
                    CASE typ.name
                      WHEN 'bigint' THEN 'Long'
                      WHEN 'binary' THEN 'Byte[]'
                      WHEN 'bit' THEN 'Boolean'
                      WHEN 'char' THEN 'String'
                      WHEN 'date' THEN 'DateTime'
                      WHEN 'datetime' THEN 'DateTime'
                      WHEN 'datetime2' THEN 'DateTime'
                      WHEN 'datetimeoffset' THEN 'DateTimeOffset'
                      WHEN 'decimal' THEN 'Decimal'
                      WHEN 'float' THEN 'Float'
                      WHEN 'image' THEN 'Byte()'
                      WHEN 'int' THEN 'Integer'
                      WHEN 'money' THEN 'Decimal'
                      WHEN 'nchar' THEN 'String'
                      WHEN 'ntext' THEN 'String'
                      WHEN 'numeric' THEN 'Decimal'
                      WHEN 'nvarchar' THEN 'String'
                      WHEN 'real' THEN 'Double'
                      WHEN 'smalldatetime' THEN 'DateTime'
                      WHEN 'smallint' THEN 'Short'
                      WHEN 'smallmoney' THEN 'Decimal'
                      WHEN 'text' THEN 'String'
                      WHEN 'time' THEN 'TimeSpan'
                      WHEN 'timestamp' THEN 'DateTime'
                      WHEN 'tinyint' THEN 'Byte'
                      WHEN 'uniqueidentifier' THEN 'Guid'
                      WHEN 'varbinary' THEN 'Byte()'
                      WHEN 'varchar' THEN 'String'
                      ELSE 'UNKNOWN_' + typ.name
                    END ColumnType ,
                    CASE WHEN col.is_nullable = 1
                              AND typ.name IN ( 'bigint', 'bit', 'date',
                                                'datetime', 'datetime2',
                                                'datetimeoffset', 'decimal',
                                                'float', 'int', 'money',
                                                'numeric', 'real',
                                                'smalldatetime', 'smallint',
                                                'smallmoney', 'time',
                                                'tinyint', 'uniqueidentifier' )
                         THEN '?'
                         ELSE ''
                    END NullableSign
          FROM      sys.columns col
                    JOIN sys.types typ ON col.system_type_id = typ.system_type_id
                                          AND col.user_type_id = typ.user_type_id
          WHERE     object_id = OBJECT_ID(@TableName)
        ) t
ORDER BY ColumnId;

SET @ClassInformation = @ClassInformation + ' 
End Class';

SET @Result = @ClassInformation

SELECT @Result

END

GO


