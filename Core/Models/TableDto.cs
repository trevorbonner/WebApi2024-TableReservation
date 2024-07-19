using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TableDto
    {
        public int Id { get; set; }
        public int MaxSeating { get; set; }
        public int TableNumber { get; set; }
        public bool IsReserved { get; set; }
    }
}
