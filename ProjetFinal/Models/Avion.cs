using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Avion", Schema = "Avions")]
    public partial class Avion
    {
        [Key]
        [Column("AvionID")]
        public int AvionId { get; set; }
        [Column("ModeleAvionID")]
        public int? ModeleAvionId { get; set; }
        [Column("PerformanceID")]
        public int? PerformanceId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Nom { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? DateFabrication { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Poids { get; set; }

        [ForeignKey("ModeleAvionId")]
        [InverseProperty("Avions")]
        public virtual ModeleAvion? ModeleAvion { get; set; }
        [ForeignKey("PerformanceId")]
        [InverseProperty("Avions")]
        public virtual Performance? Performance { get; set; }
    }
}
