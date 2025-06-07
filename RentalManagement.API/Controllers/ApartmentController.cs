using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.API.Data;
using RentalManagement.API.Models;
using SQLitePCL;

namespace RentalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {

        private readonly RentalContext _context;

        public ApartmentController(RentalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllApartments()
        {
            var apartments = _context.Apartments.ToList();
            return Ok(apartments);
        }

        [HttpPost]
        public IActionResult AddApartment([FromBody] Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllApartments), new { id = apartment.Id }, apartment);
        }
    }
}
