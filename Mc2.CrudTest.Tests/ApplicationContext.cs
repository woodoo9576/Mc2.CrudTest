using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Tests
{
    using Domain.Abstract;
    using Domain.Entities;
    internal class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers
        {
            get;
            set;
        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
