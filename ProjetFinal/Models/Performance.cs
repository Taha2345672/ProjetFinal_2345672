using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    // La classe Performance est mappée à la table "Performance" dans le schéma "Industries"
    [Table("Performance", Schema = "Industries")]
    // Création d'un index unique sur les colonnes VitesseMax et AltitudeMax
    [Index("VitesseMax", "AltitudeMax", Name = "UC_Performance", IsUnique = true)]
    public partial class Performance
    {
        // Constructeur par défaut initialisant la collection Avions
        public Performance()
        {
            Avions = new HashSet<Avion>();
        }

        // Clé primaire de la table
        [Key]
        [Column("PerformanceID")]
        public int PerformanceId { get; set; }

        // Vitesse maximale de performance de l'avion
        public int? VitesseMax { get; set; }

        // Altitude maximale de performance de l'avion
        public int? AltitudeMax { get; set; }

        // Navigation vers les avions associés à cette performance
        [InverseProperty("Performance")]
        public virtual ICollection<Avion> Avions { get; set; }
    }
}
