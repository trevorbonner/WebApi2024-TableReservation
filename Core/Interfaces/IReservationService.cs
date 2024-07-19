using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDto> GetAllResrevations();
        ReservationDto GetReservationById(int id);
        void UpdateReservation(ReservationDto resrevation);
        ReservationDto AddReservation(ReservationDto resrevation);
        void DeleteReservationById(int id);
    }
}
