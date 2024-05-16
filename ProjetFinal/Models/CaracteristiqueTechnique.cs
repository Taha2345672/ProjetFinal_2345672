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
        [Key]
        [Column("CaracteristiqueID")]
        public int CaracteristiqueId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string NomCaracteristique { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Description { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? UniteMesure { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? GammeValeurs { get; set; }
        [Column("ModeleAvionID")]
        public int? ModeleAvionId { get; set; }

        [ForeignKey("ModeleAvionId")]
        [InverseProperty("CaracteristiqueTechniques")]
        public virtual ModeleAvion? ModeleAvion { get; set; }
    }
}
