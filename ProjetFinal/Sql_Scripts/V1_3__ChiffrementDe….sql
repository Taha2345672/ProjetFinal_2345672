USE AviationDB;
GO

-- Créer une clé maîtresse avec un mot de passe
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'MotDePasseSecret123!';

-- Créer un certificat auto-signé
CREATE CERTIFICATE MonCertificat
   WITH SUBJECT = 'ChiffrementAvions';

-- Créer une clé symétrique pour le chiffrement
CREATE SYMMETRIC KEY MaCleSymetrique
    WITH ALGORITHM = AES_256
   ENCRYPTION BY CERTIFICATE MonCertificat;
   
-- Ajouter un champ pour stocker le bonus secret chiffré
ALTER TABLE Avions.Avion 
ADD BonusSecretChiffre VARBINARY(MAX) NULL;
GO
-- Chiffrer le bonus secret et le stocker dans BonusSecretChiffre
OPEN SYMMETRIC KEY MaCleSymetrique
    DECRYPTION BY CERTIFICATE MonCertificat;

UPDATE Avions.Avion
SET BonusSecretChiffre = EncryptByKey (KEY_GUID('MaCleSymetrique'), BonusSecret);

CLOSE SYMMETRIC KEY MaCleSymetrique;

-- Déchiffrement
GO
CREATE PROCEDURE Avions.USP_DechiffrementBonusSecret
    @AvionId INT
AS 
BEGIN
    OPEN SYMMETRIC KEY MaCleSymetrique 
        DECRYPTION BY CERTIFICATE MonCertificat;

    SELECT CONVERT(NVARCHAR(MAX), DECRYPTBYKEY(BonusSecretChiffre)) AS BonusSecretClair
    FROM Avions.Avion
    WHERE AvionId = @AvionId;

    CLOSE SYMMETRIC KEY MaCleSymetrique;
END;
GO

