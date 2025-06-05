using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.API.Data;

namespace RentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly RentalContext _context;

        public TenantController(RentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTenants()
        {
            var tenants = _context.Tenants.ToList();
            return Ok(tenants);
        }
    }
}
