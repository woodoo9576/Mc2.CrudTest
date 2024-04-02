using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Features.Queries;
using Domain.Abstract;
using Domain.Entities;
public class GetAllCustomersQuery : IFeatureCommand
{
    public class GetAllCustomersQueryHandler
    {
        private readonly IApplicationContext _context;

        public GetAllCustomersQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>?> Handle(GetAllCustomersQuery request)
        {
            List<Customer> customerList = await _context.Customers.ToListAsync();
            return customerList.AsReadOnly();
        }
    }
}

public interface IFeatureCommand
{
}