using Core.Entities;
using Core.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class ReservationRepo : IReservationRepo, IScoped
    {
        private DataContext context;

        public ReservationRepo(DataContext context)
        {
            this.context = context;
        }

        public Reservation AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
