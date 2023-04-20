using Microsoft.EntityFrameworkCore;
using Paharamacyapi.Models;

namespace Paharamacyapi.Data
{
    public class PharamaAPIDbContext : DbContext
    {
        public PharamaAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Drugs> drug { get; set; }
        public DbSet<Order> orders { get; set; }

    }
}
