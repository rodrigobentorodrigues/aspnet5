using Course.Models;
using System.Data.Entity;

namespace Course.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

    }
}