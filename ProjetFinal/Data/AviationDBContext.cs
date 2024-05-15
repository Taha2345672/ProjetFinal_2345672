using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetFinal.Models;

namespace ProjetFinal.Data
{
    public partial class AviationDBContext : DbContext
    {
        public AviationDBContext()
        {
        }

        public AviationDBContext(DbContextOptions<AviationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avion> Avions { get; set; } = null!;
        public virtual DbSet<CaracteristiqueTechnique> CaracteristiqueTechniques { get; set; } = null!;
        public virtual DbSet<Marque> Marques { get; set; } = null!;
        public virtual DbSet<ModeleAvion> ModeleAvions { get; set; } = null!;
        public virtual DbSet<Performance> Performances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AviationDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avion>(entity =>
            {
                entity.HasOne(d => d.ModeleAvion)
                    .WithMany(p => p.Avions)
                    .HasForeignKey(d => d.ModeleAvionId)
                    .HasConstraintName("FK_ModeleAvionID_Avion");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.Avions)
                    .HasForeignKey(d => d.PerformanceId)
                    .HasConstraintName("FK_PerformanceID");
            });

            modelBuilder.Entity<CaracteristiqueTechnique>(entity =>
            {
                entity.HasKey(e => e.CaracteristiqueId)
                    .HasName("PK__Caracter__BF68064F7731C4CB");

                entity.HasOne(d => d.ModeleAvion)
                    .WithMany(p => p.CaracteristiqueTechniques)
                    .HasForeignKey(d => d.ModeleAvionId)
                    .HasConstraintName("FK_ModeleAvionID");
            });

            modelBuilder.Entity<ModeleAvion>(entity =>
            {
                entity.Property(e => e.CapacitePassagers).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Marque)
                    .WithMany(p => p.ModeleAvions)
                    .HasForeignKey(d => d.MarqueId)
                    .HasConstraintName("FK_MarqueID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
