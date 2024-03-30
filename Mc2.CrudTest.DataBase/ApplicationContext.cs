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
        private DbSet<Customer> _customers;

        public DbSet<Customer> Customers
        {
            get => _customers;
            set => _customers = value;
        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
