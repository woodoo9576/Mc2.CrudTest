using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Abstract;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.DataBase
{
    internal class ApplicationContext : DbContext,IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=:memory:");
        }



        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Customer>().HasKey(x => x.Id);
            m.Entity<Customer>().HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();


        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
