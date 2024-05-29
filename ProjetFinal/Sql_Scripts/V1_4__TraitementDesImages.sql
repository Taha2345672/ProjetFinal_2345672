USE AviationDB
GO

-- Ajouter une nouvelle colonne pour l'identifiant unique
ALTER TABLE Avions.Avion
ADD RowGuid uniqueidentifier NOT NULL ROWGUIDCOL DEFAULT newid();

-- Ajouter une contrainte d'unicité sur la colonne RowGuid
ALTER TABLE Avions.Avion
ADD CONSTRAINT _RowGuid UNIQUE (RowGuid);

-- Modifier le type de données de la colonne Image pour stocker les images
ALTER TABLE Avions.Avion
ADD image VARBINARY(MAX) FILESTREAM NULL;