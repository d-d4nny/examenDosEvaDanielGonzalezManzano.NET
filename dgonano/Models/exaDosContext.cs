using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dgonano.Models
{
    public partial class exaDosContext : DbContext
    {
        public exaDosContext()
        {
        }

        public exaDosContext(DbContextOptions<exaDosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Vajilla> Vajillas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=PostgresConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Idreservas)
                    .HasName("reservas_pkey");

                entity.ToTable("reservas", "esqexados");

                entity.Property(e => e.Idreservas)
                    .ValueGeneratedNever()
                    .HasColumnName("idreservas");

                entity.Property(e => e.Fchreserva)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fchreserva");
            });

            modelBuilder.Entity<Vajilla>(entity =>
            {
                entity.HasKey(e => e.Idvajilla)
                    .HasName("vajillas_pkey");

                entity.ToTable("vajillas", "esqexados");

                entity.Property(e => e.Idvajilla).HasColumnName("idvajilla");

                entity.Property(e => e.Cantidadvajilla).HasColumnName("cantidadvajilla");

                entity.Property(e => e.Codigovajilla)
                    .HasMaxLength(255)
                    .HasColumnName("codigovajilla");

                entity.Property(e => e.Descripcionvajilla)
                    .HasMaxLength(255)
                    .HasColumnName("descripcionvajilla");

                entity.Property(e => e.Nombrevajilla)
                    .HasMaxLength(255)
                    .HasColumnName("nombrevajilla");

                entity.HasMany(d => d.Idreservas)
                    .WithMany(p => p.Idvajillas)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelReservaVajilla",
                        l => l.HasOne<Reserva>().WithMany().HasForeignKey("Idreserva").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_rel_reserva_vajilla_idreserva"),
                        r => r.HasOne<Vajilla>().WithMany().HasForeignKey("Idvajilla").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_rel_reserva_vajilla_idvajilla"),
                        j =>
                        {
                            j.HasKey("Idvajilla", "Idreserva").HasName("rel_reserva_vajilla_pkey");

                            j.ToTable("rel_reserva_vajilla", "esqexados");

                            j.IndexerProperty<int>("Idvajilla").HasColumnName("idvajilla");

                            j.IndexerProperty<int>("Idreserva").HasColumnName("idreserva");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
