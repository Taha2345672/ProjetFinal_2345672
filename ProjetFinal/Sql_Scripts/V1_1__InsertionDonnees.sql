INSERT INTO Marque (NomMarque, PaysOrigine, AnneeFondation) 
VALUES ('Cessna', 'États-Unis', 1927),
       ('Piper', 'États-Unis', 1927),
       ('Cirrus', 'États-Unis', 1984);
GO

-- Insertion des modèles d'avions pour Cessna
INSERT INTO ModeleAvion (MarqueID, NomModele, AnneeLancement, CapacitePassagers, Longueur) 
VALUES (1, '172 Skyhawk', 1955, 4, 8.23),
       (1, '182 Skylane', 1956, 4, 8.84),
       (1, '152', 1977, 2, 7.11),
       (1, 'Caravan', 1984, 14, 11.58);
	   GO

-- Insertion des modèles d'avions pour Piper
INSERT INTO ModeleAvion (MarqueID, NomModele, AnneeLancement, CapacitePassagers, Longueur) 
VALUES (2, 'Cherokee', 1960, 4, 7.52),
       (2, 'Cherokee 6', 1965, 6, 8.69),
       (2, 'Piper PA-28 Arrow', 1967, 4, 8.23),
       (2, 'Piper PA-32 Cherokee Six', 1965, 6, 8.84),
       (2, 'Piper PA-44 Seminole', 1978, 4, 8.32);
	   GO

-- Insertion des modèles d'avions pour Cirrus
INSERT INTO ModeleAvion (MarqueID, NomModele, AnneeLancement, CapacitePassagers, Longueur) 
VALUES (3, 'SR20', 1999, 4, 8.15),
       (3, 'SR22', 2001, 5, 8.56),
       (3, 'SR22T', 2001, 5, 8.56);
	   GO



-- Insertion des caractéristiques techniques pour les modèles d'avions de Cessna
INSERT INTO CaracteristiqueTechnique (NomCaracteristique, Description, UniteMesure, GammeValeurs, ModeleAvionID) 
VALUES 
('Envergure', 'La distance entre les extrémités des ailes.', 'mètres', 'De 7 à 12', 1),
('Masse maximale au décollage', 'Le poids maximal autorisé au décollage.', 'kilogrammes', 'De 750 à 1300', 1),
('Nombre de moteurs', 'Le nombre total de moteurs installés sur l''avion.', 'unités', '1', 1),
('Rayon d''action', 'La distance maximale que l''avion peut parcourir sans ravitaillement.', 'kilomètres', 'De 700 à 1000', 1);
GO

-- Insertion des caractéristiques techniques pour les modèles d'avions de Piper (suite)
INSERT INTO CaracteristiqueTechnique (NomCaracteristique, Description, UniteMesure, GammeValeurs, ModeleAvionID) 
VALUES 
('Nombre de moteurs', 'Le nombre total de moteurs installés sur l''avion.', 'unités', '1', 5),
('Rayon d''action', 'La distance maximale que l''avion peut parcourir sans ravitaillement.', 'kilomètres', 'De 800 à 1100', 5);
GO

-- Insertion des caractéristiques techniques pour les modèles d'avions de Cirrus
INSERT INTO CaracteristiqueTechnique (NomCaracteristique, Description, UniteMesure, GammeValeurs, ModeleAvionID) 
VALUES 
('Envergure', 'La distance entre les extrémités des ailes.', 'mètres', 'De 7 à 12', 9),
('Masse maximale au décollage', 'Le poids maximal autorisé au décollage.', 'kilogrammes', 'De 700 à 1200', 9),
('Nombre de moteurs', 'Le nombre total de moteurs installés sur l''avion.', 'unités', '1', 9),
('Rayon d''action', 'La distance maximale que l''avion peut parcourir sans ravitaillement.', 'kilomètres', 'De 900 à 1300', 9);
GO



-- Insertion des performances
INSERT INTO Performance (VitesseMax, AltitudeMax) 
VALUES 
(200, 5000),
(250, 6000),
(300, 7000);
GO


-- Insertion des avions
INSERT INTO Avion (ModeleAvionID, PerformanceID, Nom, DateFabrication, Poids) 
VALUES 
(1, 1, 'Cessna 172 Skyhawk II', '1960-01-01', 1250),
(2, 2, 'Cessna 182 Skylane II', '1962-01-01', 1450),
(3, 3, 'Cessna 152 II', '1980-01-01', 850),
(4, 1, 'Cessna Caravan II', '1988-01-01', 2700),
(5, 2, 'Piper Cherokee II', '1963-01-01', 1150),
(6, 2, 'Piper Cherokee 6 II', '1967-01-01', 1350),
(7, 2, 'Piper PA-28 Arrow II', '1970-01-01', 1300),
(8, 2, 'Piper PA-32 Cherokee Six II', '1968-01-01', 1500),
(9, 3, 'Cirrus SR20 II', '2002-01-01', 1150),
(10, 3, 'Cirrus SR22 II', '2004-01-01', 1250),
(11, 3, 'Cirrus SR22T II', '2004-01-01', 1350),
(1, 1, 'Cessna 172 Skyhawk III', '1965-01-01', 1300),
(2, 2, 'Cessna 182 Skylane III', '1968-01-01', 1500),
(3, 3, 'Cessna 152 III', '1985-01-01', 900),
(4, 1, 'Cessna Caravan III', '1990-01-01', 2800),
(5, 2, 'Piper Cherokee III', '1965-01-01', 1200),
(6, 2, 'Piper Cherokee 6 III', '1969-01-01', 1400),
(7, 2, 'Piper PA-28 Arrow III', '1972-01-01', 1350),
(8, 2, 'Piper PA-32 Cherokee Six III', '1970-01-01', 1550),
(9, 3, 'Cirrus SR20 III', '2005-01-01', 1200),
(10, 3, 'Cirrus SR22 III', '2007-01-01', 1300);
GO