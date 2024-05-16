-- Cr�ation de la vue VueAvions
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


-- Cr�ation de la fonction CalculerAgeAvion
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

-- Utilisation de la fonction dans une requ�te SELECT
GO
SELECT A.Nom, MA.NomModele, M.NomMarque
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
WHERE dbo.CalculerAgeAvion(A.DateFabrication) > 10;
GO

-- Proc�dure stock�e
GO
CREATE PROCEDURE GetAvionsParModele
    @NomModele VARCHAR(255)
AS
BEGIN
    -- S�lection des avions du mod�le sp�cifi�
    SELECT A.Nom, MA.NomModele, M.NomMarque, MA.CapacitePassagers, A.DateFabrication
    FROM Avion AS A
    INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
    INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
    WHERE MA.NomModele = @NomModele;
END;
GO

-- Proc�dure stock�e pour r�cup�rer les avions fabriqu�s apr�s une certaine dateGO
CREATE PROCEDURE GetAvionsApresDate
    @DateLimite DATE
AS
BEGIN
    -- S�lection des avions fabriqu�s apr�s la date limite sp�cifi�e
    SELECT A.Nom, MA.NomModele, M.NomMarque, MA.CapacitePassagers, A.DateFabrication
    FROM Avion AS A
    INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
    INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
    WHERE A.DateFabrication > @DateLimite;
END;
GO

-- Ex�cution de la proc�dure GetAvionsParModele
EXEC GetAvionsParModele @NomModele = '172 Skyhawk';

-- Ex�cution de la proc�dure GetAvionsApresDate 
EXEC GetAvionsApresDate @DateLimite = '2000-01-01';

-- Ajout de la colonne LastModifiedDate � la table Avion
GO
ALTER TABLE Avion
ADD LastModifiedDate DATETIME;



-- Cr�ation du d�clencheur UpdateLastModifiedDate
GO
CREATE TRIGGER UpdateLastModifiedDate
ON dbo.Avion
AFTER UPDATE
AS
BEGIN
    -- Mise � jour de la date de derni�re modification dans la table des avions
    UPDATE Avion
    SET LastModifiedDate = GETDATE()
    WHERE AvionID IN (SELECT DISTINCT AvionID FROM inserted)
END;

-- Mise � jour d'une ligne dans la table des avions
UPDATE Avion
SET Poids = 3000
WHERE AvionID = 1;

-- S�lection pour v�rifier la mise � jour de la date de derni�re modification
SELECT * FROM Avion WHERE AvionID = 1;




