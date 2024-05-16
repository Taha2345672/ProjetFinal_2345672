-- Création de la vue VueAvions
GO
CREATE VIEW VueAvions AS
SELECT A.Nom AS NomAvion, MA.NomModele, M.NomMarque, MA.CapacitePassagers, A.DateFabrication
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID;
GO

-- Affichage de toutes les colonnes de la vue VueAvions
SELECT NomAvion, NomModele, NomMarque, CapacitePassagers, DateFabrication
FROM VueAvions


-- Création de la fonction CalculerAgeAvion
GO
CREATE FUNCTION dbo.CalculerAgeAvion (@DateFabrication DATE)
RETURNS INT
AS
BEGIN
    DECLARE @Age INT;
    SET @Age = YEAR(GETDATE()) - YEAR(@DateFabrication);
    IF (MONTH(GETDATE()) < MONTH(@DateFabrication) OR (MONTH(GETDATE()) = MONTH(@DateFabrication) AND DAY(GETDATE()) < DAY(@DateFabrication)))
        SET @Age = @Age - 1;
    RETURN @Age;
END;
GO

-- Utilisation de la fonction dans une requête SELECT
GO
SELECT A.Nom, MA.NomModele, M.NomMarque
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
WHERE dbo.CalculerAgeAvion(A.DateFabrication) > 10;
GO

-- Procédure stockée
GO
CREATE PROCEDURE GetAvionsParModele
    @NomModele VARCHAR(255)
AS
BEGIN
    -- Sélection des avions du modèle spécifié
    SELECT A.Nom, MA.NomModele, M.NomMarque, MA.CapacitePassagers, A.DateFabrication
    FROM Avion AS A
    INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
    INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
    WHERE MA.NomModele = @NomModele;
END;
GO

-- Procédure stockée pour récupérer les avions fabriqués après une certaine dateGO
CREATE PROCEDURE GetAvionsApresDate
    @DateLimite DATE
AS
BEGIN
    -- Sélection des avions fabriqués après la date limite spécifiée
    SELECT A.Nom, MA.NomModele, M.NomMarque, MA.CapacitePassagers, A.DateFabrication
    FROM Avion AS A
    INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
    INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
    WHERE A.DateFabrication > @DateLimite;
END;
GO

-- Exécution de la procédure GetAvionsParModele
EXEC GetAvionsParModele @NomModele = '172 Skyhawk';

-- Exécution de la procédure GetAvionsApresDate 
EXEC GetAvionsApresDate @DateLimite = '2000-01-01';

-- Ajout de la colonne LastModifiedDate à la table Avion
GO
ALTER TABLE Avion
ADD LastModifiedDate DATETIME;



-- Création du déclencheur UpdateLastModifiedDate
GO
CREATE TRIGGER UpdateLastModifiedDate
ON dbo.Avion
AFTER UPDATE
AS
BEGIN
    -- Mise à jour de la date de dernière modification dans la table des avions
    UPDATE Avion
    SET LastModifiedDate = GETDATE()
    WHERE AvionID IN (SELECT DISTINCT AvionID FROM inserted)
END;

-- Mise à jour d'une ligne dans la table des avions
UPDATE Avion
SET Poids = 3000
WHERE AvionID = 1;

-- Sélection pour vérifier la mise à jour de la date de dernière modification
SELECT * FROM Avion WHERE AvionID = 1;




