using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITableRepo
    {
        List<Table> GetAllTables();
        Table GetTableById(int id);
        void UpdateTable(Table table);
        Table AddTable(Table table);
        void DeleteTableById(int id);
    }
}
