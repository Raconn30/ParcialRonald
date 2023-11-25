using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITCMECANICOS.Models;

public partial class ItcmecanicosContext : DbContext
{
    public ItcmecanicosContext()
    {
    }

    public ItcmecanicosContext(DbContextOptions<ItcmecanicosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Mecanico> Mecanicos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8A4S6J7; Database=ITCMECANICOS; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F48CA11B2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Mecanico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mecanico__3213E83FDB93F5AE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3213E83F4F4B3581");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("placa");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculos__clien__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
