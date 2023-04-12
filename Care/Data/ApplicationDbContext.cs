using Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Care.Data
{
    public class ApplicationDbContext:DbContext
    {
        //constructor
        //pass the parameeter that will collect the dbContext and pass it to base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        //create dbset crate tabe with columns present in property

        public DbSet<Models.Category> Categories { get; set; }
        
    }
}
