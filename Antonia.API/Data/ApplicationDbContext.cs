using Microsoft.EntityFrameworkCore;
using Antonia.API.Models;
using System.Linq;
using System.Text.Json.Serialization;

namespace Antonia.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Necesitado> Necesitados { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<VoluntarioRol> VoluntarioRoles { get; set; }
        public DbSet<Cartera> Carteras { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Email).IsRequired().HasColumnType("varchar(100)");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Password).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Tipo).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.TipoDocumento).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.DocumentoIdentidad).IsRequired().HasColumnType("varchar(50)");
                entity.HasIndex(e => e.DocumentoIdentidad).IsUnique();
                entity.Property(e => e.Telefono).IsRequired().HasColumnType("varchar(20)");
                entity.HasIndex(e => e.Telefono);
                entity.Property(e => e.FechaAlta).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ProvinciaId).IsRequired(false);

                // Relaciones
                entity.HasOne(e => e.Provincia)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(e => e.ProvinciaId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relaciones uno a uno
                entity.HasOne(e => e.Voluntario)
                    .WithOne(v => v.Usuario)
                    .HasForeignKey<Voluntario>(v => v.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Necesitado)
                    .WithOne(n => n.Usuario)
                    .HasForeignKey<Necesitado>(n => n.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurar Voluntario
            modelBuilder.Entity<Voluntario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Disponibilidad).HasDefaultValue(true);
                entity.Property(e => e.AceptaEmergencias).HasDefaultValue(false);
                entity.Property(e => e.TieneVehiculo).HasDefaultValue(false);
                entity.Property(e => e.PuedeLlamar).HasDefaultValue(false);
                entity.Property(e => e.UsuarioId).IsRequired();

                entity.HasMany(e => e.VoluntarioRoles)
                    .WithOne(vr => vr.Voluntario)
                    .HasForeignKey(vr => vr.VoluntarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurar Necesitado
            modelBuilder.Entity<Necesitado>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UsuarioId).IsRequired();

                entity.HasOne(e => e.Cartera)
                    .WithOne(c => c.Necesitado)
                    .HasForeignKey<Cartera>(c => c.NecesitadoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurar Tarea
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Titulo).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Estado).HasDefaultValue("Pendiente").HasColumnType("varchar(50)");
                entity.Property(e => e.Prioridad).HasDefaultValue("Normal").HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.FechaActualizacion).HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.ProvinciaId).IsRequired();
                entity.Property(e => e.RolId).IsRequired();
                entity.Property(e => e.CreadoPorId).IsRequired();
                entity.Property(e => e.AsignadoAId).IsRequired(false);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Tareas)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Provincia)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(e => e.ProvinciaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Rol)
                    .WithMany(r => r.Tareas)
                    .HasForeignKey(e => e.RolId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreadoPor)
                    .WithMany(n => n.TareasCreadas)
                    .HasForeignKey(e => e.CreadoPorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AsignadoA)
                    .WithMany(v => v.TareasAsignadas)
                    .HasForeignKey(e => e.AsignadoAId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configurar Cartera
            modelBuilder.Entity<Cartera>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Saldo).HasDefaultValue(0).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Estado).HasDefaultValue("Activa").HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.NecesitadoId).IsRequired();

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Carteras)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configurar Notificacion
            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Titulo).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Mensaje).IsRequired().HasColumnType("text");
                entity.Property(e => e.Leida).HasDefaultValue(false);
                entity.Property(e => e.Tipo).HasDefaultValue("General").HasColumnType("varchar(50)");
                entity.Property(e => e.Prioridad).HasDefaultValue("Normal").HasColumnType("varchar(50)");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.TareaId).IsRequired(false);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.Notificaciones)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Tarea)
                    .WithMany(t => t.Notificaciones)
                    .HasForeignKey(e => e.TareaId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurar Provincia
            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.CodigoPostal).IsRequired().HasColumnType("varchar(10)");
                entity.Property(e => e.Activa).HasDefaultValue(true);
                entity.HasIndex(e => e.CodigoPostal).IsUnique();
            });

            // Configurar Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasColumnType("varchar(50)");
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.HasIndex(e => e.Nombre).IsUnique();
            });

            // Configurar VoluntarioRol
            modelBuilder.Entity<VoluntarioRol>(entity =>
            {
                entity.HasKey(e => new { e.VoluntarioId, e.RolId });
                entity.Property(e => e.Activo).HasDefaultValue(true);
                entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(e => e.Rol)
                    .WithMany(r => r.VoluntarioRoles)
                    .HasForeignKey(e => e.RolId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurar strings para MySQL
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var stringProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(string));
                foreach (var property in stringProperties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("varchar(255)");
                }
            }
        }
    }
} 