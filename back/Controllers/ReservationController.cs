using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hostelsystem.Models;
using Hostelsystem.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hostelsystem.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IDataRepository<Reservation> dataRepository;

        public ReservationController(IDataRepository<Reservation> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<object> reservations = dataRepository.GetAll();
            return Ok(reservations);
        }
        
        [HttpGet("filtered")]
        public IActionResult GetFiltered([FromQuery] string name, [FromQuery] string city)
        {
            IEnumerable<object> reservations = dataRepository.GetFiltered(new Filter(){ Name = name, City = city });
            return Ok(reservations);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Reservation is null.");
            }
            
            dataRepository.Add(reservation);

            return CreatedAtRoute(
                  "Get",
                  new { Id = reservation.ReservationId },
                  reservation);
        }

    }
}
