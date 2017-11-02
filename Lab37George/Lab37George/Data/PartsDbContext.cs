using Lab37George.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab37George.Data
{
    public class PartsDbContext : DbContext
    {
        // inherits db context into this particular context
        public PartsDbContext(DbContextOptions<PartsDbContext> options) : base(options)
        {

        }
        // reference to our model where the fields are contained
        public DbSet<Parts> Parts { get; set; }
    }
}
