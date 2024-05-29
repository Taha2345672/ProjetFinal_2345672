using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("Performance", Schema = "Industries")]
    
    [Index("VitesseMax", "AltitudeMax", Name = "UC_Performance", IsUnique = true)]
    public partial class Performance
    {
        
        public Performance()
        {
            Avions = new HashSet<Avion>();
        }

       
        [Key]
        [Column("PerformanceID")]
        public int PerformanceId { get; set; }

      
        public int? VitesseMax { get; set; }

       
        public int? AltitudeMax { get; set; }

        
        [InverseProperty("Performance")]
        public virtual ICollection<Avion> Avions { get; set; }
    }
}
