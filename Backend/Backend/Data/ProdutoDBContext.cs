using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class ProdutoDBContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        private static string dbType;
        private static string _connectionString;

        public static void SetDBOptions(string dataBaseType = "", string connectionString = "")
        {
            dbType = dataBaseType;
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(o => new { o.Id });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            switch (dbType.ToLower())
            {
                case "sqlserver":
                    optionsBuilder.UseSqlServer(_connectionString);
                    break;
                case "inmemorydatabase":
                    optionsBuilder.UseInMemoryDatabase("InMemoryDataBaseGameResult");
                    break;
                default:
                    optionsBuilder.UseInMemoryDatabase("InMemoryDataBaseGameResult");
                    break;
            }
        }
    }
}
