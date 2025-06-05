using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.API.Data;
using RentalManagement.API.Models;

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

        [HttpPost]
        public IActionResult AddTenant([FromBody] Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllTenants), new { id = tenant.Id }, tenant);
        }
    }
}
