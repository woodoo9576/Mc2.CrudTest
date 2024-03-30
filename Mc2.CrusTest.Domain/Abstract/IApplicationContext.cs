using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Domain.Abstract
{
    using Entities;
    internal interface IApplicationContext
    {
        DbSet<Customer> Customers { get; set; } 
        Task<int> SaveChanges();
    }
}
