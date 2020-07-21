using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HousingWebsite.Models
{
    public partial class RentalWebsiteContext : DbContext
    {
        public RentalWebsiteContext()
        {
        }

        public RentalWebsiteContext(DbContextOptions<RentalWebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PropertiesForRent> PropertiesForRent { get; set; }
        public virtual DbSet<Property> Property { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                        .AddJsonFile("appsettings.json")
                                                        .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("HousingDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertiesForRent>(entity =>
            {
                entity.HasKey(e => e.RentalId)
                    .HasName("PK__Properti__97005943785D46AC");

                entity.Property(e => e.PricePcm).HasColumnName("PricePCM");

                entity.Property(e => e.PropertyAvailableFrom).HasColumnType("datetime");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertiesForRent)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Propertie__Prope__32E0915F");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BuildDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Epcrating)
                    .HasColumnName("EPCRating")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhotoRef)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
