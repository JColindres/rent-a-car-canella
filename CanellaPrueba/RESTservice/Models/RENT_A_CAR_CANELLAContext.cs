using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RESTservice.Models
{
    public partial class RENT_A_CAR_CANELLAContext : DbContext
    {
        public RENT_A_CAR_CANELLAContext()
        {
        }

        public RENT_A_CAR_CANELLAContext(DbContextOptions<RENT_A_CAR_CANELLAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencium> Agencia { get; set; } = null!;
        public virtual DbSet<Garaje> Garajes { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-JFDH9S4\\SQLEXPRESS; Database=RENT_A_CAR_CANELLA; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencium>(entity =>
            {
                entity.HasKey(e => e.IdAgencia)
                    .HasName("PK__AGENCIA__43F3B224BE6BDA6C");

                entity.ToTable("AGENCIA");

                entity.Property(e => e.IdAgencia).HasColumnName("ID_AGENCIA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Garaje>(entity =>
            {
                entity.HasKey(e => e.IdGaraje)
                    .HasName("PK__GARAJE__164E55C77C1080B5");

                entity.ToTable("GARAJE");

                entity.Property(e => e.IdGaraje).HasColumnName("ID_GARAJE");

                entity.Property(e => e.AgenciaIdAgencia).HasColumnName("AGENCIA_ID_AGENCIA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.AgenciaIdAgenciaNavigation)
                    .WithMany(p => p.Garajes)
                    .HasForeignKey(d => d.AgenciaIdAgencia)
                    .HasConstraintName("FK__GARAJE__AGENCIA___38996AB5");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__RESERVA__1ED54AE3B1C33E63");

                entity.ToTable("RESERVA");

                entity.Property(e => e.IdReserva).HasColumnName("ID_RESERVA");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_DEVOLUCION");

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_PRESTAMO");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.UsuarioIdUsuario).HasColumnName("USUARIO_ID_USUARIO");

                entity.Property(e => e.VehiculoIdVehiculo).HasColumnName("VEHICULO_ID_VEHICULO");

                entity.HasOne(d => d.UsuarioIdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.UsuarioIdUsuario)
                    .HasConstraintName("FK__RESERVA__USUARIO__4316F928");

                entity.HasOne(d => d.VehiculoIdVehiculoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.VehiculoIdVehiculo)
                    .HasConstraintName("FK__RESERVA__VEHICUL__440B1D61");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTu)
                    .HasName("PK__TIPO_USU__8B63B1A33826CEE5");

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTu).HasColumnName("ID_TU");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__91136B90DDE2C09E");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENIA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.TuIdTu).HasColumnName("TU_ID_TU");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");

                entity.HasOne(d => d.TuIdTuNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TuIdTu)
                    .HasConstraintName("FK__USUARIO__TU_ID_T__403A8C7D");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__VEHICULO__F685B1DFCC2564EC");

                entity.ToTable("VEHICULO");

                entity.Property(e => e.IdVehiculo).HasColumnName("ID_VEHICULO");

                entity.Property(e => e.Alquiler)
                    .HasColumnType("money")
                    .HasColumnName("ALQUILER");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLOR");

                entity.Property(e => e.GarajeIdGaraje).HasColumnName("GARAJE_ID_GARAJE");

                entity.Property(e => e.Marca)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARCA");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MATRICULA");

                entity.HasOne(d => d.GarajeIdGarajeNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.GarajeIdGaraje)
                    .HasConstraintName("FK__VEHICULO__GARAJE__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
