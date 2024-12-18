using Microsoft.EntityFrameworkCore;
using MoneyMeLoanAPI.Models;

namespace MoneyMeLoanAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Application> Applications { get; set; }
    }
}
