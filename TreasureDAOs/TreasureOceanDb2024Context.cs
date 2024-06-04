using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TreasureBO;

namespace TreasureDAOs;

public partial class TreasureOceanDb2024Context : DbContext
{
    public TreasureOceanDb2024Context()
    {
    }

    public TreasureOceanDb2024Context(DbContextOptions<TreasureOceanDb2024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<SeaArea> SeaAreas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=Password1@;Database=TreasureOceanDB2024;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.Property(e => e.UserName).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Capital).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SeaArea>(entity =>
        {
            entity.HasKey(e => e.SeaId);

            entity.Property(e => e.SeaId).HasColumnName("SeaID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.SeaName).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Country).WithMany(p => p.SeaAreas)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_SeaAreas_Country");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
