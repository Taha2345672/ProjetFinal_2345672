USE master 
GO

-- CREATION ou RECREATION de la BD
IF
EXISTS(SELECT * FROM sys.databases WHERE name='AviationDB')
BEGIN
	DROP DATABASE AviationDB
END

CREATE DATABASE AviationDB
GO

-- Configuration de FILESTREAM
EXEC sp_configure filestream_access_level, 2 RECONFIGURE

ALTER DATABASE AviationDB
ADD FILEGROUP AviationDB_Images CONTAINS FILESTREAM;
GO

ALTER DATABASE AviationDB
ADD FILE (
	NAME = AviationDB_Images,
	FILENAME = 'C:\EspaceLabo\AviationDB_Images'
)
TO FILEGROUP AviationDB_Images
GO

-- Configuration des clés symétriques
USE AviationDB
GO

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'CeciEst1GrosMotDePasse!'
GO
CREATE CERTIFICATE AviationDB_Certificat WITH SUBJECT = 'PaysOrigine'
GO
CREATE SYMMETRIC KEY AviationDB_Cle WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE AviationDB_Certificat
GO
