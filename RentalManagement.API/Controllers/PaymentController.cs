using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.API.Data;
using RentalManagement.API.Models;

namespace RentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly RentalContext _context;

        public PaymentController(RentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var payments = _context.Payments
                .Include(p => p.RentalAgreement)
                    .ThenInclude(r => r.Tenant)
                .Include(p => p.RentalAgreement)
                    .ThenInclude(r => r.Apartment)
                .ToList();

            return Ok(payments);
        }



        [HttpPost]
        public IActionResult Post([FromBody] Payment payment)
        {
            var agreementExists = _context.RentalAgreements.Any(r => r.Id == payment.RentalAgreementId);

            if (!agreementExists)
            {
                return BadRequest("Nieprawidłowy RentalAgreementId.");
            }

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllPayments), new { id = payment.Id }, payment);
        }




        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);

            if(payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
