GO
CREATE VIEW Vue_NombreAvionsParMarque AS
SELECT Marque.NomMarque, COUNT(Avion.AvionID) AS NombreAvions
FROM Avions.Marque
LEFT JOIN Avions.ModeleAvion ON Marque.MarqueID = ModeleAvion.MarqueID
LEFT JOIN Avions.Avion ON ModeleAvion.ModeleAvionID = Avion.ModeleAvionID
GROUP BY Marque.NomMarque;
GO
