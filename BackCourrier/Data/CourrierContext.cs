using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackCourrier.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace BackCourrier.Data
{
    public class CourrierContext : DbContext
    {
        public CourrierContext(DbContextOptions<CourrierContext> options)
            : base(options)
        {
        }

        public DbSet<Courriers> Courrier { get; set; } = default!;
        public DbSet<CourrierDestinataire> CourrierDestinataire { get; set; } = default!;
        public DbSet<Coursier> Coursier { get; set; } = default!;
        public DbSet<Destinataire> Destinataire { get; set; } = default!;
        public DbSet<MouvementCourrier> MouvementCourrier { get; set; } = default!;
        public DbSet<Receptioniste> Receptioniste { get; set; } = default!;
        public DbSet<Status> Status { get; set; } = default!;

        public DbSet<Flag> Flag { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Courriers>().ToTable("Courrier");
            modelBuilder.Entity<CourrierDestinataire>().ToTable("CourrierDestinataire");
            modelBuilder.Entity<Coursier>().ToTable("Coursier");
            modelBuilder.Entity<Destinataire>().ToTable("Destinataire");
            modelBuilder.Entity<MouvementCourrier>().ToTable("MouvementCourrier");
            modelBuilder.Entity<Receptioniste>().ToTable("Receptioniste");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Flag>().ToTable("Flag");
        }

    }
}
