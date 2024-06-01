-- Création de l'index sur la colonne NomModele de la table ModeleAvions
CREATE INDEX IX_ModeleAvions_NomModele 
ON Avions.ModeleAvion (NomModele);

-- Création de l'index composite sur les colonnes MarqueId et AnneeLancement de la table ModeleAvions
CREATE INDEX IX_ModeleAvions_MarqueId_AnneeLancement 
ON Avions.ModeleAvion (MarqueId, AnneeLancement);