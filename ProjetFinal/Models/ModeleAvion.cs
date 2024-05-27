using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    // La classe ModeleAvion est mappée à la table "ModeleAvion" dans le schéma "Avions"
    [Table("ModeleAvion", Schema = "Avions")]
    public partial class ModeleAvion
    {
        // Constructeur par défaut initialisant les collections Avions et CaracteristiqueTechniques
        public ModeleAvion()
        {
            Avions = new HashSet<Avion>();
            CaracteristiqueTechniques = new HashSet<CaracteristiqueTechnique>();
        }

        // Clé primaire de la table
        [Key]
        [Column("ModeleAvionID")]
        public int ModeleAvionId { get; set; }

        // Clé étrangère liée à la marque de cet avion
        [Column("MarqueID")]
        public int? MarqueId { get; set; }

        // Nom du modèle d'avion
        [StringLength(255)]
        [Unicode(false)]
        public string NomModele { get; set; } = null!;

        // Année de lancement du modèle d'avion
        public int? AnneeLancement { get; set; }

        // Capacité de passagers du modèle d'avion
        public int? CapacitePassagers { get; set; }

        // Longueur du modèle d'avion
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Longueur { get; set; }

        // Navigation vers la marque associée à ce modèle d'avion
        [ForeignKey("MarqueId")]
        [InverseProperty("ModeleAvions")]
        public virtual Marque? Marque { get; set; }

        // Navigation vers les avions associés à ce modèle d'avion
        [InverseProperty("ModeleAvion")]
        public virtual ICollection<Avion> Avions { get; set; }

        // Navigation vers les caractéristiques techniques associées à ce modèle d'avion
        [InverseProperty("ModeleAvion")]
        public virtual ICollection<CaracteristiqueTechnique> CaracteristiqueTechniques { get; set; }
    }
}
