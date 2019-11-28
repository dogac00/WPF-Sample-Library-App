using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CetLibrary.Service;

namespace CetLibrary.Data
{
    public class LibraryDb :DbContext
    {
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CetLibrary;Trusted_Connection=True;";
        
        public DbSet<CetUser> CetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
