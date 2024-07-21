using Microsoft.EntityFrameworkCore;
using Heetapp1.Models;

namespace Heetapp1
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
