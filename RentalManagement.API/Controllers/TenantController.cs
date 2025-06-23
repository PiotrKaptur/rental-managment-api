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



        /// <summary>
        /// Zwraca listę wszystkich najemców.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllTenants()
        {
            var tenants = _context.Tenants.ToList();
            return Ok(tenants);
        }

        /// <summary>
        /// Zwraca szczegóły konkretnego najemcy na podtsawie identyfikatora
        /// </summary>
        /// <param name="id">Identyfikator najemcy</param>
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



        /// <summary>
        /// Aktualizuje dane najemcy.
        /// </summary>
        /// <param name="id">Identyfikator najemcy</param>
        /// <param name="updatedTenant">Zaktualizowane dane najemcy</param>
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



        /// <summary>
        /// Usuwa najemcę o podanym identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator najemcy</param>
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



        /// <summary>
        /// Dodaje nowego najemcę do systemu.
        /// </summary>
        /// <param name="tenant">Obiekt najemcy do dodania</param>
        [HttpPost]
        public IActionResult AddTenant([FromBody] Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTenantById), new { id = tenant.Id }, tenant);
        }
    }
}
