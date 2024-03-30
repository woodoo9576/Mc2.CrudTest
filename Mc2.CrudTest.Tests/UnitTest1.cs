using FluentAssertions;
using Mc2.CrudTest.Application.Features.Commands;
using Mc2.CrudTest.Application.Features.Queries;
using Mc2.CrudTest.Domain.Abstract;
using Mc2.CrudTest.Domain.Entities;


namespace Mc2.CrudTest.Tests
{
    public class Tests
    {
        private IApplicationContext beforeTestSetupContext(Action<IApplicationContext> action = null)
        {
            var applicationContext = (new ApplicationContextBuilder()).CreateContextForSqLite();
            action?.Invoke(applicationContext);
            return applicationContext;
        }

        [Test]
        public async Task GetAllProductsShouldReturnListOfProductsThatHaveOneProduct()
        {
            var context = beforeTestSetupContext(async applicationContext =>
            {
                applicationContext.Customers.Add(new Customer()
                {
                    FirstName = "First",
                    LastName = "Last",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = 5445320017,
                    Email = "abc@xyz.co",
                    BankAccountNumber = 1234567890
                });
                await applicationContext.SaveChanges();
            });
            var query = new GetAllCustomersQuery();
            var handler = new GetAllCustomersQuery.GetAllCustomersQueryHandler(context);

            var list = await handler.Handle(query);
            list.Should().HaveCount(1);
        }

        [Test]
        public async Task CreateCustomerHandlerShouldCreateProduct()
        {
            var context = beforeTestSetupContext();
            var command = new CreateCustomerCommand()
            {
                FirstName = "First",
                LastName = "Last",
                DateOfBirth = DateTime.Today,
                PhoneNumber = 5445320017,
                Email = "abc@xyz.co",
                BankAccountNumber = 1234567890
            };
            var handler = new CreateCustomerCommand.CreateCustomerCommandHandler(context);

            var newProductId = await handler.Handle(command);
            newProductId.Should().Be(1);
        }
    }
}