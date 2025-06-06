﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IActionResult AddRentalAgreement([FromBody] RentalAgreement rentalAgreement)
        {
            // Sprawdzimy, czy istnieje Tenant i Apartment
            var tenantExists = _context.Tenants.Any(t =>t.Id == rentalAgreement.Tenant.Id);
            var apartmentExists = _context.Apartments.Any(a => a.Id == rentalAgreement.Apartment.Id);

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
