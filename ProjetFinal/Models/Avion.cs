using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    // La classe Avion est mappée à la table "Avion" dans le schéma "Avions"
    [Table("Avion", Schema = "Avions")]
    public partial class Avion
    {
        // Clé primaire de la table
        [Key]
        [Column("AvionID")]
        public int AvionId { get; set; }

        // Clé étrangère liée au modèle d'avion associé à cet avion
        [Column("ModeleAvionID")]
        public int? ModeleAvionId { get; set; }

        // Clé étrangère liée aux performances de cet avion
        [Column("PerformanceID")]
        public int? PerformanceId { get; set; }

        // Nom de l'avion
        [StringLength(255)]
        [Unicode(false)]
        public string Nom { get; set; } = null!;

        // Date de fabrication de l'avion
        [Column(TypeName = "date")]
        public DateTime? DateFabrication { get; set; }

        // Poids de l'avion
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Poids { get; set; }

        // Bonus secret de l'avion
        public string? BonusSecret { get; set; }

        // Données binaires de l'image de l'avion
      //  public byte[]? ImageData { get; set; }

        // Navigation vers le modèle d'avion associé
        [ForeignKey("ModeleAvionId")]
        [InverseProperty("Avions")]
        public virtual ModeleAvion? ModeleAvion { get; set; }

        // Navigation vers les performances associées à cet avion
        [ForeignKey("PerformanceId")]
        [InverseProperty("Avions")]
        public virtual Performance? Performance { get; set; }
    }
}
