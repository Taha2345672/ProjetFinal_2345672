using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    // La classe Marque est mappée à la table "Marque" dans le schéma "Avions"
    [Table("Marque", Schema = "Avions")]
    // Index unique sur la colonne NomMarque pour garantir l'unicité des noms de marque
    [Index("NomMarque", Name = "UC_NomMarque", IsUnique = true)]
    [Index("NomMarque", Name = "UQ__Marque__B430BC3702D253F7", IsUnique = true)]
    public partial class Marque
    {
        // Constructeur par défaut initialisant la collection de ModeleAvion
        public Marque()
        {
            ModeleAvions = new HashSet<ModeleAvion>();
        }

        // Clé primaire de la table
        [Key]
        [Column("MarqueID")]
        public int MarqueId { get; set; }

        // Nom de la marque
        [StringLength(255)]
        [Unicode(false)]
        public string? NomMarque { get; set; }

        // Pays d'origine de la marque
        [StringLength(100)]
        [Unicode(false)]
        public string? PaysOrigine { get; set; }

        // Année de fondation de la marque
        public int? AnneeFondation { get; set; }

        // Navigation vers les modèles d'avion associés à cette marque
        [InverseProperty("Marque")]
        public virtual ICollection<ModeleAvion> ModeleAvions { get; set; }
    }
}
