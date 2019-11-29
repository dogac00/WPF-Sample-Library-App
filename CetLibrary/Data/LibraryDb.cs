using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CetLibrary.Service;

namespace CetLibrary.Data
{
    public class LibraryDb :DbContext
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CetLibraryDb;Trusted_Connection=True;";
        
        public DbSet<CetUser> CetUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "admin",
                CanChangePassword = true
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "student",
                CanChangePassword = false
            });

            modelBuilder.Entity<CetUser>().HasData(new CetUser
            {
                CreatedDate = DateTime.Now,
                Id = 1,
                Name = "dogac",
                Password = CetUserService.HashPassword("123"),
                RoleId = 1,
                Surname = "akyildiz",
                UserName = "dogac"
            });
        }
    }
}
