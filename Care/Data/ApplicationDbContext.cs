using Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Care.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor
        //pass the parameeter that will collect the dbContext and pass it to base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //create dbset crate tabe with columns present in property

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }



        //seeding data to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    CatId = "11",
                    CatName = "k",
                    Price = 100,
                    Quantity = 10
                }
                );
        }

    }
}
