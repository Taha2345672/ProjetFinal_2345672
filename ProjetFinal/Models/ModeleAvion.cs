using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("ModeleAvion")]
    public partial class ModeleAvion
    {
        public ModeleAvion()
        {
            Avions = new HashSet<Avion>();
            CaracteristiqueTechniques = new HashSet<CaracteristiqueTechnique>();
        }

        [Key]
        [Column("ModeleAvionID")]
        public int ModeleAvionId { get; set; }
        [Column("MarqueID")]
        public int? MarqueId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string NomModele { get; set; } = null!;
        public int? AnneeLancement { get; set; }
        public int? CapacitePassagers { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Longueur { get; set; }

        [ForeignKey("MarqueId")]
        [InverseProperty("ModeleAvions")]
        public virtual Marque? Marque { get; set; }
        [InverseProperty("ModeleAvion")]
        public virtual ICollection<Avion> Avions { get; set; }
        [InverseProperty("ModeleAvion")]
        public virtual ICollection<CaracteristiqueTechnique> CaracteristiqueTechniques { get; set; }
    }
}
