using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace TableReservation.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class ReservationController : ControllerBase
    {
        private IReservationService service;

        public ReservationController(IReservationService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<ReservationDto> GetResrevationById(int id)
        {
            var reservation = service.GetReservationById(id);

            return Ok(reservation);
        }

        [HttpPost("CreateReservation")]
        public ActionResult<ReservationDto> CreateReservation(ReservationDto reservation)
        {

            reservation = service.AddReservation(reservation);

            if(reservation == null)
            {
                //204
                NoContent();
            }
            //201
            return Created("", reservation);
        }

        [HttpPut("UpdateReservation")]
        public ActionResult<ReservationDto> UpdateReservation(ReservationDto reservation)
        {
            return NoContent();
        }
    }
}
