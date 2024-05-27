using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("CaracteristiqueTechnique", Schema = "Avions")]
    public partial class CaracteristiqueTechnique
    {
        // Clé primaire de la table
        [Key]
        [Column("CaracteristiqueID")]
        public int CaracteristiqueId { get; set; }

        // Nom de la caractéristique technique
        [StringLength(255)]
        [Unicode(false)]
        public string NomCaracteristique { get; set; } = null!;

        // Description de la caractéristique technique
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        // Unité de mesure de la caractéristique technique
        [StringLength(50)]
        [Unicode(false)]
        public string? UniteMesure { get; set; }

        // Gamme de valeurs possibles de la caractéristique technique
        [StringLength(100)]
        [Unicode(false)]
        public string? GammeValeurs { get; set; }

        // Clé étrangère liée au modèle d'avion associé à cette caractéristique technique
        [Column("ModeleAvionID")]
        public int? ModeleAvionId { get; set; }

        // Navigation vers le modèle d'avion associé
        [ForeignKey("ModeleAvionId")]
        [InverseProperty("CaracteristiqueTechniques")]
        public virtual ModeleAvion? ModeleAvion { get; set; }
    }
}
