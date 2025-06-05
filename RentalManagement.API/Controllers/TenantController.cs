using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        public IActionResult GetAllTenants()
        {
            var tenants = new List<object>
            {
            new { Id = 1, FirstName = "John", LastName = "Kowalski" },
            new { Id = 2, FirstName = "Adam", LastName = "Nowak" }
            };

            return Ok(tenants);
        }
    }
}
