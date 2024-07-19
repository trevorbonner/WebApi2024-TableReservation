using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITableService
    {
        List<TableDto> GetAllTables();
        TableDto GetTableById(int id);
        void UpdateTable(TableDto table);
        TableDto AddTable(TableDto table);
        void DeleteTableById(int id);
    }
}
