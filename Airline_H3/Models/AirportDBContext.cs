using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Airline_H3.Models
{
    public partial class AirportDBContext : DbContext
    {
        public AirportDBContext()
        {
        }

        public AirportDBContext(DbContextOptions<AirportDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airplain> Airplains { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<FlightRoute> FlightRoutes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ZBC-EMA-UDL2310;Database=AirportDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Airplain>(entity =>
            {
                entity.ToTable("Airplain");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Airlineid).HasColumnName("airlineid");

                entity.Property(e => e.AirplainName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.Airplains)
                    .HasForeignKey(d => d.Airlineid)
                    .HasConstraintName("FK__Airplain__airlin__286302EC");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("Airport");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AirportName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Iata)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("IATA");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlightRoute>(entity =>
            {
                entity.ToTable("FlightRoute");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Airplain)
                    .WithMany(p => p.FlightRoutes)
                    .HasForeignKey(d => d.AirplainId)
                    .HasConstraintName("FK__FlightRou__Airpl__2F10007B");

                entity.HasOne(d => d.FromDestAirportNavigation)
                    .WithMany(p => p.FlightRouteFromDestAirportNavigations)
                    .HasForeignKey(d => d.FromDestAirport)
                    .HasConstraintName("FK__FlightRou__FromD__2D27B809");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.FlightRouteOperators)
                    .HasForeignKey(d => d.Operatorid)
                    .HasConstraintName("FK__FlightRou__Opera__2C3393D0");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.FlightRouteOwners)
                    .HasForeignKey(d => d.Ownerid)
                    .HasConstraintName("FK__FlightRou__Owner__2B3F6F97");

                entity.HasOne(d => d.ToDestAirportNavigation)
                    .WithMany(p => p.FlightRouteToDestAirportNavigations)
                    .HasForeignKey(d => d.ToDestAirport)
                    .HasConstraintName("FK__FlightRou__ToDes__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
