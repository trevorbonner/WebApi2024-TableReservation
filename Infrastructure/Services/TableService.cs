using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TableService : ITableService
    {
        private ITableRepo repo;

        public TableService(ITableRepo repo)
        {
            this.repo = repo;
        }

        public Table AddTable(Table table)
        {
            table.Id = 1;
            table.LastUpdatedDateTime= DateTime.Now;

            return table;
        }

        public void DeleteTableById(int id)
        {
            //do stuff in the future
        }

        public List<Table> GetAllTables()
        {
            return new List<Table>();
        }

        public Table GetTableById(int id)
        {
            return new Table();
        }

        public void UpdateTable(Table table)
        {
            //TODO
        }
    }
}
