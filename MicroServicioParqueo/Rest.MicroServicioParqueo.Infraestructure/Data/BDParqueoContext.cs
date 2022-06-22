using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rest.MicroServicioParqueo.Dominio.Entidades;

#nullable disable

namespace Rest.MicroServicioParqueo.Infraestructure.Data
{
    public partial class BDParqueoContext : DbContext
    {
        public BDParqueoContext()
        {
        }

        public BDParqueoContext(DbContextOptions<BDParqueoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__FC851A3A960BC5EE");

                entity.ToTable("Pago");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Pago__IdPersona__7C4F7684");

                entity.HasOne(d => d.IdTicketNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdTicket)
                    .HasConstraintName("FK__Pago__IdTicket__7B5B524B");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PK__Parametr__37B016F47B34C46E");

                entity.ToTable("Parametro");

                entity.Property(e => e.Tarifa).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.TipoVehiculo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadTiempo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__2EC8D2AC36681EFF");

                entity.ToTable("Persona");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK__Ticket__4B93C7E752CDF92B");

                entity.ToTable("Ticket");

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__7086121504B9F15A");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVehiculo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Vehiculo__IdPers__76969D2E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
