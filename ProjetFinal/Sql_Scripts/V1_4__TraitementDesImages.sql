-- Créer une procédure stockée pour insérer une image dans la table des avions
CREATE PROCEDURE [Avions].[InsertImage]
    @AvionID INT,
    @ImageData VARBINARY(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Vérifier si l'avion existe
    IF EXISTS (SELECT 1 FROM Avions.Avion WHERE AvionID = @AvionID)
    BEGIN
        -- Mettre à jour l'image de l'avion s'il existe déjà
        UPDATE Avions.Avion
        SET ImageData = @ImageData
        WHERE AvionID = @AvionID;
    END
    ELSE
    BEGIN
        -- Insérer une nouvelle entrée avec l'image
        INSERT INTO Avions.Avion (AvionID, ImageData)
        VALUES (@AvionID, @ImageData);
    END
END;
GO
