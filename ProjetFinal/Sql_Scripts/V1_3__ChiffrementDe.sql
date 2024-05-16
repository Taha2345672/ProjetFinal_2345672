-- Requ�te 1 : S�lectionne tous les avions de la marque Cessna et les trie par ann�e de fabrication d�croissante
SELECT * 
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
WHERE M.NomMarque = 'Cessna'
ORDER BY A.DateFabrication DESC;
GO

-- Requ�te 2 : Compte le nombre d'avions par mod�le pour chaque marque
SELECT M.NomMarque, MA.NomModele, COUNT(*) AS NombreAvions
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
GROUP BY M.NomMarque, MA.NomModele;
GO

-- Requ�te 3 : S�lectionne les marques ayant au moins 3 mod�les d'avions diff�rents
SELECT M.NomMarque, COUNT(*) AS NombreModeles
FROM ModeleAvion AS MA
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
GROUP BY M.NomMarque
HAVING COUNT(*) >= 3;
GO

-- Requ�te 4 : avec INNER JOIN sur les 3 tables
SELECT A.Nom, MA.NomModele, CT.NomCaracteristique, CT.Description, P.VitesseMax, P.AltitudeMax
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN CaracteristiqueTechnique AS CT ON MA.ModeleAvionID = CT.ModeleAvionID
INNER JOIN Performance AS P ON A.PerformanceID = P.PerformanceID;
GO

-- Requ�te 5 : S�lectionne le mod�le d'avion le plus r�cent de chaque marque
SELECT M.NomMarque, MA.NomModele, MA.AnneeLancement
FROM ModeleAvion AS MA
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
INNER JOIN (
    SELECT MarqueID, MAX(AnneeLancement) AS DerniereAnnee
    FROM ModeleAvion
    GROUP BY MarqueID
) AS MaxAnnee ON MA.MarqueID = MaxAnnee.MarqueID AND MA.AnneeLancement = MaxAnnee.DerniereAnnee;
GO
