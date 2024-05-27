using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

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
