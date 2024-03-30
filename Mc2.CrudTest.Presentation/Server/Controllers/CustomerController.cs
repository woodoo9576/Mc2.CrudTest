using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class CustomerController : ControllerBase
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
