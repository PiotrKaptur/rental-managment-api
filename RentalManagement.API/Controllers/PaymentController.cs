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
                return BadRequest(new { message = "Nieprawidłowy RentalAgreementId." });
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

        [HttpGet("overdue")]
        public IActionResult GetOverduePayments()
        {
            var now = DateTime.Today;
            var monthStart = new DateTime(now.Year, now.Month, 1);
            var nextMonth = monthStart.AddMonths(1);

            var activeAgreements = _context.RentalAgreements
                .Include(r => r.Tenant)
                .Include(r => r.Apartment)
                .Where(r =>
                    r.StartDate <= now &&
                    (r.EndDate == null || r.EndDate >= now))
                .ToList();


            var overdueList = new List<object>(); //tymczasowo jako anonimowy obiekt

            foreach (var agreement in activeAgreements)
            {
                bool hasPayment = _context.Payments.Any(p =>
                p.RentalAgreementId == agreement.Id &&
                p.PaymentDate >= monthStart &&
                p.PaymentDate < nextMonth
                );

                if (!hasPayment)
                {
                    overdueList.Add(new
                    {
                        AgreementId = agreement.Id,
                        Tenant = $"{agreement.Tenant.FirstName} {agreement.Tenant.LastName}",
                        Apartment = agreement.Apartment.Address,
                        Month = $"{monthStart:yyyy-MM}",
                        AmountDue = agreement.MonthlyPayment,
                        Currency = agreement.Currency
                    });
                }
            }

            return Ok(overdueList);
        }
    }
}
