using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Library
{
    public class DatabaseContext : DbContext
    {
        public DbSet<GenreData> Genres { get; set; }
        public DbSet<BookData> Books { get; set; }
        private string _dbPath => Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "database.db");

        public DatabaseContext()
        {
            if (!File.Exists(_dbPath))
            {
                Database.EnsureCreatedAsync();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}