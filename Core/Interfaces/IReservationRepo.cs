using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReservationRepo
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        void UpdateReservation(Reservation reservation);
        Reservation AddReservation(Reservation reservation);
        void DeleteReservationById(int id);
    }
}
