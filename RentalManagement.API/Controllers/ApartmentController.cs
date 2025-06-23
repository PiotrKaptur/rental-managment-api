using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.API.Data;
using RentalManagement.API.Models;

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



        /// <summary>
        /// Zwraca listę wszystkich mieszkań.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllApartments()
        {
            var apartments = _context.Apartments.ToList();
            return Ok(apartments);
        }



        /// <summary>
        /// Aktualizuje dane mieszkania.
        /// </summary>
        /// <param name="id">Identyfikator mieszkania</param>
        /// <param name="updatedApartment">Zaktualizowane dane mieszkania</param>
        [HttpPut("{id}")]
        public IActionResult UpdateApartment(int id, [FromBody] Apartment updatedApartment)
        {
            var apartment = _context.Apartments.FirstOrDefault(t => t.Id == id);

            if(apartment == null)
            {
                return NotFound();
            }

            // Aktualizacja pól
            apartment.Address = updatedApartment.Address;
            apartment.Floor = updatedApartment.Floor;
            apartment.RoomCount = updatedApartment.RoomCount;
            apartment.RentAmount = updatedApartment.RentAmount;

            // Zapisanie zmian w bazie danych
            _context.SaveChanges();
            return Ok(apartment);
        }



        /// <summary>
        /// Usuwa mieszkanie o podanym identyfikatorze.
        /// </summary>
        /// <param name="id">Identyfikator mieszkania</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteApartment(int id)
        {
            var apartment = _context.Apartments.FirstOrDefault(t => t.Id == id);

            if(apartment == null)
            {
                return NotFound();
            }

            // Usuwanie rekordu z bazy
            _context.Apartments.Remove(apartment);
            _context.SaveChanges();

            return NoContent(); // 204 No Content - standard dla DELETE (REST API)
        }



        /// <summary>
        /// Dodaje nowe mieszkanie do systemu.
        /// </summary>
        /// <param name="apartment">Obiekt mieszkania do dodania</param>
        [HttpPost]
        public IActionResult AddApartment([FromBody] Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllApartments), new { id = apartment.Id }, apartment);
        }
    }
}
