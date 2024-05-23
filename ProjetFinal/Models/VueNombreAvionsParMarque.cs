using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Keyless]
    public partial class VueNombreAvionsParMarque
    {
        [StringLength(255)]
        [Unicode(false)]
        public string? NomMarque { get; set; }
        public int? NombreAvions { get; set; }
    }
}
