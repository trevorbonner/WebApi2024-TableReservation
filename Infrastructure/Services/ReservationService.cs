using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReservationService : IReservationService, IScoped
    {
        private IReservationRepo repo;
        private IMapper mapper;

        public ReservationService(IReservationRepo repo, IMapper mapper) 
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public ReservationDto AddReservation(ReservationDto resrevation)
        {
            var newReservation = mapper.Map<Reservation>(resrevation);
            //repo.AddReservation(newReservation);

            resrevation = mapper.Map<ReservationDto>(newReservation);

            return resrevation;
        }

        public void DeleteReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReservationDto> GetAllResrevations()
        {
            throw new NotImplementedException();
        }

        public ReservationDto GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto resrevation)
        {
            throw new NotImplementedException();
        }
    }
}
