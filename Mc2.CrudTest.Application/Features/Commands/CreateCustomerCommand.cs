using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Features.Queries;
using Mc2.CrudTest.Domain.Abstract;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Features.Commands
{
    public class CreateCustomerCommand : IFeatureCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
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
                var customer = new Customer
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
    
}
