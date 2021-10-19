using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace backSisInvestigacion.Models
{
    public partial class bddSisInvestigacionContext : DbContext
    {
        public bddSisInvestigacionContext()
        {
        }

        public bddSisInvestigacionContext(DbContextOptions<bddSisInvestigacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<Facultad> Facultads { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<RegistroInvestigacion> RegistroInvestigacions { get; set; }
        public virtual DbSet<TipoInvestigacion> TipoInvestigacions { get; set; }
        public virtual DbSet<TrabInvestigacion> TrabInvestigacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=JAV05JLINFVSOTO;Database=bddSisInvestigacion;trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Idespecialidad);

                entity.ToTable("especialidad");

                entity.Property(e => e.Idespecialidad).HasColumnName("idespecialidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);

                entity.Property(e => e.Idfacultad).HasColumnName("idfacultad");

                entity.HasOne(d => d.IdfacultadNavigation)
                    .WithMany(p => p.Especialidads)
                    .HasForeignKey(d => d.Idfacultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_especialidad_facultad");
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.HasKey(e => e.Idfacultad);

                entity.ToTable("facultad");

                entity.Property(e => e.Idfacultad).HasColumnName("idfacultad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Idpersona);

                entity.ToTable("persona");

                entity.Property(e => e.Idpersona).HasColumnName("idpersona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("apellido")
                    .IsFixedLength(true);

                entity.Property(e => e.Correo)
                    .HasMaxLength(35)
                    .HasColumnName("correo")
                    .IsFixedLength(true);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RegistroInvestigacion>(entity =>
            {
                entity.HasKey(e => e.Idetapainv);

                entity.ToTable("registro_investigacion");

                entity.Property(e => e.Idetapainv)
                    .ValueGeneratedNever()
                    .HasColumnName("idetapainv");

                entity.Property(e => e.Etapa).HasColumnName("etapa");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdtipoInv).HasColumnName("idtipo_inv");

                entity.Property(e => e.IdtrabInvestigacion).HasColumnName("idtrab_investigacion");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .HasColumnName("observaciones")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdtrabInvestigacionNavigation)
                    .WithMany(p => p.RegistroInvestigacions)
                    .HasForeignKey(d => d.IdtrabInvestigacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_investigacion_trab_investigacion");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.RegistroInvestigacions)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_investigacion_usuario");
            });

            modelBuilder.Entity<TipoInvestigacion>(entity =>
            {
                entity.HasKey(e => e.IdtipoInv);

                entity.ToTable("tipo_investigacion");

                entity.Property(e => e.IdtipoInv).HasColumnName("idtipo_inv");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descripcion")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TrabInvestigacion>(entity =>
            {
                entity.HasKey(e => e.IdtrabInvestigacion)
                    .HasName("PK_reg_investigacion");

                entity.ToTable("trab_investigacion");

                entity.Property(e => e.IdtrabInvestigacion).HasColumnName("idtrab_investigacion");

                entity.Property(e => e.Etapa).HasColumnName("etapa");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idasesor).HasColumnName("idasesor");

                entity.Property(e => e.IdtipoInv).HasColumnName("idtipo_inv");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("titulo")
                    .IsFixedLength(true);

                entity.Property(e => e.UrlInv)
                    .HasMaxLength(400)
                    .HasColumnName("url_inv")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdasesorNavigation)
                    .WithMany(p => p.TrabInvestigacionIdasesorNavigations)
                    .HasForeignKey(d => d.Idasesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trab_investigacion_usuario1");

                entity.HasOne(d => d.IdtipoInvNavigation)
                    .WithMany(p => p.TrabInvestigacions)
                    .HasForeignKey(d => d.IdtipoInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trab_investigacion_tipo_investigacion");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TrabInvestigacionIdusuarioNavigations)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trab_investigacion_usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("usuario");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idespecialidad).HasColumnName("idespecialidad");

                entity.Property(e => e.Idpersona).HasColumnName("idpersona");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.HasOne(d => d.IdespecialidadNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idespecialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_especialidad");

                entity.HasOne(d => d.IdpersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idpersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
