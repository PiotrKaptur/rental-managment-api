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

        [HttpGet("{id}")]
        public IActionResult GetTenantById(int id)
        {
            var tenant = _context.Tenants.FirstOrDefault(t => t.Id == id);

            if(tenant == null)
            {
                return NotFound();
            }
            return Ok(tenant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTenant(int id, [FromBody] Tenant updatedTenant)
        {
            var tenant = _context.Tenants.FirstOrDefault(t => t.Id == id);

            if (tenant == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            tenant.FirstName = updatedTenant.FirstName;
            tenant.LastName = updatedTenant.LastName;
            tenant.PhoneNumber = updatedTenant.PhoneNumber;
            tenant.Email = updatedTenant.Email;

            _context.SaveChanges();


            //204 No Content = OK, ale bez zwracania treści.
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTenant(int id)
        {
            var tenant = _context.Tenants.FirstOrDefault(t => t.Id == id);

            if(tenant == null)
            {
                return NotFound();
            }

            // Usuwanie rekordu z bazy
            _context.Tenants.Remove(tenant);
            _context.SaveChanges();

            return NoContent(); // 204 No Content
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
