using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hostelsystem.Models
{
    public class HostelSystemDbContext : DbContext
    {
        public HostelSystemDbContext(DbContextOptions<HostelSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestReservation>()
             .HasKey(gr => new { gr.GuestId, gr.ReservationId });

            modelBuilder.Entity<GuestReservation>()
                .HasOne(gr => gr.Guest)
                .WithMany(r => r.Reservations)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GuestReservation>()
                .HasOne(gr => gr.Reservation)
                .WithMany(g => g.Guests)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
