using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.API.Data;
using RentalManagement.API.Models;

namespace RentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalAgreementController : ControllerBase
    {
        private readonly RentalContext _context;

        public RentalAgreementController(RentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllRentalAgreements()
        {
            var rentalAgreements = _context.RentalAgreements
                .Include(r => r.Tenant)
                .Include(r => r.Apartment)
                .ToList();

            return Ok(rentalAgreements);
        }

        [HttpGet("{id}")]
        public IActionResult GetRentalAgreementById(int id)
        {
            var rentalAgreement = _context.RentalAgreements
                .Include(r => r.Tenant)
                .Include(r => r.Apartment)
                .FirstOrDefault(t => t.Id == id);

            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return Ok(rentalAgreement);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateRentalAgreement(int id, [FromBody] RentalAgreement updatedRentalAgreement)
        {
            var rentalAgreement = _context.RentalAgreements.FirstOrDefault(r => r.Id == id);

            if (rentalAgreement == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            rentalAgreement.StartDate = updatedRentalAgreement.StartDate;
            rentalAgreement.EndDate = updatedRentalAgreement.EndDate;
            rentalAgreement.MonthlyPayment = updatedRentalAgreement.MonthlyPayment;
            rentalAgreement.Currency = updatedRentalAgreement.Currency;

            _context.SaveChanges();

            return Ok(rentalAgreement);

        }

        [HttpPost]
        public IActionResult AddRentalAgreement([FromBody] RentalAgreement rentalAgreement)
        {
            // Sprawdzimy, czy istnieje Tenant i Apartment
            var tenantExists = _context.Tenants.Any(t =>t.Id == rentalAgreement.TenantId); //było Tenant.Id
            var apartmentExists = _context.Apartments.Any(a => a.Id == rentalAgreement.ApartmentId);//było Apartment.Id

            if(!tenantExists || !apartmentExists)
            {
                return BadRequest("Invalid TenantId or ApartmentId");
            }


            _context.RentalAgreements.Add(rentalAgreement);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllRentalAgreements), new { id = rentalAgreement.Id }, rentalAgreement);
        }
    }
}
