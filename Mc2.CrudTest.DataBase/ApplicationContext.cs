using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.DataBase;
using Domain.Abstract;
using Domain.Entities;
public class ApplicationContext : DbContext, IApplicationContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    /// <inheritdoc />
    public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=:memory:");
    }

    protected override void OnModelCreating(ModelBuilder m)
    {
        m.Entity<Customer>().HasKey(x => x.Id);

        // ReSharper disable once InvalidXmlDocComment
        /// Code-First Multi Column Unique Index 
        m.Entity<Customer>().HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
    }
}