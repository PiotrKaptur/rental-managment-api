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
        public IActionResult Get()
        {
            ;
        }
        [HttpPost]
        public IActionResult Post()
        {
            ;
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            ;
        }
    }
}
