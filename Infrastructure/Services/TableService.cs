using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TableService : ITableService, IScoped
    {
        private ITableRepo repo;

        public TableService(ITableRepo repo)
        {
            this.repo = repo;
        }

        public Table AddTable(Table table)
        {
            var newTable = new Core.Entities.Table()
            {
                Maxseating = table.MaxSeating,
                TableNumber = table.TableNumber,
                LastUpdatedDateTime = DateTime.Now
            };

            repo.AddTable(newTable);

            return table;
        }

        public void DeleteTableById(int id)
        {
            repo.DeleteTableById(id);
        }

        public List<Table> GetAllTables()
        {
            var table = new Table()
            {
                Id = 1,
                IsDeleted = false,
                LastUpdatedDateTime = DateTime.Now,
                MaxSeating = 4,
                TableNumber = 1
            };

            var table1 = new Table()
            {
                Id = 2,
                IsDeleted = true,
                LastUpdatedDateTime = DateTime.Now,
                MaxSeating = 5,
                TableNumber = 2
            };


            var table2 = new Table()
            {
                Id = 3,
                IsDeleted = false,
                LastUpdatedDateTime = DateTime.Now,
                MaxSeating = 8,
                TableNumber = 3,
                IsReserved = true
            };

            var table3 = new Table()
            {
                Id = 4,
                IsDeleted = false,
                LastUpdatedDateTime = DateTime.Now,
                MaxSeating = 8,
                TableNumber = 4
            };

            return new List<Table>() { table, table1, table2, table3 };
        }

        public Table GetTableById(int id)
        {
            var foundTable = repo.GetTableById(id); 
            if(foundTable != null)
            {
                var table = new Table()
                {
                    TableNumber = foundTable.TableNumber,
                    MaxSeating = foundTable.Maxseating,
                    IsReserved = true
                };

                return table;
            }

            return null;
        }

        public void UpdateTable(Table table)
        {
            //TODO
        }
    }
}
