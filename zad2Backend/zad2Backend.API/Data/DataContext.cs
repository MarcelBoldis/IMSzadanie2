using Microsoft.EntityFrameworkCore;
using zad2Backend.API.Models;

namespace zad2Backend.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Novinky> Novinky {get; set;}
        public DbSet<Terminy> Terminy {get; set;}
    }
}