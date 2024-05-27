using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal.Models
{
    [Table("changelog", Schema = "Avions")]
    public partial class Changelog
    {
        [Key] // Spécifie que cette propriété est la clé primaire
        [Column("id")] // Nom de la colonne dans la base de données
        public int Id { get; set; }

        [Column("type")] // Nom de la colonne dans la base de données
        public byte? Type { get; set; }

        [Column("version")] // Nom de la colonne dans la base de données
        [StringLength(50)] // Longueur maximale de la chaîne
        [Unicode(false)] // Indique que la chaîne ne contient pas de caractères Unicode
        public string? Version { get; set; }

        [Column("description")] // Nom de la colonne dans la base de données
        [StringLength(200)] // Longueur maximale de la chaîne
        [Unicode(false)] // Indique que la chaîne ne contient pas de caractères Unicode
        public string Description { get; set; } = null!;

        [Column("name")] // Nom de la colonne dans la base de données
        [StringLength(300)] // Longueur maximale de la chaîne
        [Unicode(false)] // Indique que la chaîne ne contient pas de caractères Unicode
        public string Name { get; set; } = null!;

        [Column("checksum")] // Nom de la colonne dans la base de données
        [StringLength(32)] // Longueur maximale de la chaîne
        [Unicode(false)] // Indique que la chaîne ne contient pas de caractères Unicode
        public string? Checksum { get; set; }

        [Column("installed_by")] // Nom de la colonne dans la base de données
        [StringLength(100)] // Longueur maximale de la chaîne
        [Unicode(false)] // Indique que la chaîne ne contient pas de caractères Unicode
        public string InstalledBy { get; set; } = null!;

        [Column("installed_on", TypeName = "datetime")] // Spécifie le type de colonne comme datetime
        public DateTime InstalledOn { get; set; }

        [Column("success")] // Nom de la colonne dans la base de données
        public bool Success { get; set; }
    }
}
