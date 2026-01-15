using Microsoft.EntityFrameworkCore;
using Projekt_WPF.Models;
using System.IO;

namespace Projekt_WPF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wonder> Wonders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=wonders.db");
        }
    }
}