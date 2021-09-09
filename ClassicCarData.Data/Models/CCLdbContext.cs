using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClassicCarData.Data.Models
{
    public partial class CCLdbContext : DbContext
    {
        public CCLdbContext()
        {
        }

        public CCLdbContext(DbContextOptions<CCLdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Listing> Listings { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=;User Id=;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.ToTable("Dealer");

                entity.Property(e => e.DealerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DealerUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ListingId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StockNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Listing>(entity =>
            {
                entity.ToTable("Listing");

                entity.Property(e => e.DealerName).HasMaxLength(500);

                entity.Property(e => e.Engine).HasMaxLength(100);

                entity.Property(e => e.ListingId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ListingID");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Make).HasMaxLength(200);

                entity.Property(e => e.Model).HasMaxLength(200);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockNumber).HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Transmission).HasMaxLength(200);

                entity.Property(e => e.Vin).HasMaxLength(100);

                entity.Property(e => e.Year).HasMaxLength(100);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.LogMessage).IsRequired();
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("make");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("value");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("model");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("make");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("value");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("year");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Year");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
