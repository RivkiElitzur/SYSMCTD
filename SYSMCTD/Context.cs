using Microsoft.EntityFrameworkCore;
using SYSMCTD.Models;

namespace SYSMCTD
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Addresses> Addresses { get; set; }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

    }
}
