﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Marque")]
    [Index("NomMarque", Name = "UC_NomMarque", IsUnique = true)]
    [Index("NomMarque", Name = "UQ__Marque__B430BC372DB921E9", IsUnique = true)]
    public partial class Marque
    {
        public Marque()
        {
            ModeleAvions = new HashSet<ModeleAvion>();
        }

        [Key]
        [Column("MarqueID")]
        public int MarqueId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? NomMarque { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? PaysOrigine { get; set; }
        public int? AnneeFondation { get; set; }

        [InverseProperty("Marque")]
        public virtual ICollection<ModeleAvion> ModeleAvions { get; set; }
    }
}