using System;
using CarDealer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.DataAccess
{
    public class CarDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433\\Catalog=CarDB;Database=CarDB;User=sa;Password=reallyStrongPwd#123");
        }

        public DbSet<Car> Cars { get; set; }
    }
}
