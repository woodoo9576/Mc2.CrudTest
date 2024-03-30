using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Abstract;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Features.Queries
{
    internal class GetAllCustomersQuery : IFeatureCommand
    {
        public class GetAllProductsQueryHandler
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Customer>?> Handle(GetAllCustomersQuery request)
            {
                var customerList =  await _context.Customers.ToListAsync();
                return customerList?.AsReadOnly();
            }
        }
    }

    public interface IFeatureCommand
    {
    }
}
