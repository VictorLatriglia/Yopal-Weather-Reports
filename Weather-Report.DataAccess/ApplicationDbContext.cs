using Microsoft.EntityFrameworkCore;
using Weather_Report.Models;

namespace Weather_Report.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Station> Stations { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }
    }
}
