using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Domain.DTO;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }


    public virtual DbSet<Gruppa> Gruppas { get; set; }

    public virtual DbSet<Raspisanie> Raspisanies { get; set; }

    public virtual DbSet<Trener> Treners { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("dennedeli", new[] { "пн", "вт", "ср", "чт", "пт", "сб", "вс" });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Nomerabonimenta).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Nomerabonimenta)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nomerabonimenta");
            entity.Property(e => e.Dataroshdenia).HasColumnName("dataroshdenia");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Nashaloabonimenta).HasColumnName("nashaloabonimenta");
            entity.Property(e => e.Okonshanie).HasColumnName("okonshanie");
            entity.Property(e => e.Pol)
                .HasColumnType("character varying")
                .HasColumnName("pol");
            entity.Property(e => e.Rost).HasColumnName("rost");
            entity.Property(e => e.Telephone)
                .HasColumnType("character varying")
                .HasColumnName("telephone");
            entity.Property(e => e.Ves).HasColumnName("ves");
            entity.Property(e => e.Названиеgruppi)
                .HasColumnType("character varying")
                .HasColumnName("названиеgruppi");

            entity.HasOne(d => d.НазваниеgruppiNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Названиеgruppi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_названиеgruppi_fkey");
        });


        modelBuilder.Entity<Gruppa>(entity =>
        {
            entity.HasKey(e => e.Названиеgruppi).HasName("gruppa_pkey");

            entity.ToTable("gruppa");

            entity.Property(e => e.Названиеgruppi)
                .HasColumnType("character varying")
                .HasColumnName("названиеgruppi");
            entity.Property(e => e.Примечание)
                .HasColumnType("character varying")
                .HasColumnName("примечание");
        });

        modelBuilder.Entity<Raspisanie>(entity =>
        {
            entity.HasKey(e => e.Identificatorraspisania).HasName("raspisanie_pkey");

            entity.ToTable("raspisanie");

            entity.Property(e => e.Identificatorraspisania).HasColumnName("identificatorraspisania");
            entity.Property(e => e.Identificatortrener).HasColumnName("identificatortrener");
            entity.Property(e => e.Nachalozanatii).HasColumnName("nachalozanatii");
            entity.Property(e => e.Prodolshitelnost).HasColumnName("prodolshitelnost");
            entity.Property(e => e.Vidzanatii)
                .HasColumnType("character varying")
                .HasColumnName("vidzanatii");
            entity.Property(e => e.Zal)
                .HasColumnType("character varying")
                .HasColumnName("zal");
            entity.Property(e => e.Названиеgruppi)
                .HasColumnType("character varying")
                .HasColumnName("названиеgruppi");

            entity.HasOne(d => d.IdentificatortrenerNavigation).WithMany(p => p.Raspisanies)
                .HasForeignKey(d => d.Identificatortrener)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("raspisanie_identificatortrener_fkey");

            entity.HasOne(d => d.НазваниеgruppiNavigation).WithMany(p => p.Raspisanies)
                .HasForeignKey(d => d.Названиеgruppi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("raspisanie_названиеgruppi_fkey");
        });

        modelBuilder.Entity<Trener>(entity =>
        {
            entity.HasKey(e => e.Identificatortrener).HasName("trener_pkey");

            entity.ToTable("trener");

            entity.Property(e => e.Identificatortrener)
                .UseIdentityAlwaysColumn()
                .HasColumnName("identificatortrener");
            entity.Property(e => e.Dolshnost)
                .HasColumnType("character varying")
                .HasColumnName("dolshnost");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Telephone)
                .HasColumnType("character varying")
                .HasColumnName("telephone");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
