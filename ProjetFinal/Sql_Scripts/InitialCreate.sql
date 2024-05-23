USE master;
GO

-- Cr�ation ou suppression de la base de donn�es AviationDB
IF EXISTS (SELECT * FROM sys.databases WHERE name='AviationDB')
BEGIN
    DROP DATABASE AviationDB;
END;

CREATE DATABASE AviationDB;
GO

-- Configuration de FILESTREAM
EXEC sp_configure 'filestream_access_level', 2;
RECONFIGURE;
GO

-- Ajout du FILEGROUP pour FILESTREAM
ALTER DATABASE AviationDB
ADD FILEGROUP AviationDB_Images CONTAINS FILESTREAM;

ALTER DATABASE AviationDB
ADD FILE (
    NAME = AviationDB_Images,
    FILENAME = 'C:\EspaceLabo\AviationDB_Images'
)
TO FILEGROUP AviationDB_Images;
GO

-- Configuration des cl�s sym�triques dans la base de donn�es AviationDB
USE AviationDB;
GO

