using HomeManagerApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManagerApi.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Compra> Compras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=HomeManager;Integrated Security=true";
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(connectionString,
                 p => p.EnableRetryOnFailure(
                     maxRetryCount: 2,
                     maxRetryDelay: TimeSpan.FromSeconds(5),
                     errorNumbersToAdd: null).MigrationsHistoryTable("home_manager_history"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
