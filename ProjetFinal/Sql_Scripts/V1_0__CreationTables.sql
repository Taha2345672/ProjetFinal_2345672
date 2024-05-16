
-- Création de la table Marque avec une contrainte UNIQUE sur NomMarque
CREATE TABLE Marque (
    MarqueID INT PRIMARY KEY IDENTITY,
    NomMarque VARCHAR(255) UNIQUE,
    PaysOrigine VARCHAR(100),
    AnneeFondation INT, 
    CONSTRAINT UC_NomMarque UNIQUE (NomMarque)
);


--Création de la table ModèleAvion avec des clés étrangères, une contrainte CHECK et une contrainte DEFAULT
CREATE TABLE ModeleAvion (
    ModeleAvionID INT PRIMARY KEY IDENTITY,
    MarqueID INT,
    NomModele VARCHAR(255) NOT NULL,
    AnneeLancement INT,
    CapacitePassagers INT DEFAULT 0,
    Longueur DECIMAL(10,2),
    CONSTRAINT FK_MarqueID FOREIGN KEY (MarqueID) REFERENCES Marque(MarqueID),
    CONSTRAINT CHK_AnneeLancement CHECK (AnneeLancement >= 1900 AND AnneeLancement <= YEAR(GETDATE()))
);


-- Création de la table CaracteristiqueTechnique avec une contrainte de clé étrangère
CREATE TABLE CaracteristiqueTechnique (
    CaracteristiqueID INT PRIMARY KEY IDENTITY,
    NomCaracteristique VARCHAR(255) NOT NULL,
    Description TEXT,
    UniteMesure VARCHAR(50),
    GammeValeurs VARCHAR(100),
    ModeleAvionID INT,
    CONSTRAINT FK_ModeleAvionID FOREIGN KEY (ModeleAvionID) REFERENCES ModeleAvion(ModeleAvionID)
);


-- Création de la table Performance avec une contrainte de clé étrangère et une contrainte UNIQUE
CREATE TABLE Performance (
    PerformanceID INT PRIMARY KEY IDENTITY,
    VitesseMax INT,
    AltitudeMax INT,
    CONSTRAINT UC_Performance UNIQUE (VitesseMax, AltitudeMax)
);


-- Création de la table Avion avec des contraintes de clés étrangères
CREATE TABLE Avion (
    AvionID INT PRIMARY KEY IDENTITY,
    ModeleAvionID INT,
    PerformanceID INT,
    Nom VARCHAR(255) NOT NULL,
    DateFabrication DATE,
    Poids DECIMAL(10,2),
    CONSTRAINT FK_ModeleAvionID_Avion FOREIGN KEY (ModeleAvionID) REFERENCES ModeleAvion(ModeleAvionID),
    CONSTRAINT FK_PerformanceID FOREIGN KEY (PerformanceID) REFERENCES Performance(PerformanceID)
);
