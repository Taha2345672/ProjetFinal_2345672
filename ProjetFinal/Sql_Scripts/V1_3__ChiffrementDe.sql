-- Requête 1 : Sélectionne tous les avions de la marque Cessna et les trie par année de fabrication décroissante
SELECT * 
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
WHERE M.NomMarque = 'Cessna'
ORDER BY A.DateFabrication DESC;
GO

-- Requête 2 : Compte le nombre d'avions par modèle pour chaque marque
SELECT M.NomMarque, MA.NomModele, COUNT(*) AS NombreAvions
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
GROUP BY M.NomMarque, MA.NomModele;
GO

-- Requête 3 : Sélectionne les marques ayant au moins 3 modèles d'avions différents
SELECT M.NomMarque, COUNT(*) AS NombreModeles
FROM ModeleAvion AS MA
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
GROUP BY M.NomMarque
HAVING COUNT(*) >= 3;
GO

-- Requête 4 : avec INNER JOIN sur les 3 tables
SELECT A.Nom, MA.NomModele, CT.NomCaracteristique, CT.Description, P.VitesseMax, P.AltitudeMax
FROM Avion AS A
INNER JOIN ModeleAvion AS MA ON A.ModeleAvionID = MA.ModeleAvionID
INNER JOIN CaracteristiqueTechnique AS CT ON MA.ModeleAvionID = CT.ModeleAvionID
INNER JOIN Performance AS P ON A.PerformanceID = P.PerformanceID;
GO

-- Requête 5 : Sélectionne le modèle d'avion le plus récent de chaque marque
SELECT M.NomMarque, MA.NomModele, MA.AnneeLancement
FROM ModeleAvion AS MA
INNER JOIN Marque AS M ON MA.MarqueID = M.MarqueID
INNER JOIN (
    SELECT MarqueID, MAX(AnneeLancement) AS DerniereAnnee
    FROM ModeleAvion
    GROUP BY MarqueID
) AS MaxAnnee ON MA.MarqueID = MaxAnnee.MarqueID AND MA.AnneeLancement = MaxAnnee.DerniereAnnee;
GO
