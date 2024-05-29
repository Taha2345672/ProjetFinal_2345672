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
        public virtual DbSet<Changelog> Changelogs { get; set; } = null!;
        public virtual DbSet<Marque> Marques { get; set; } = null!;
        public virtual DbSet<ModeleAvion> ModeleAvions { get; set; } = null!;
        public virtual DbSet<Performance> Performances { get; set; } = null!;
        public virtual DbSet<VueNombreAvionsParMarque> VueNombreAvionsParMarques { get; set; } = null!;

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

                entity.Property(e => e.ImageData)
                    .HasColumnName("ImageData")
                    .HasColumnType("varbinary(max)");
            });

            modelBuilder.Entity<CaracteristiqueTechnique>(entity =>
            {
                entity.HasKey(e => e.CaracteristiqueId)
                    .HasName("PK__Caracter__BF68064FC4BCE9A3");

                entity.HasOne(d => d.ModeleAvion)
                    .WithMany(p => p.CaracteristiqueTechniques)
                    .HasForeignKey(d => d.ModeleAvionId)
                    .HasConstraintName("FK_ModeleAvionID");
            });

            modelBuilder.Entity<Changelog>(entity =>
            {
                entity.Property(e => e.InstalledOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ModeleAvion>(entity =>
            {
                entity.Property(e => e.CapacitePassagers).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Marque)
                    .WithMany(p => p.ModeleAvions)
                    .HasForeignKey(d => d.MarqueId)
                    .HasConstraintName("FK_MarqueID");
            });

            modelBuilder.Entity<VueNombreAvionsParMarque>(entity =>
            {
                entity.ToView("Vue_NombreAvionsParMarque");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}