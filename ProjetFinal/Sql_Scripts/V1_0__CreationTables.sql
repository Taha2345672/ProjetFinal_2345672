
-- Cr�ation de la table Marque avec une contrainte UNIQUE sur NomMarque
CREATE TABLE Avions.Marque (
    MarqueID INT PRIMARY KEY IDENTITY,
    NomMarque VARCHAR(255) UNIQUE,
    PaysOrigine VARCHAR(100),
    AnneeFondation INT, 
    CONSTRAINT UC_NomMarque UNIQUE (NomMarque)
);


--Cr�ation de la table Mod�leAvion avec des cl�s �trang�res, une contrainte CHECK et une contrainte DEFAULT
CREATE TABLE Avions.ModeleAvion (
    ModeleAvionID INT PRIMARY KEY IDENTITY,
    MarqueID INT,
    NomModele VARCHAR(255) NOT NULL,
    AnneeLancement INT,
    CapacitePassagers INT DEFAULT 0,
    Longueur DECIMAL(10,2),
    CONSTRAINT FK_MarqueID FOREIGN KEY (MarqueID) REFERENCES Avions.Marque(MarqueID),
    CONSTRAINT CHK_AnneeLancement CHECK (AnneeLancement >= 1900 AND AnneeLancement <= YEAR(GETDATE()))
);


-- Cr�ation de la table CaracteristiqueTechnique avec une contrainte de cl� �trang�re
CREATE TABLE Avions.CaracteristiqueTechnique (
    CaracteristiqueID INT PRIMARY KEY IDENTITY,
    NomCaracteristique VARCHAR(255) NOT NULL,
    Description TEXT,
    UniteMesure VARCHAR(50),
    GammeValeurs VARCHAR(100),
    ModeleAvionID INT,
    CONSTRAINT FK_ModeleAvionID FOREIGN KEY (ModeleAvionID) REFERENCES Avions.ModeleAvion(ModeleAvionID)
);


-- Cr�ation de la table Performance avec une contrainte de cl� �trang�re et une contrainte UNIQUE
CREATE TABLE Industries.Performance (
    PerformanceID INT PRIMARY KEY IDENTITY,
    VitesseMax INT,
    AltitudeMax INT,
    CONSTRAINT UC_Performance UNIQUE (VitesseMax, AltitudeMax)
);


-- Cr�ation de la table Avion avec des contraintes de cl�s �trang�res
CREATE TABLE Avions.Avion (
    AvionID INT PRIMARY KEY IDENTITY,
    ModeleAvionID INT,
    PerformanceID INT,
    Nom VARCHAR(255) NOT NULL,
    BonusSecret  VARBINARY(MAX),
    DateFabrication DATE,
    Poids DECIMAL(10,2),
    CONSTRAINT FK_ModeleAvionID_Avion FOREIGN KEY (ModeleAvionID) REFERENCES Avions.ModeleAvion(ModeleAvionID),
    CONSTRAINT FK_PerformanceID FOREIGN KEY (PerformanceID) REFERENCES Industries.Performance(PerformanceID)
);
