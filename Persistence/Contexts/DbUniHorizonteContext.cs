using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Persistence.Entities;

namespace Persistence.Contexts;

public partial class DbUniHorizonteContext : DbContext {
  public DbUniHorizonteContext() { }

  public DbUniHorizonteContext(DbContextOptions<DbUniHorizonteContext> options) : base(options) { }

  public virtual DbSet<TblCategorium> TblCategoria { get; set; }

  public virtual DbSet<TblEstadoInventario> TblEstadoInventarios { get; set; }

  public virtual DbSet<TblIdioma> TblIdiomas { get; set; }

  public virtual DbSet<TblInventarioLibro> TblInventarioLibros { get; set; }

  public virtual DbSet<TblLibro> TblLibros { get; set; }

  public virtual DbSet<TblLibroCategorium> TblLibroCategoria { get; set; }

  public virtual DbSet<TblLibroIdioma> TblLibroIdiomas { get; set; }

  public virtual DbSet<TblLibroMaterium> TblLibroMateria { get; set; }

  public virtual DbSet<TblLibroPrograma> TblLibroProgramas { get; set; }

  public virtual DbSet<TblMaterium> TblMateria { get; set; }

  public virtual DbSet<TblPrograma> TblProgramas { get; set; }

  public virtual DbSet<TblRol> TblRols { get; set; }

  public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

  public virtual DbSet<TblUsuarioPrograma> TblUsuarioProgramas { get; set; }

  public virtual DbSet<TblUsuarioRole> TblUsuarioRoles { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<TblCategorium>(entity => {
      entity.HasKey(e => e.RowId).HasName("PK_TBL_CATEGORIAS");

      entity.ToTable("TBL_CATEGORIA");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Categoria).HasMaxLength(150);
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblEstadoInventario>(entity => {
      entity.HasKey(e => e.RowId);

      entity.ToTable("TBL_ESTADO_INVENTARIO");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.EstadoNombre).HasMaxLength(255);
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblIdioma>(entity => {
      entity.HasKey(e => e.RowId).HasName("PK_TBL_IDIOMAS");

      entity.ToTable("TBL_IDIOMA");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Idioma).HasMaxLength(150);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblInventarioLibro>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_INVENTARIO_LIBRO");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_INVENTARIO_LIBRO").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdLibro],(200))+'|')+left([RowIdEstadoInventario],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdEstadoInventario).HasMaxLength(450);
      entity.Property(e => e.RowIdLibro).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblLibro>(entity => {
      entity.HasKey(e => e.RowId).HasName("PK_TBL_LIBROS");

      entity.ToTable("TBL_LIBRO");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Autor).HasMaxLength(450);
      entity.Property(e => e.Editorial).HasMaxLength(255);
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.MencionPrimera).HasMaxLength(450);
      entity.Property(e => e.PrimeraEdicion).HasMaxLength(450);
      entity.Property(e => e.RowIdRowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
      entity.Property(e => e.Serie).HasMaxLength(10);
      entity.Property(e => e.Titulo).HasMaxLength(255);
    });

    modelBuilder.Entity<TblLibroCategorium>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_LIBRO_CATEGORIA");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_LIBRO_CATEGORIA").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdLibro],(200))+'|')+left([RowIdCategoria],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdCategoria).HasMaxLength(450);
      entity.Property(e => e.RowIdLibro).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblLibroIdioma>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_LIBRO_IDIOMA");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_LIBRO_IDIOMA").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdLibro],(200))+'|')+left([RowIdIdioma],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdIdioma).HasMaxLength(450);
      entity.Property(e => e.RowIdLibro).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblLibroMaterium>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_LIBRO_MATERIA");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_LIBRO_MATERIA").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdLibro],(200))+'|')+left([RowIdMateria],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdLibro).HasMaxLength(450);
      entity.Property(e => e.RowIdMateria).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblLibroPrograma>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_LIBRO_PROGRAMA");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_LIBRO_PROGRAMA").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdLibro],(200))+'|')+left([RowIdPrograma],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdLibro).HasMaxLength(450);
      entity.Property(e => e.RowIdPrograma).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblMaterium>(entity => {
      entity.HasKey(e => e.RowId).HasName("PK_TBL_MATERIAS");

      entity.ToTable("TBL_MATERIA");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Materia).HasMaxLength(150);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblPrograma>(entity => {
      entity.HasKey(e => e.RowId);

      entity.ToTable("TBL_PROGRAMAS");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Programa).HasMaxLength(150);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblRol>(entity => {
      entity.HasKey(e => e.RowId).HasName("PK_TBL_ROLES");

      entity.ToTable("TBL_ROL");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Nombre).HasMaxLength(20);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblUsuario>(entity => {
      entity.HasKey(e => e.RowId).HasName("PK_TBL_USUARIOS");

      entity.ToTable("TBL_USUARIO");

      entity.Property(e => e.RowId).HasDefaultValueSql("(newid())");
      entity.Property(e => e.Apellido).HasMaxLength(250);
      entity.Property(e => e.Cedula).HasMaxLength(250);
      entity.Property(e => e.Correo).HasMaxLength(250);
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.Nombre).HasMaxLength(250);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
      entity.Property(e => e.Telefono).HasMaxLength(250);
    });

    modelBuilder.Entity<TblUsuarioPrograma>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_USUARIO_PROGRAMA");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_USUARIO_PROGRAMA").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdUsuario],(200))+'|')+left([RowIdPrograma],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdPrograma).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuario).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    modelBuilder.Entity<TblUsuarioRole>(entity => {
      entity
          .HasNoKey()
          .ToTable("TBL_USUARIO_ROLE");

      entity.HasIndex(e => e.Combined, "unq_t_TBL_USUARIO_ROLE").IsUnique();

      entity.Property(e => e.Combined)
          .HasMaxLength(401)
          .HasComputedColumnSql("((left([RowIdUsuario],(200))+'|')+left([RowIdRole],(200)))", false)
          .HasColumnName("combined");
      entity.Property(e => e.Estado)
          .IsRequired()
          .HasDefaultValueSql("(CONVERT([bit],(1)))");
      entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
      entity.Property(e => e.FechaEdicion).HasColumnType("datetime");
      entity.Property(e => e.Id).ValueGeneratedOnAdd();
      entity.Property(e => e.RowIdRole).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuario).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioCreador).HasMaxLength(450);
      entity.Property(e => e.RowIdUsuarioEditor).HasMaxLength(450);
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
