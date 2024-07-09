using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Table : BaseModel
    {
        public int Maxseating { get; set; }
        public int TableNumber { get; set; }
    }
}
