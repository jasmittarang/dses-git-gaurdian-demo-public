using Microsoft.EntityFrameworkCore;
using DsesDemoApp.Models;

namespace DsesDemoApp.Data
{
    public class DsesDemoAppContext : DbContext
    {
        public DsesDemoAppContext (DbContextOptions<DsesDemoAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
