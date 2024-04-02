using Mc2.CrudTest.Application.Features.Queries;

namespace Mc2.CrudTest.Application.Features.Commands;
using Domain.Abstract;
using Domain.Entities;
public class CreateCustomerCommand : IFeatureCommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }
    public long BankAccountNumber { get; set; }

    public class CreateCustomerCommandHandler
    {
        private readonly IApplicationContext _context;

        public CreateCustomerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCustomerCommand request)
        {
            Customer customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber
            };

            _context.Customers.Add(customer);
            await _context.SaveChanges();
            return customer.Id;
        }
    }
}