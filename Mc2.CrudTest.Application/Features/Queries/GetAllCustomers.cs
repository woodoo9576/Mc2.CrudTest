using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Features.Queries
{
    using Domain.Abstract;
    using Domain.Entities;

    public class GetAllCustomersQuery
    {
        // Query parameters can be added here if needed
    }

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

    // A simple dispatcher to handle queries
    public class QueryDispatcher
    {
        private readonly IApplicationContext _context;

        public QueryDispatcher(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>?> Dispatch(GetAllCustomersQuery query)
        {
            var handler = new GetAllCustomersQueryHandler(_context);
            return await handler.Handle(query);
        }
    }
}

/*
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
public interface IQueryHandler<in TRequest, TResult>
{
    Task<TResult> Handle(TRequest request, CancellationToken cancellation);
}
public interface IQueryDispatcher
{
    Task<TResult> Dispatch<TRequest, TResult>(TRequest request, CancellationToken cancellation);
}


public interface IFeatureCommand
{
}
*/