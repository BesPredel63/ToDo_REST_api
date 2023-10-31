using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using ToDo_REST_api.Models;

namespace ToDo_REST_api.AppDb {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Goal> Goals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connString = config.GetConnectionString("MySQLConnection");
            optionsBuilder.UseMySQL(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Title = "Семья", Color = "#0000FF" },
                    new Category { Id = 2, Title = "Работа", Color = "#FF0000" },
                    new Category { Id = 3, Title = "Хобби", Color = "#00FF00" },
                    new Category { Id = 4, Title = "Гараж", Color = "#0080C0" },
                    new Category { Id = 5, Title = "Авто", Color = "#FF8000" }
                );
            modelBuilder.Entity<Goal>().HasData(
                    new Goal { Id = 1, Title = "Убраться в гараже", ExecuteDate = new DateTime(2023, 10, 19), Description = "Выкинуть хлам из погреба в гараже", IsActive = true, CategoryId = 4 },
                    new Goal { Id = 2, Title = "Пройти ТО", ExecuteDate = new DateTime(2023, 10, 02), Description = "Заменить масло в моторе, поменять фильтра", IsActive = true, CategoryId = 5 },
                    new Goal { Id = 3, Title = "Купить билеты в кино", ExecuteDate = new DateTime(2023, 10, 28), Description = "Сходить в кино с женой", IsActive = true, CategoryId = 1 }
                );
        }
    }
}
