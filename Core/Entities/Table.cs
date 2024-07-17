﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Table : BaseEntity
    {
        public Table()
        {
            Reservations = new List<Reservation>();
        }

        public int Maxseating { get; set; }
        public int TableNumber { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
