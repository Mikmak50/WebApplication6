using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } //A vérifier si nécessaire?

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity(typeof(Ride))
                .HasOne(typeof(Place), "PlaceStart")
                .WithMany()
                .HasForeignKey("PlaceEndId")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
            modelbuilder.Entity(typeof(Ride))
                .HasOne(typeof(Place), "PlaceEnd")
                .WithMany()
                .HasForeignKey("PlaceEndId")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
            //modelbuilder.Entity(typeof(UserCar))
            //    .HasOne(typeof(), "PlaceEnd")
            //    .WithMany()
            //    .HasForeignKey("UserId")
            //    .OnDelete(DeleteBehavior.Restrict); // no ON DELETE;
            //modelbuilder.Entity<UserCar>()
            //.HasKey(c => new { c.UserId, c.CarId });
            modelbuilder.Entity<UserCar>()
        .HasKey(uc => new { uc.UserId, uc.CarId });

            modelbuilder.Entity<UserCar>()
                .HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.UsersCars)
                .HasForeignKey(uc => uc.UserId);


            modelbuilder.Entity<UserCar>()
                .HasOne(uc => uc.Car)
                .WithMany(c => c.UsersCars) // If you add `public ICollection<UserBook> UserBooks { get; set; }` navigation property to Book model class then replace `.WithMany()` with `.WithMany(b => b.UserBooks)`
                .HasForeignKey(uc => uc.CarId);
        }
    }
}
