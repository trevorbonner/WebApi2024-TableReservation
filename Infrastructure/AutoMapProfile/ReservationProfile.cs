using AutoMapper;
using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapProfile
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
        }
    }
}
