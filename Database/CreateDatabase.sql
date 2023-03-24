USE master
GO

DECLARE @sqlDataPath	nvarchar(255) = CAST(SERVERPROPERTY('instancedefaultdatapath') AS nvarchar(255))
		,@sqlLogPath	nvarchar(255) = CAST(SERVERPROPERTY('instancedefaultlogpath') AS nvarchar(255))


DECLARE @sql nvarchar(max) =   'IF  NOT EXISTS (SELECT name FROM sys.databases WHERE name = N''ProductList'')
								CREATE DATABASE ProductList On
									( NAME = N''ProductList'', FILENAME = N''' + @sqlDataPath + 'ProductList.mdf'' , SIZE = 100Mb , MAXSIZE = UNLIMITED, FILEGROWTH = 10Mb)
										LOG ON 
									( NAME = N''ProductList_log'', FILENAME = N''' + @sqlLogPath + 'ProductList.LDF'' , SIZE = 10Mb , MAXSIZE = UNLIMITED , FILEGROWTH = 10Mb)
									COLLATE SQL_Latin1_General_CP1_CS_AS'

EXEC sp_executesql @sql
GO


