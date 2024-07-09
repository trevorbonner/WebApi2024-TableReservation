using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Table : BaseEntity
    {
        public int Maxseating { get; set; }
        public int TableNumber { get; set; }
    }
}
