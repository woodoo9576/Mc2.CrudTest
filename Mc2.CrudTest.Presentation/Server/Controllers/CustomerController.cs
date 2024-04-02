using Microsoft.AspNetCore.Mvc;


namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    using Application.Features.Commands;
    using Application.Features.Queries;
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CreateCustomerCommand.CreateCustomerCommandHandler _createCustomerCommandHandler;
        private readonly GetAllCustomersQuery.GetAllCustomersQueryHandler _getAllCustomersQueryHandler;

        public CustomerController(CreateCustomerCommand.CreateCustomerCommandHandler createCustomerCommandHandler, GetAllCustomersQuery.GetAllCustomersQueryHandler getAllCustomersQueryHandler)
        {
            _createCustomerCommandHandler = createCustomerCommandHandler;
            _getAllCustomersQueryHandler = getAllCustomersQueryHandler;
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand request)
        {
            if(ModelState.IsValid)
            {
               return Ok(await _createCustomerCommandHandler.Handle(request));
            }
            return BadRequest(modelState:ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _getAllCustomersQueryHandler.Handle(new GetAllCustomersQuery()));
        }
    }
}
