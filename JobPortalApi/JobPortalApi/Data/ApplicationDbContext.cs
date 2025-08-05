using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Models;

namespace JobPortalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
