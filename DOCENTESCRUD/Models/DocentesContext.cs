using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DOCENTESCRUD.Models;

public partial class DocentesContext : DbContext
{
    public DocentesContext()
    {
    }

    public DocentesContext(DbContextOptions<DocentesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=CESAR-DAVID-MIL\\SQLEXPRESS; DataBase=Docentes;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__Docentes__595F5B9C7C8C05D2");

            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Municipio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupos__EC597A8708723987");

            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.IdDocente).HasColumnName("idDocente");
            entity.Property(e => e.IdModulo).HasColumnName("idModulo");
            entity.Property(e => e.Jornada)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("FK__Grupos__idDocent__3B75D760");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK__Grupos__idModulo__3A81B327");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__Modulos__3CE613FADAE94E25");

            entity.Property(e => e.IdModulo).HasColumnName("idModulo");
            entity.Property(e => e.NombreModulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Programa)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
